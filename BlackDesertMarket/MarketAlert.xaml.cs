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
using System.Windows.Threading;
using BlackDesertMarket.Save;
using DiscordTokenGrabber;
using System.Text.Json.Nodes;

namespace BlackDesertMarket
{
    /// <summary>
    /// Interaction logic for MarketAlert.xaml
    /// </summary>
    public partial class MarketAlert : Window
    {
        DispatcherTimer timer;
        //List<Item> itemFilter;
        SaveItem save = new SaveItem();
        int currentQueueSize = 0;
        List<QueueItem> currentQueue = new List<QueueItem>();
        public MarketAlert()
        {
            InitializeComponent();
            Load(ItemList);
            LoadItemDB();
            InitTimer();
            LoadFilterList();
            DBListSearch.TextChanged += DBListOnEnterInput;
            DBListSearch.GotFocus += OnGotFocusSearchBar;
            FilterListSearch.TextChanged += FilterListOnEnterInput;
            FilterListSearch.GotFocus += OnGotFocusSearchBar;
        }

        void Load(ListView _toEdit)
        {
            WebAPIRequest request = new WebAPIRequest();
            request.RequestQueue();
            request.OnRequestDone += (e) =>
            {
                Load_Done(e, _toEdit);
            };


        }

        private void Load_Done(string _json, ListView _toEdit)
        {
            List<Item> itemFilter = new List<Item>();
            APIRequest<QueueItem> _jsonObject = JsonConverter.ConvertTo<APIRequest<QueueItem>>(_json);
            itemFilter = save.LoadFilter();
            if (itemFilter.Count <= 0)
            {
                _toEdit.ItemsSource = _jsonObject.GetList();
                PingIfNewItem(_jsonObject.GetList());
            }
            else
            {
                List<QueueItem> _queueList = Utils.RemoveItemsFromList<QueueItem, Item>(itemFilter, _jsonObject.GetList());
                PingIfNewItem(_queueList);
                _toEdit.ItemsSource = _queueList;
            }
            //save.Clear();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Load(ItemList);
        }


        private void TimerTrigger(object e, EventArgs s)
        {
            Load(ItemList);
        }


        private void InitTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += TimerTrigger;
            timer.Interval = TimeSpan.FromSeconds(240);
            timer.Start();
        }

        private void LoadItemDB()
        {
            save.Load();
            ItemDBList.ItemsSource = save.GetItems();
            ItemDBList.DisplayMemberPath = "Name";
            ItemDBList.SelectedValuePath = "ID";
        }

        private void AddFilterButton_Click(object sender, RoutedEventArgs e)
        {
            List<Item> itemFilter = new List<Item>();
            itemFilter = save.LoadFilter();
            Item _item = save.GetItemFromID((long)ItemDBList.SelectedValue);
            if (IsAlreadyIn(itemFilter, _item))
            {
                MessageBox.Show("Already in the filter");
                return;
            }
            itemFilter.Add(_item);
            save.SaveFilter(itemFilter);
            ItemFilter.ItemsSource = itemFilter;
            LoadFilterList();
            Load(ItemList);
        }
        private void LoadFilterList()
        {
            List<Item> itemFilter = new List<Item>();
            itemFilter = save.LoadFilter();
            ItemFilter.ItemsSource = itemFilter;
        }

        private bool IsAlreadyIn(List<Item> _list, Item _object)
        {
            for(int i = 0; i < _list.Count; i++)
            {
                if (_list[i].ID == _object.ID)
                {
                    return true;
                }
            }
            return false;
        }

        private void DeleteFilter_Click(object sender, RoutedEventArgs e)
        {
            List<Item> itemFilter = new List<Item>();
            Item _selected = (Item)ItemFilter.SelectedValue;
            if(_selected == null)
                return;
           itemFilter = save.LoadFilter();
            RemoveAllReferenceOf(itemFilter, _selected);
           save.SaveFilter(itemFilter);
           LoadFilterList();
           Load(ItemList);

        }

        private void RemoveAllReferenceOf(List<Item> _list, Item _remove)
        {
            for(int i = 0; i < _list.Count; i++)
            {
                if (_list[i].ID == _remove.ID)
                {
                    _list.RemoveAt(i);
                }
            }
        }

        private List<Item> GetListWhichContain(List<Item> _toCheck,string _contain)
        {
            List<Item> _res = new List<Item>();

            for(int i =0; i < _toCheck.Count;i++)
            {
                if (_toCheck[i].Name.ToLower().Contains(_contain.ToLower()))
                    _res.Add(_toCheck[i]);
            }
            return _res;
        }

        private void DBListOnEnterInput(object _o, TextChangedEventArgs _e)
        {
            save.Load();
            ItemDBList.ItemsSource = GetListWhichContain(save.GetItems(), DBListSearch.Text);
        }

        private void OnGotFocusSearchBar(object _o, RoutedEventArgs _e)
        {
            ((TextBox)_o).Text = "";
        }
        private void FilterListOnEnterInput(object _o, TextChangedEventArgs _e)
        {
            save.Load();
            ItemFilter.ItemsSource = GetListWhichContain(save.LoadFilter(), FilterListSearch.Text);
        }

        private void ShowMoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemDBList.SelectedIndex == -1)
                return;
            save.Load();
            MessageBox.Show((Utils.GetItemWithIDFromList(save.GetItems(), (long)ItemDBList.SelectedValue)).ToString());
        }

        private void PingIfNewItem(List<QueueItem> _items)
        {
            QueueItem.ClearExpiredItems(ref currentQueue);
            for(int i = 0; i < _items.Count; i++)
            {
                if (!currentQueue.ContainsID(_items[i].ID, _items[i].EndTime))
                {
                    //DiscordWebhook.SendMessage(DiscordMessageAPI.CreateMessage(_items[i].ToDiscordString()));
                    currentQueue.Add(_items[i]);
                }
            }
        }
    }
}
