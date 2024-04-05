﻿#pragma checksum "..\..\..\MarketAlert.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1B868088963A7FF631F799301B20EB5A1941C6F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BlackDesertMarket;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BlackDesertMarket {
    
    
    /// <summary>
    /// MarketAlert
    /// </summary>
    public partial class MarketAlert : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\MarketAlert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ItemList;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\MarketAlert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RefreshButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\MarketAlert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DBListSearch;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\MarketAlert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddFilterButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\MarketAlert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowMoreButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\MarketAlert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ItemDBList;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\MarketAlert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Enhancement;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MarketAlert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilterListSearch;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\MarketAlert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteFilter;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\MarketAlert.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ItemFilter;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BlackDesertMarket;component/marketalert.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MarketAlert.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ItemList = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.RefreshButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\MarketAlert.xaml"
            this.RefreshButton.Click += new System.Windows.RoutedEventHandler(this.RefreshButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DBListSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AddFilterButton = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\MarketAlert.xaml"
            this.AddFilterButton.Click += new System.Windows.RoutedEventHandler(this.AddFilterButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ShowMoreButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\MarketAlert.xaml"
            this.ShowMoreButton.Click += new System.Windows.RoutedEventHandler(this.ShowMoreButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ItemDBList = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.Enhancement = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.FilterListSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.DeleteFilter = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\MarketAlert.xaml"
            this.DeleteFilter.Click += new System.Windows.RoutedEventHandler(this.DeleteFilter_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ItemFilter = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

