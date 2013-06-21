﻿using System;
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
            string sqlString = "SELECT * FROM mGroup";
            SqlCommand cmd = new SqlCommand(sqlString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Premet p = new Premet();
                    p.ID = Int32.Parse(reader[0].ToString());
                    p.key = reader[1].ToString();
                    p.title = reader[2].ToString();
                    p.subtitle = reader[3].ToString();
                    p.backgroundImage = reader[4].ToString();
                    p.description = reader[5].ToString();

                    toReturn.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Premet p = new Premet();
                p.ID = -1;
                p.title = e.ToString();

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
