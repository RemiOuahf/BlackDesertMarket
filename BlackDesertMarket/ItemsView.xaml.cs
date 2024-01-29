﻿using System;
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
            string _json = request.RequestWithItemID(_id);
            if (!Utils.IsRequestValid(_json))
            {
                MessageBox.Show("Error with the request, make sure that the ID is from an marketable object");
                return;
            }
            APIRequest<Item> _jsonObject = JsonConverter.ConvertTo<APIRequest<Item>>(_json);
            //should be one item at each time
            if(_jsonObject.GetList().Count < 1)
            {
                MessageBox.Show("No object found");
                return;
            }
            save.Load();
            int _index = IsAlreadyIn(save.GetItems(), _jsonObject.GetList()[0]);
            if (_index !=-1)
            {
                MessageBoxButton _button = MessageBoxButton.YesNo;
                MessageBoxResult _result = MessageBox.Show("Already added \n Refresh it ?","Title",_button);
                if(_result == MessageBoxResult.Yes)
                {
                    List<Item> _items = save.GetItems();
                   _items[_index] = _jsonObject.GetList()[0];
                    save.Save(_items);
                    Load();
                }
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
            WebAPIRequest request = new WebAPIRequest();
            int _main;
            int _sub;
            if (!int.TryParse(ItemMain.Text, out _main) || !int.TryParse(ItemSub.Text,out _sub))
            {
                MessageBox.Show("Incorrect ID, string aren't allowed");
                return;
            }
            string _json = request.RequestMainSub(_main, _sub);
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
            for(int i =0; i < _jsonObject.GetList().Count; i++)
            {
                if (IsAlreadyIn(save.GetItems(), _jsonObject.GetList()[i]) != -1)
                {
                   MessageBox.Show("Already added");
                    continue;
                }
                save.Save(_jsonObject.GetList()[i]);
            }
            Load();
        }

        private void ItemList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            save.Load();
            selectedItemDisplay.Content = (Utils.GetItemWithIDFromList(save.GetItems(), (long)ItemList.SelectedValue)).ToString();

        }

        void RefreshAllItem()
        {
            save.Load();
            List<Item> _items = save.GetItems();
            for(int i =0; i < _items.Count; i++)
            {
                WebAPIRequest request = new WebAPIRequest();
                string _json = request.RequestWithItemID(_items[i].ID);
                if (!Utils.IsRequestValid(_json))
                {
                    //MessageBox.Show("Error with the request, make sure that the ID is from an marketable object");
                    continue;
                }
                APIRequest<Item> _jsonObject = JsonConverter.ConvertTo<APIRequest<Item>>(_json);
                //should be one item at each time
                if (_jsonObject.GetList().Count < 1)
                {
                    //MessageBox.Show("No object found");
                    continue;
                }
                _items[i] = _jsonObject.GetList()[0];
            }
            save.Save(_items);
            Load();
            MessageBox.Show("Refresh succeed");
        }

        private void refreshAllButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshAllItem();
        }
    }
}
