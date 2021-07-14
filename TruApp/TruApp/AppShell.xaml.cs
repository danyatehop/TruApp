using Xamarin.Forms;
using TruApp.views;

namespace TruApp
{

    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SongPage), typeof(SongPage));
            Routing.RegisterRoute(nameof(PiggyPage), typeof(PiggyPage));
        }
    }
}