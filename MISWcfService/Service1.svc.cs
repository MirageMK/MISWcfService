using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MISWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string cString = ConfigurationManager.AppSettings["SQLSERVER_CONNECTION_STRING"];

        public List<Premet> getAllPredmeti()
        {
            List<Premet> toReturn = new List<Premet>();

            SqlConnection connection = new SqlConnection(cString);
            string sqlString = "SELECT * FROM Predmeti";
            SqlCommand cmd = new SqlCommand(sqlString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Premet p = new Premet();
                    p.id = Int32.Parse(reader[0].ToString());
                    p.naslov = reader[1].ToString();
                    p.smer = reader[2].ToString();
                    Int32.TryParse(reader[3].ToString(), out p.semestar);
                    Boolean.TryParse(reader[4].ToString(), out  p.zadolzitelen);
                    p.opis = reader[5].ToString();

                    toReturn.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Premet p = new Premet();
                p.id = -1;
                p.naslov = e.ToString();

                toReturn.Add(p);
                return toReturn;
            }
            finally
            {
                connection.Close();
            }
            return toReturn;
        }

        public List<Premet> getAllZadolzitelni(string nasoka)
        {
            List<Premet> toReturn = new List<Premet>();

            SqlConnection connection = new SqlConnection(cString);
            string sqlString = "SELECT * FROM Predmeti WHERE nasoka LIKE '%" + nasoka + "%' AND zadolzitelen=1";
            SqlCommand cmd = new SqlCommand(sqlString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Premet p = new Premet();
                    p.id = Int32.Parse(reader[0].ToString());
                    p.naslov = reader[1].ToString();
                    p.smer = reader[2].ToString();
                    Int32.TryParse(reader[3].ToString(), out p.semestar);
                    Boolean.TryParse(reader[4].ToString(), out  p.zadolzitelen);
                    p.opis = reader[5].ToString();

                    toReturn.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Premet p = new Premet();
                p.id = -1;
                p.naslov = e.ToString();

                toReturn.Add(p);
                return toReturn;
            }
            finally
            {
                connection.Close();
            }
            return toReturn;
        }

        public List<Premet> getAllIzborni(string nasoka)
        {
            List<Premet> toReturn = new List<Premet>();

            SqlConnection connection = new SqlConnection(cString);
            string sqlString = "SELECT * FROM Predmeti WHERE nasoka LIKE '%" + nasoka + "%' AND zadolzitelen=0";
            SqlCommand cmd = new SqlCommand(sqlString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Premet p = new Premet();
                    p.id = Int32.Parse(reader[0].ToString());
                    p.naslov = reader[1].ToString();
                    p.smer = reader[2].ToString();
                    Int32.TryParse(reader[3].ToString(), out p.semestar);
                    Boolean.TryParse(reader[4].ToString(), out  p.zadolzitelen);
                    p.opis = reader[5].ToString();

                    toReturn.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Premet p = new Premet();
                p.id = -1;
                p.naslov = e.ToString();

                toReturn.Add(p);
                return toReturn;
            }
            finally
            {
                connection.Close();
            }
            return toReturn;
        }
    }
}
