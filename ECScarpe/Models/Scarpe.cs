using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ECScarpe.Models
{
    public class Scarpe
    {
        public int IdScarpa { get; set; }
        public string Nome { get; set; }
        public double Prezzo { get; set; }
        public string Descrizione { get; set; }
        public string ImgPrinc { get; set; }
        public string ImgDet1 { get; set; }
        public string ImgDet2 { get; set; }
        public bool Vetrina { get; set; }

        //public static List<Scarpe> lScarpe = new List<Scarpe>();

        public static List<Scarpe>  GetAllScarpe()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["EcScarpe"].ToString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * From Scarpe";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            List<Scarpe> scarpes = new List<Scarpe>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Scarpe scarpa = new Scarpe();
                    scarpa.IdScarpa = Convert.ToInt32(reader["IdScarpa"]);
                    scarpa.Nome = reader["Nome"].ToString();
                    scarpa.Prezzo = Convert.ToInt32(reader["Prezzo"]);
                    scarpa.Descrizione = reader["Descrizione"].ToString();
                    scarpa.ImgPrinc = reader["ImgPrincipale"].ToString();
                    scarpa.ImgDet1 = reader["ImgDettagli1"].ToString();
                    scarpa.ImgDet2 = reader["ImgDettagli2"].ToString();
                    scarpa.Vetrina = Convert.ToBoolean(reader["Vetrina"]);
                    scarpes.Add(scarpa);
                }
            }
            connection.Close();
            return  scarpes;
        }

        public static Scarpe GetScarpa(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["EcScarpe"].ToString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@Id", id);
            command.CommandText = "Select * From Scarpe where IdScarpa = @Id";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            Scarpe scarpa = new Scarpe();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    scarpa.IdScarpa = Convert.ToInt32(reader["IdScarpa"]);
                    scarpa.Nome = reader["Nome"].ToString();
                    scarpa.Prezzo = Convert.ToInt32(reader["Prezzo"]);
                    scarpa.Descrizione = reader["Descrizione"].ToString();
                    scarpa.ImgPrinc = reader["ImgPrincipale"].ToString();
                    scarpa.ImgDet1 = reader["ImgDettagli1"].ToString();
                    scarpa.ImgDet2 = reader["ImgDettagli2"].ToString();
                    scarpa.Vetrina = Convert.ToBoolean(reader["Vetrina"]);
                    
                }
            }
            
            connection.Close();
            return scarpa;
        }

        public static void AggiornaScarpa(Scarpe s)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["EcScarpe"].ToString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@Id", s.IdScarpa);
            command.Parameters.AddWithValue("@Nome", s.Nome);
            command.Parameters.AddWithValue("@Prezzo", s.Prezzo);
            command.Parameters.AddWithValue("@Descrizione", s.Descrizione);
            command.Parameters.AddWithValue("@ImgPrinc", s.ImgPrinc);
            command.Parameters.AddWithValue("@ImgDet1", s.ImgDet1);
            command.Parameters.AddWithValue("@ImgDet2", s.ImgDet2);
            command.Parameters.AddWithValue("@Vetrina", s.Vetrina);

            command.CommandText = "UPDATE Scarpe set Nome = @Nome, Prezzo = @Prezzo, Descrizione = @Descrizione, ImgPrincipale = @ImgPrinc, ImgDettagli1 = @ImgDet1, ImgDettagli2 = @ImgDet2, Vetrina = @Vetrina   WHERE  IdScarpa = @Id";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            connection.Close();
          
        }

        public static void AggiungiScarpa(Scarpe s)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["EcScarpe"].ToString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@Nome", s.Nome);
            command.Parameters.AddWithValue("@Prezzo", s.Prezzo);
            command.Parameters.AddWithValue("@Descrizione", s.Descrizione);
            command.Parameters.AddWithValue("@ImgPrinc", s.ImgPrinc);
            command.Parameters.AddWithValue("@ImgDet1", s.ImgDet1);
            command.Parameters.AddWithValue("@ImgDet2", s.ImgDet2);
            command.Parameters.AddWithValue("@Vetrina", s.Vetrina);

            command.CommandText = "Insert into Scarpe  (Nome, Prezzo , Descrizione, ImgPrincipale, ImgDettagli1, ImgDettagli2 , Vetrina ) Values (@Nome,@Prezzo, @Descrizione, @ImgPrinc,@ImgDet1,@ImgDet2, @Vetrina)";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            connection.Close();

        }
    } 
}