using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruApp.views
{
    [QueryProperty(nameof(itemID), nameof(itemID))]
    public partial class SongPage : ContentPage
    {
        public string itemID
        {
            set
            {
                LoadSong(value);
            }
        }
        public SongPage()
        {
            InitializeComponent();
        }

        async void LoadSong(string itemID)
        {
            int id = Convert.ToInt32(itemID);
            SongDB songDB = await App.Database.GetItemAsync(id);
            BindingContext = songDB;
        }
    }
}