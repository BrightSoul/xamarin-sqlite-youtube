using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp1.Modello
{
    public interface IRepositoryVisite
    {
        IEnumerable<Visita> Elenca();
        void Aggiungi(Visita visita);
    }
}
