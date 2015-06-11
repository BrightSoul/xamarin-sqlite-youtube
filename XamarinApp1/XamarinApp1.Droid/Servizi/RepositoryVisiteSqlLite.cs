using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinApp1.Modello;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinApp1.Droid.Servizi.RepositoryVisiteSqlLiteAndroid))]
namespace XamarinApp1.Droid.Servizi
{
    public class RepositoryVisiteSqlLiteAndroid : IRepositoryVisite
    {
        private readonly SQLiteConnection conn;
        public RepositoryVisiteSqlLiteAndroid()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(folder, "app1.db"));
            conn.CreateTable<Visita>(CreateFlags.AllImplicit | CreateFlags.AutoIncPK);

        }

        public void Aggiungi(Visita visita)
        {
            conn.Insert(visita);
        }

        public IEnumerable<Visita> Elenca()
        {
            return conn.Table<Visita>().ToList();
        }
    }
}