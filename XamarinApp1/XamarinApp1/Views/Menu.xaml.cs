using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinApp1.ViewModels;

namespace XamarinApp1.Views
{
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
            this.BindingContext = new MenuVM();
        }
    }
}
