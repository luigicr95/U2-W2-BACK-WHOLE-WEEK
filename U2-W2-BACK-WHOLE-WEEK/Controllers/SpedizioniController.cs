using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U2_W2_BACK_WHOLE_WEEK.Models;

namespace U2_W2_BACK_WHOLE_WEEK.Controllers
{
    public class SpedizioniController : Controller
    {
        // GET: Spedizioni
        public ActionResult GetSpedizioni()
        {
            Spedizione.listaSpedizioni.Clear();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConToSpedizioni"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT IDSpedizione, Spedizione.Indirizzo, Spedizione.Citta, DataSpedizione, Nome, Cognome FROM Spedizione INNER JOIN Clienti ON IDMittente = IDCliente";
                command.Connection = con;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Spedizione spedizione = new Spedizione();
                    Cliente mittente = new Cliente() { Nome = reader["Nome"].ToString(), Cognome = reader["Cognome"].ToString() };
                    spedizione.ID = Convert.ToInt32(reader["IDSpedizione"]);
                    spedizione.Mittente = mittente;
                    spedizione.Indirizzo = reader["Indirizzo"].ToString();
                    spedizione.Citta = reader["Citta"].ToString();
                    spedizione.DataSpedizione = Convert.ToDateTime(reader["DataSpedizione"]);
            

                    Spedizione.listaSpedizioni.Add(spedizione);


                }
            }
            catch (Exception ex)
            {

            }

            con.Close();

            return View(Spedizione.listaSpedizioni);

        }

        public ActionResult DetailsUpdates()
        {         
            
            return View();
        }

        public ActionResult _Details(int id)
        {
            Spedizione.listaSpedizioni.Clear();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConToSpedizioni"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@idSpedizione", id);
                command.CommandText = "SELECT IDSpedizione, Destinatario, Spedizione.Indirizzo, Spedizione.Citta, Costo, Peso, DataSpedizione, DataConsegna, Nome, Cognome FROM Spedizione INNER JOIN Clienti ON IDMittente = IDCliente WHERE IDSpedizione = @idSpedizione";
                command.Connection = con;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Spedizione spedizione = new Spedizione();
                    Cliente mittente = new Cliente() { Nome = reader["Nome"].ToString(), Cognome = reader["Cognome"].ToString() };
                    spedizione.ID = Convert.ToInt32(reader["IDSpedizione"]);
                    spedizione.Destinatario = reader["Destinatario"].ToString();
                    spedizione.Costo = Convert.ToDecimal(reader["Costo"]);
                    spedizione.Peso = Convert.ToDecimal(reader["Peso"]);
                    spedizione.Mittente = mittente;
                    spedizione.Indirizzo = reader["Indirizzo"].ToString();
                    spedizione.Citta = reader["Citta"].ToString();
                    spedizione.DataSpedizione = Convert.ToDateTime(reader["DataSpedizione"]);
                    spedizione.DataConsegna = Convert.ToDateTime(reader["DataConsegna"]);


                    Spedizione.listaSpedizioni.Add(spedizione);


                }
            }
            catch (Exception ex)
            {

            }

            con.Close();

            return PartialView(Spedizione.listaSpedizioni);
        }
    }
    
}