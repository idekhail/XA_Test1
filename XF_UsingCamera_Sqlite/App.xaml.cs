using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF_UsingCamera_Sqlite
{
    public partial class App : Application
    {
        static DB db;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static DB SQLiteObj
        {
            get
            {
                if (db == null)
                {
                    db = new DB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DB1.db3"));
                }
                return db;
            }
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
