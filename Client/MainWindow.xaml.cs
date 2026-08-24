using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.IO;
using System.Windows.Media.Imaging;
using BusinessServer;
using DataContracts;
using Library;


namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChannelFactory<BusinessServerInterface> factory;
        BusinessServerInterface foob;

        delegate DataStruct SearchDelegate(string lastName0);
        public MainWindow()
        {
            InitializeComponent();

            NetTcpBinding tcp = new NetTcpBinding();
            tcp.MaxReceivedMessageSize = 10 * 1024 * 1024;
            tcp.MaxBufferSize = 10 *1024 * 1024;

            string URL = "net.tcp://localhost:8200/BusinessServer";

            factory = new ChannelFactory<BusinessServerInterface>(tcp, URL);

            foob = factory.CreateChannel();

            try
            {
                TotalNum.Text = foob.GetNumEntries().ToString();

            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("DataServer is not running. Please start the DataServer first.");
                Application.Current.Shutdown();
            }
            catch (CommunicationException)
            {
                MessageBox.Show("DataServer is not running. Please start the DataServer first.");
            }


        }
        private void LoadPhoto(int index)
        {
            try
            {

                byte[] data = foob.GetPhoto(index);

                if (data == null || data.Length == 0)
                {
                    PhotoBox.Source = null;
                    return;
                }


                using (MemoryStream ms = new MemoryStream(data))
                {
                    BitmapImage img = new BitmapImage();

                    img.BeginInit();
                    img.CacheOption = BitmapCacheOption.OnLoad;
                    img.StreamSource = ms;
                    img.EndInit(); 
                    img.Freeze();

                    PhotoBox.Source = img;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "LoadPhoto Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

       private void OnSearchComplete(IAsyncResult ar)
        {
            SearchDelegate searchDel = (SearchDelegate)ar.AsyncState;
            DataStruct result = searchDel.EndInvoke(ar);
            if (result != null)
            {
                FNameBox.Text = result.firstName;
                LNameBox.Text = result.lastName;
                BalanceBox.Text = result.balance.ToString("C");
                AcctNoBox.Text = result.accountNumber.ToString();
                PinBox.Text = result.pin.ToString("D4");
                LoadPhoto(result.index);
            }
            else
            {
                MessageBox.Show("No record found for last name: " + SearchBox.Text);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string lastName =SearchBox.Text;

            SearchDelegate searchDel = foob.SearchByLastName;

            searchDel.BeginInvoke(
                lastName,
                OnSearchComplete,
                searchDel);
        }
        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;


            if (!Int32.TryParse(IndexNum.Text, out index))
            {
                MessageBox.Show("Please enter a valid integer for the index.");
                return;
            }

            try
            {
                string fName = "", lName = "";
                int bal = 0;
                uint acct = 0, pin = 0;
                index = Int32.Parse(IndexNum.Text);
                foob.GetValuesForEntry(index, out acct, out pin, out bal, out fName, out lName);
                LoadPhoto(index);
                FNameBox.Text = fName;
                LNameBox.Text = lName;
                BalanceBox.Text = bal.ToString("C");
                AcctNoBox.Text = acct.ToString();
                PinBox.Text = pin.ToString("D4");

            }
            catch (FaultException<IndexFault> ex)
            {
                MessageBox.Show("Recordd not found ");
            }
            catch (TimeoutException)
            {
                MessageBox.Show("The request timed out. Please try again.");
            }
            catch (CommunicationException ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Communication Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }


        }
    }
}
