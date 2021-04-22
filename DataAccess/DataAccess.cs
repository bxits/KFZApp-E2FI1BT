using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTypes;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class DataAccess
    {
        //"CRUD" - "C"reate, "R"ead, "U"pdate, "D"elete - Szenario
        public void SaveKFZ(KFZ kfz)
        {
            MessageBox.Show($"Jetzt wird KFZ {kfz.Kennzeichen} gespeichert.");
            //In Azure-DB speichern INSERT-Statement
            MySqlConnection myConnection = new MySqlConnection("SERVER=localhost;DATABASE=kfzapp;UID=u_kfzapp;PASSWORD=u_kfzapp;");
            myConnection.Open();

            //INSERT-Statement zusammenbauen.
            string insertSQL = $"INSERT INTO `kfz`(`FahrgestellNr`, `Kennzeichen`, `Leistung`, `Typ`)" +
                $" VALUES ('{kfz.FahrgestellNr}','{kfz.Kennzeichen}',{kfz.Leistung},'{kfz.Typ}');";

            //Connection und SQL-Statement zusammenführen.
            MySqlCommand myCommand = new MySqlCommand(insertSQL);
            myCommand.Connection = myConnection;

            //SQL-Statement an DB senden.
            myCommand.ExecuteNonQuery();

            //Ressourcen wieder freigeben.
            myConnection.Close();

        }

        public void SaveKFZDetails(KFZ k)
        {
            MySqlConnection myConnection = new MySqlConnection("SERVER=localhost;DATABASE=kfzapp;UID=u_kfzapp;PASSWORD=u_kfzapp;");
            myConnection.Open();

            //UPDATE-Statement
            string sqlUpdateStatement =
                $"UPDATE kfz SET FahrgestellNr='{k.FahrgestellNr}'," +
                $" Kennzeichen='{k.Kennzeichen}', Leistung='{k.Leistung}'," +
                $" Typ='{k.Typ}' WHERE idkfz='{k.KFZid}';";

            //Connection und SQL-Statement zusammenführen.
            MySqlCommand myCommand = new MySqlCommand(sqlUpdateStatement);
            myCommand.Connection = myConnection;

            //SQL-Statement an DB senden.
            myCommand.ExecuteNonQuery();

            //Ressourcen wieder freigeben.
            myConnection.Close();
        }

        public void DeleteKFZ(KFZ k)
        {
            //k.KFZid
        }

        public List<KFZ> GetAllKFZ()
        {
            MySqlConnection myConnection = new MySqlConnection(
                "SERVER=localhost;DATABASE=kfzapp;UID=u_kfzapp;PASSWORD=u_kfzapp;");
            
            myConnection.Open();
            
            List<KFZ> allKFZ = new List<KFZ>();
            string sqlSELECT = "SELECT * FROM kfz;";
            MySqlCommand myCommand = new MySqlCommand(sqlSELECT);
            myCommand.Connection = myConnection;
            MySqlDataReader reader = myCommand.ExecuteReader();


            while (reader.Read())
            {
                KFZ newKFZ = new KFZ();
                newKFZ.KFZid = Convert.ToInt32(reader["idkfz"]);
                //usw....

                allKFZ.Add(newKFZ);
            }

            myConnection.Close();


            return allKFZ;
        }
    }
}
