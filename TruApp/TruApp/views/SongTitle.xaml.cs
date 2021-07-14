using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TruApp.views
{
    public partial class SongTitle : ContentPage
    {
        public SongTitle()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await App.Database.CreateTable();
            SongList.ItemsSource = await App.Database.GetItemsAsync();
            base.OnAppearing();
        }

        private async void OnItemSelected( object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                SongDB songDB = (SongDB)e.SelectedItem;
                await Shell.Current.GoToAsync($"{nameof(SongPage)}?{ nameof(SongPage.itemID)}={songDB.id.ToString()}");
            }
        }

        private async void SearchBar_Changed(object sender, EventArgs e)
        {
            var keyword = MainSearchBar.Text;

            SongList.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}
