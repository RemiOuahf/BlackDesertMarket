using BlackDesertMarket.API;
using BlackDesertMarket.Items;
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
using System.Windows.Shapes;
using BlackDesertMarket.Json;
using System.Timers;

namespace BlackDesertMarket
{
    /// <summary>
    /// Interaction logic for MarketAlert.xaml
    /// </summary>
    public partial class MarketAlert : Window
    {
        Timer refreshTimer = new Timer(30000);
        public MarketAlert()
        {
            InitializeComponent();
            Load();
           // refreshTimer.Elapsed += (e, s) => { Load(); };
           // refreshTimer.Start();
           // refreshTimer.AutoReset = true;
        }

        void Load()
        {
            ItemList.Items.Clear();
            WebAPIRequest request = new WebAPIRequest();

            APIRequest<QueueItem> _jsonObject = JsonConverter.ConvertTo<APIRequest<QueueItem>>(request.RequestQueue());
            for (int i= 0; i < _jsonObject.GetList().Count; i++)
            {
                ItemList.Items.Add(_jsonObject.GetList()[i].ToString());
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
