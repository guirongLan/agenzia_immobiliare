using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenzia_immobiliare
{
    class ClasseAgenzia
    {
        private string provincia;
        private int prezzo;
        private int Locali;
        private string Agente;

        public ClasseAgenzia()
        {
            provincia = "tha wuuuuuuuuarudo";
            Agente = "tha wuuuuuuuuarudo";
            Locali = 0;
            prezzo = 0;
        }
        public ClasseAgenzia(string Pro, int pre, int loc, string Age)
        {
            provincia = Pro;
            Agente = Age;
            Locali = loc;
            prezzo = pre;
        }
        //get
        public string GetProvincia()
        {
            return provincia;
        }
        public string GetAgente()
        {
            return Agente;
        }
        public int GetLocali()
        {
            return Locali;
        }
        public int GetPrezzo()
        {
            return prezzo;
        }
        //set
        public void SetProvincia(string pro)
        {
            provincia = pro;
        }
        public void SetAgente(string age)
        {
            Agente = age;
        }
        public void SetLocali(int loc)
        {
            Locali = loc;
        }
        public void SetPrezzo(int pre)
        {
            prezzo = pre;
        }
    }
}
