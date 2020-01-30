using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HelperClasses
{
    public class DBConnection
    {
        private DBConnection()
        {

        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string UID { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }

        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection instance = null;
        public static DBConnection Instance()
        {
            if (instance == null)
                instance = new DBConnection();
            return instance;
        }

        public DBConnection Initialise(string uid, string pass, string dbname, string host)
        {
            UID = uid;
            Password = pass;
            databaseName = dbname;
            Host = host;

            if (instance == null)
                instance = new DBConnection();
            return instance;
        }

        public bool Open()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;

                string connstring = string.Format("Server=" + Host + "; database={0}; UID=" + UID + "; password=" + Password, databaseName);
                connection = new MySqlConnection(connstring);

                try
                {
                    connection.Open();
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }

            return true;
        }

        public void Close()
        {
            if (connection == null)
                return;

            connection.Close();
            connection = null;
        }

        public void ExecuteNonQuery(string statement)
        {
            if (Open())
            {
                var cmd = new MySqlCommand(statement, connection);
                cmd.ExecuteNonQuery();
                Close();
            }
        }

        public List<string[]> Select(string query)
        {
            //Create a list to store the result
            List<string[]> list = new List<string[]>();

            //Open connection
            if (Open())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    //make string[] the size of the row being returned
                    string[] row = new string[dataReader.FieldCount];

                    //fill sting[] with row data
                    for (int i = 0; i < row.Length; i++)
                        row[i] = dataReader[i].ToString();

                    //add string[] to return list
                    list.Add(row);
                }

                dataReader.Close();
                Close();

                return list;
            }
            else return list;
        }

        public int Count(string table)
        {
            string query = "SELECT Count(*) FROM " + table;
            int Count = -1;

            if (Open())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                Close();

                return Count;
            }
            else return Count;
        }
    }
}
