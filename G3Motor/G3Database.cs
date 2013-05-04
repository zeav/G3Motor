using System;
using MySql.Data.MySqlClient; // http://cdn.mysql.com/Downloads/Connector-Net/mysql-connector-net-6.6.5.msi // SQL Library is in folder.

namespace G3Motor
{   
    /**
     * Singleton class used to access the G3-Database.
    **/
    public sealed class G3Database
    {
        /**
         * Member variables.
        **/
        private static readonly G3Database instance = new G3Database();
        private MySqlConnection connection;
        private string errMsg;

        /* Static init. Singleton pattern instantiation. */
        public static G3Database Instance
        {
            get
            {
                return instance; // CIL initialization on first reference
            }
        }

        /**
         * Constructor.
        **/
        private G3Database()
        {
            string server = "int.zeav.no";
            string port = "3306";
            string database = "g3";
            string uid = "g3"; // should the user have limited rights?
            string password = "g3";
            string connectionString = String.Format("SERVER={0}; PORT={1}; DATABASE={2}; UID={3}; PASSWORD={4};", server, port, database, uid, password);

            connection = new MySqlConnection(connectionString);
        }

        /**
         * Private member functions.
        **/
        private bool Connect()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0: errMsg = "Server unavailable.\n" + e.StackTrace;
                        break;

                    case 1045: errMsg = "Invalid credentials\n" + e.StackTrace;
                        break;
                }

                return false;
            }
        }

        private bool Disconnect()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                errMsg = "Unable to disconnect.\n" + e.Message;
                return false;
            }
        }

        /**
         * Public member functions. 
        **/
        public bool Query(string query)
        {
            if (this.Connect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    this.Disconnect();
                }
            }

            return true;
        }

    }
}
