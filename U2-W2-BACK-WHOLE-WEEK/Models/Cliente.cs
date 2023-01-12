using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U2_W2_BACK_WHOLE_WEEK.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIVA { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public DateTime DataDiNascita { get; set; }
        public bool Azienda { get; set; }

        public static List<Cliente> listaClienti { get; set; } = new List<Cliente>();
    }
}