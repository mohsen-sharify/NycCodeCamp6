﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using NycCodeCamp.WP7App.ViewModels;
using CoreEntities = CodeCamp.Core.Entities;

namespace NycCodeCamp.WP7App.Pages
{
    public partial class SessionsByTag : PhoneApplicationPage
    {
        public SessionsByTag()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            DataContext = new SessionsByTagViewModel(NavigationContext.QueryString["tag"]);
        }

        private void SessionSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;

            ((ListBox)sender).SelectedItem = null;

            var session = (CoreEntities.Session)e.AddedItems[0];
            NavigationService.Navigate(new Uri("/Pages/Session.xaml?key=" + session.Key, UriKind.Relative));
        }
    }
}