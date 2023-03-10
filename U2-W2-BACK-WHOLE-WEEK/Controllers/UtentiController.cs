using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using U2_W2_BACK_WHOLE_WEEK.Models;

namespace U2_W2_BACK_WHOLE_WEEK.Controllers
{
    public class UtentiController : Controller
    {
        // GET: Utenti
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Utenti utente)
        {
            if(Utenti.Autenticazione(utente.Username, utente.Password))
            {
                FormsAuthentication.SetAuthCookie(utente.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }

            ViewBag.messaggio = "Username o Password errati";
            return View();
        }
    }
}