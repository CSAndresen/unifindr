using System;
using System.Collections.Generic;
using UniFindr_V2.ViewModels;
using UniFindr_V2.Views;
using Xamarin.Forms;

namespace UniFindr_V2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("//Profile", typeof(ProfilePage));
            Routing.RegisterRoute("//SearchResults_Abroad", typeof(SearchResultsPage_Abroad));
            Routing.RegisterRoute("//SearchResults_All", typeof(SearchResultsPage_All));
            Routing.RegisterRoute("//SearchResults_Home", typeof(SearchResultsPage_Home));
        }
    }
}