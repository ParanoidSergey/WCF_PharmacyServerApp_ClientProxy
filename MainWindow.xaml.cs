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
using WCF_PharmacyServerApp_ClientProxy.ServiceReference1;

namespace WCF_PharmacyServerApp_ClientProxy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Аскорбинки
        TestClient proxy = new TestClient();
        IAsyncResult AsyncRes;
        static List<CatalogModelService> _items;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgCatalog.Items.Clear();

                MessageBox.Show(proxy.test(3).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //AsyncRes = proxy.BeginGet(txbProductName.Text, Callback, proxy);

            //foreach (CatalogModelService item in _items)
            //    {
            //        dgCatalog.Items.Add(item);
            //    }
        }

        private void txbProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbProductName.Text != "" && txbProductName.Text != " ")
            {
                btnFind.IsEnabled = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _items = new List<CatalogModelService>();
        }

        //---------------------------------------------------------------------------------

        static void Callback(IAsyncResult res)
        {
            try
            {
                _items = ((TestClient)res.AsyncState).EndGet(res).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
