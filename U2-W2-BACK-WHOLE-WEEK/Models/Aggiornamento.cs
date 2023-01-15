using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U2_W2_BACK_WHOLE_WEEK.Models
{
    public class Aggiornamento
    {
        public int ID { get; set; }
        public DateTime DataAggiornamento { get; set; }
        public string Descrizione { get; set; }
        public string Stato { get; set; }
        public string Luogo { get; set; }
        public int IDSpedizione { get; set; }

        public static List<Aggiornamento> listaAggiornamenti { get; set; } = new List<Aggiornamento>();
    }
}