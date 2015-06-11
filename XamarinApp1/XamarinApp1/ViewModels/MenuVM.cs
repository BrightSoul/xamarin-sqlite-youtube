using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp1.Messaggi;
using XamarinApp1.Modello;

namespace XamarinApp1.ViewModels
{
    public class MenuVM
    {

        private IEnumerable<Pagina> pagine;
        private IRepositoryVisite repo;
        public MenuVM()
        {
            repo = DependencyService.Get<IRepositoryVisite>();
            var visite = repo.Elenca().GroupBy(v => v.Pagina);
            var nomiPagine = new[] { "Homepage", "Corsi", "Sedi", "Video" };

            pagine = from pagina in nomiPagine
                       join visita in visite on pagina equals visita.Key into groupjoin
                       from gruppo in groupjoin.DefaultIfEmpty()
                       select new Pagina { Nome = pagina, VisiteTotali = gruppo == null ? 0 : gruppo.Count(), UltimaVisita = gruppo == null ? DateTime.MinValue : gruppo.Max(v => v.Data) };
        }

        private Pagina _paginaSelezionata;
        public Pagina PaginaSelezionata
        {
            get
            {
                return _paginaSelezionata;
            }
            set
            {
                _paginaSelezionata = value;

                if (value != null)
                {
                    var visita = new Visita { Data = DateTime.Now, Pagina = value.Nome };
                    repo.Aggiungi(visita);
                    value.UltimaVisita = visita.Data;
                    value.VisiteTotali++;
                    MessagingCenter.Send<PaginaVisitata>(new PaginaVisitata { Nome = value.Nome }, "");
                }
            }
        }

        public IEnumerable<Pagina> Pagine
        {
            get
            {
                return pagine;
            }
        }
    }
}
