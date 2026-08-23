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
using DataServer;


namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChannelFactory<DataServerInterface> factory;
        DataServerInterface foob;
        public MainWindow()
        {
            InitializeComponent();

            NetTcpBinding tcp = new NetTcpBinding();

            string URL = "net.tcp://localhost:8100/DataService";

            factory = new ChannelFactory<DataServerInterface>(tcp, URL);

            foob = factory.CreateChannel();

            TotalNum.Text = foob.GetNumEntries().ToString();
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            string fName = "", lName = "";
            int bal = 0;
            uint acct = 0, pin = 0;
            //On click, Get the index....
            index = Int32.Parse(IndexNum.Text);
            //Then, run our RPC function, using the out mode parameters...
            foob.GetValuesForEntry(index, out acct, out pin, out bal, out fName, out lName);
            //And now, set the values in the GUI!
            FNameBox.Text = fName;
            LNameBox.Text = lName;
            BalanceBox.Text = bal.ToString("C");
            AcctNoBox.Text = acct.ToString();
            PinBox.Text = pin.ToString("D4");
        }

    }
}
