using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp1.Modello
{
    public class Pagina : INotifyPropertyChanged
    {
        public Pagina()
        {
            VisiteTotali = 0;
            UltimaVisita = DateTime.MinValue;
        }
        public string Nome { get; set; }

        private int visiteTotali;
        public int VisiteTotali
        {
            get
            {
                return visiteTotali;
            }
            set
            {
                visiteTotali = value;
                OnPropertyChanged("VisiteTotali");
                OnPropertyChanged("Riepilogo");
            }
        }

        private DateTime ultimaVisita;
        public DateTime UltimaVisita
        {
            get
            {
                return ultimaVisita;
            }
            set
            {
                ultimaVisita = value;
                OnPropertyChanged("UltimaVisita");
                OnPropertyChanged("Riepilogo");
            }
        }

        public string Riepilogo
        {
            get
            {
                if (VisiteTotali > 0)
                    return string.Format("Visite: {0}, Ultima: {1:HH.mm.ss}", VisiteTotali, UltimaVisita);

                return "Nessuna visita";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
