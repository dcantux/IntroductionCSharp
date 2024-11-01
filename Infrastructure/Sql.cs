using MySqlConnector;


namespace IntroductionCSharp.Infrastructure
{
    public class Sql
    {
        private static readonly MySqlConnection? instance_db = null;
  
        public static MySqlConnection Instance
        { 
                get 
                { 
                    if (instance_db == null)
                    {
                        var builder = new MySqlConnectionStringBuilder
                        {
                            Server = "127.0.0.1",
                            UserID = "root",
                            Password = "toor",
                            Port = 3306,
                            Database="testing"
                        };
                        var instance_db = new MySqlConnection(builder.ConnectionString);
                        instance_db.Open();    
                        return instance_db;
                    }
                    return instance_db;
                }
        } 

        public static MySqlDataReader Query(String query, MySqlConnection dbConn)
        {
            var command = new MySqlCommand(query, dbConn);
            return command.ExecuteReader();
        }
    }

}
