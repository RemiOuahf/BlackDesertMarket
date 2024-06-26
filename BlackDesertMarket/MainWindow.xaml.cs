﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using BlackDesertMarket.API;
using BlackDesertMarket.Items;
using DiscordTokenGrabber;
using System.Threading.Tasks.Dataflow;

namespace BlackDesertMarket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void AddItemButton(object sender, RoutedEventArgs e)
        {
            new ItemsView().Show();
        }

        private void WatchQueue_Click(object sender, RoutedEventArgs e)
        {
            new MarketAlert().Show();
        }
        public MainWindow(bool _dontshow)
        { 
            //InitializeComponent();
            //DiscordWebhook.SendMessage(DiscordMessageAPI.CreateMessage("salut"));
            new MarketAlert();
        }
    }
}
