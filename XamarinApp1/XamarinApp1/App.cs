using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinApp1.Messaggi;
using XamarinApp1.Views;

namespace XamarinApp1
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var masterDetailPage = new MasterDetailPage
            {
                Master = new Menu(),
                Detail = new Homepage()
            };

            MessagingCenter.Subscribe<PaginaVisitata>(this, "", p =>
            {
                masterDetailPage.IsPresented = false;
                var tipo = Type.GetType("XamarinApp1.Views." + p.Nome);
                masterDetailPage.Detail = Activator.CreateInstance(tipo) as Page;
            });

            this.MainPage = masterDetailPage;

            
                
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
