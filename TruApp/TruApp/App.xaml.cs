using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace TruApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "songs.db";
        public static SongAsyncRepository database;
        public static SongAsyncRepository Database
        {
            get
            {
                if(database == null)
                {
                    string dbPath = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);

                    if (!File.Exists(dbPath))
                    {

                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;

                        using (Stream stream = assembly.GetManifestResourceStream($"TruApp.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  
                                fs.Flush();
                            }
                        }
                    }

                    database = new SongAsyncRepository(dbPath);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
