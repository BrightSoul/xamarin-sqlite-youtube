using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp1.Modello;

namespace XamarinApp1.ViewModels
{
    public class HomepageVM
    {
        IRepositoryVisite _repo;
        public HomepageVM()
        {
            _repo = DependencyService.Get<IRepositoryVisite>();
        }

        private IEnumerable<Visita> _visite;
        public IEnumerable<Visita> Visite
        {
            get
            {
                if (_visite == null)
                {           
                    _visite = _repo.Elenca();
                }
                return _visite;
            }
        }
    }
}
