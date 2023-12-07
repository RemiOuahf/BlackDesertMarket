using System;
using System.Collections.Generic;
using System.IO;
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
using System.Drawing;
using BlackDesertMarket.API;
using BlackDesertMarket.Items;
using BlackDesertMarket.Json;
using BlackDesertMarket.Save;

namespace BlackDesertMarket
{
    /// <summary>
    /// Interaction logic for ItemsView.xaml
    /// </summary>
    public partial class ItemsView : Window
    {
        SaveItem save = new SaveItem();

        public ItemsView()
        {
            InitializeComponent();
            IDTextArea.TextChanged += TextChanged;
            Load();
        }


        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            int _value = 0;
            if (int.TryParse(((TextBox)sender).Text, out _value))
            {
                ((TextBox)sender).Text = _value.ToString();
            }
            else
            {
                ((TextBox)sender).Text = "";
            }
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            WebAPIRequest request = new WebAPIRequest();
            APIRequest<Item> _jsonObject = JsonConverter.ConvertTo<APIRequest<Item>>(request.RequestWithItemID(int.Parse(IDTextArea.Text)));
            //should be one item at each time
            if(_jsonObject.GetList().Count < 1)
            {
                return;
            }
            SaveItem _save = new SaveItem();
            _save.Save(_jsonObject.GetList()[0]);
            Load();
        }

        void Load()
        {
            ItemList.Items.Clear();
            save.Load();
            List<Item> items = save.GetItems();
            for(int i =0; i<items.Count; i++)
            {
                ItemList.Items.Add(items[i].Name);
            }
        }
    }
}
