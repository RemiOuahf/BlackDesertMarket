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
using System.Security.Cryptography;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Threading;
using System.ComponentModel;

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
            //TestFillItems();
            Closing += Close;
        }

        ~ItemsView()
        {

        }

        void Close(object sender, CancelEventArgs e)
        {
            save = null;
            ItemList.Resources.Clear();
            ItemList.ItemsSource = null;
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
            int _id;
            if (!int.TryParse(IDTextArea.Text, out _id))
            {
                MessageBox.Show("Incorrect ID, string aren't allowed");
                return;
            }
            request.RequestWithItemID(_id);
            request.OnRequestDone += FindButtonClick_Done;
        }
        private void FindButtonClick_Done(string _json)
        {
            SaveItem save = new SaveItem();
            if (!Utils.IsRequestValid(_json))
            {
                MessageBox.Show("Error with the request, make sure that the ID is from an marketable object");
                return;
            }
            APIRequest<Item> _jsonObject = JsonConverter.ConvertTo<APIRequest<Item>>(_json);
            //should be one item at each time
            if (_jsonObject.GetList().Count < 1)
            {
                MessageBox.Show("No object found");
                return;
            }
            save.Load();
            int _index = IsAlreadyIn(save.GetItems(), _jsonObject.GetList()[0]);
            if (_index != -1)
            {
                AskToRefreshItem(_index, _jsonObject);
                return;
            }
            save.Save(_jsonObject.GetList()[0]);
            Load();
        }
        void Load()
        {
            save.Load();
            ItemList.ItemsSource = save.GetItems();
            ItemList.DisplayMemberPath = "Name";
            ItemList.SelectedValuePath = "ID";
        }

        int IsAlreadyIn(List<Item> _items, Item _toCheck)
        {

            for(int i = 0; i < _items.Count;i++)
            {
                if (_items[i].ID == _toCheck.ID)
                    return i;
            }
            return -1;
        }

        void TestFillItems()
        {
            ItemMain.Text = 45.ToString();
            for(int i =1; i < 5; i++)
            {
                ItemSub.Text = i.ToString();
                FindCategoriesButton_Click(null, new RoutedEventArgs());
            }
        }
        private void FindCategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            int _main;
            int _sub;
            if (!int.TryParse(ItemMain.Text, out _main) || !int.TryParse(ItemSub.Text,out _sub))
            {
                MessageBox.Show("Incorrect ID, string aren't allowed");
                return;
            }
            FindCategories(_main, _sub);

        }

        private void FindCategories(int _main, int _sub, bool _showMessage = true)
        {
            WebAPIRequest request = new WebAPIRequest();
            request.RequestMainSub(_main, _sub);
            request.OnRequestDone += (e) => FindCategoriesButton_done(e, _showMessage);
        }


        private void FindCategoriesButton_done(string _json, bool _showMessage)
        {
            SaveItem save = new SaveItem();
            if (!Utils.IsRequestValid(_json))
            {
                MessageBox.Show("Error with the request, make sure that the ID is from an marketable object");
                return;
            }
            APIRequest<Item> _jsonObject = JsonConverter.ConvertTo<APIRequest<Item>>(_json);
            //should be one item at each time
            if (_jsonObject.GetList().Count < 1)
            {
                MessageBox.Show("No object found");
                return;
            }
            save.Load();
            for (int i = 0; i < _jsonObject.GetList().Count; i++)
            {
                int _index = IsAlreadyIn(save.GetItems(), _jsonObject.GetList()[i]);
                if (_index != -1)
                {
                    RefreshItem(_index, _jsonObject, i);
                    continue;
                }
                save.Save(_jsonObject.GetList()[i]);
            }
            if(_showMessage)
               MessageBox.Show("Succeed");
            Load();
        }

        private void ItemList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SaveItem save = new SaveItem();
            save.Load();
            selectedItemDisplay.Content = (Utils.GetItemWithIDFromList(save.GetItems(), (long)ItemList.SelectedValue)).ToString();

        }
        private void AskToRefreshItem(int _index, APIRequest<Item> _jsonObject, int _jsonIndex = 0)
        {
            MessageBoxButton _button = MessageBoxButton.YesNo;
            MessageBoxResult _result = MessageBox.Show("Already added \n Refresh it ?", "Title", _button);
            if (_result == MessageBoxResult.Yes)
            {
                RefreshItem(_index, _jsonObject, _jsonIndex);
            }
        }
        private void RefreshItem(int _index, APIRequest<Item> _jsonObject, int _jsonIndex)
        {
            SaveItem save = new SaveItem();
            save.Load();
            List<Item> _items = save.GetItems();
            _items[_index] = _jsonObject.GetList()[_jsonIndex];
            save.Save(_items);
            Load();
        }

    }
}
