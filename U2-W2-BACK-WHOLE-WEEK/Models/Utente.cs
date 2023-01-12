using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U2_W2_BACK_WHOLE_WEEK.Models
{
    public class Utente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public string Ruolo { get; set; }

    }
}