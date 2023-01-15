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
    [Authorize]
    public class ClientiController : Controller
    {
        // GET: Cliente
        public ActionResult GetPrivati()
        {
            Cliente.listaClienti.Clear();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConToSpedizioni"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("Azienda", false);
                command.CommandText = "SELECT * FROM CLIENTI WHERE Azienda = @azienda";
                command.Connection= con;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cliente clienti = new Cliente();
                    clienti.ID = Convert.ToInt32(reader["IDCliente"]);
                    clienti.Nome = reader["Nome"].ToString() ;
                    clienti.Cognome = reader["Cognome"].ToString();
                    clienti.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    clienti.Indirizzo = reader["Indirizzo"].ToString();
                    clienti.Citta = reader["Citta"].ToString();
                    clienti.DataDiNascita = Convert.ToDateTime(reader["DataDiNascita"]);

                    Cliente.listaClienti.Add(clienti);


                }
            }catch(Exception ex)
            {

            }

            con.Close();

            return View (Cliente.listaClienti);
            
        }

        public ActionResult AddPrivati()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPrivati(Cliente privato)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConToSpedizioni"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@Nome", privato.Nome);
                command.Parameters.AddWithValue("@Cognome", privato.Cognome);
                command.Parameters.AddWithValue("@CodiceFiscale", privato.CodiceFiscale);
                command.Parameters.AddWithValue("@Indirizzo", privato.Indirizzo);
                command.Parameters.AddWithValue("@Citta", privato.Citta);
                command.Parameters.AddWithValue("@DataDiNascita", privato.DataDiNascita);
                command.Parameters.AddWithValue("@Azienda", false);
                command.CommandText = "INSERT INTO Clienti (Nome, Cognome, CodiceFiscale, Indirizzo, Citta, DataDiNascita, Azienda) VALUES (@Nome, @Cognome, @CodiceFiscale, @Indirizzo, @Citta, @DataDiNascita, @Azienda)";
                command.Connection = con;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }

            con.Close();

            return RedirectToAction("GetPrivati");
        }

        public ActionResult GetAziende()
        {
           Cliente.listaClienti.Clear();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConToSpedizioni"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("Azienda", true);
                command.CommandText = "SELECT * FROM CLIENTI WHERE Azienda = @azienda";
                command.Connection = con;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cliente clienti = new Cliente();
                    clienti.ID = Convert.ToInt32(reader["IDCliente"]);
                    clienti.Nome = reader["Nome"].ToString();
                    clienti.PartitaIVA = reader["PartitaIVA"].ToString();
                    clienti.Indirizzo = reader["Indirizzo"].ToString();
                    clienti.Citta = reader["Citta"].ToString();

                    Cliente.listaClienti.Add(clienti);


                }
            }
            catch (Exception ex)
            {

            }

            con.Close();

            return View(Cliente.listaClienti);

        }

        public ActionResult AddAziende()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAziende(Cliente azienda)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConToSpedizioni"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@Nome", azienda.Nome);
                command.Parameters.AddWithValue("@PartitaIVA", azienda.PartitaIVA);
                command.Parameters.AddWithValue("@Indirizzo", azienda.Indirizzo);
                command.Parameters.AddWithValue("@Citta", azienda.Citta);
                command.Parameters.AddWithValue("@Azienda", true);
                command.CommandText = "INSERT INTO Clienti (Nome, PartitaIVA, Indirizzo, Citta, Azienda) VALUES (@Nome, @PartitaIVA, @Indirizzo, @Citta, @Azienda)";
                command.Connection = con;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }

            con.Close();

            return RedirectToAction("GetAziende");
        }
    }
}