using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U2_W2_BACK_WHOLE_WEEK.Models
{
    public class Spedizione
    {
        public int ID { get; set; }
        public string Destinatario { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public decimal Costo { get; set; }
        public decimal Peso { get; set; }
        public DateTime DataSpedizione { get; set; }
        public DateTime DataConsegna { get; set; }
        public Cliente Mittente { get; set; }
        public static List<Spedizione> listaSpedizioni { get; set; } = new List<Spedizione>();
    }
}