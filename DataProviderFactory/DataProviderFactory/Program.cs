using static System.Console;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Threading.Tasks.Dataflow;

namespace DataProviderFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with Provider Factories *****\n");

            string dataProvider =
                ConfigurationManager.AppSettings["provider"];
            string connectionString =
                ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if(connection == null) 
                {
                    ShowError("Connection");
                    return;
                }

                WriteLine($"Your connection object is a: {connection.GetType().Name}");
                connection.ConnectionString = connectionString;
                connection.Open();
                var sqlConnection = connection as SqlConnection;
                
                if(sqlConnection != null )
                {
                    WriteLine(sqlConnection.ServerVersion);
                }       

                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    ShowError("Command");
                    return;
                }

                WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * From Inventory";

                using(DbDataReader dataReader = command.ExecuteReader()) 
                {
                    WriteLine($"Your data reader  objest is a: {dataReader.GetType().Name}");

                    WriteLine("\n***** Current Inventory *****");
                    while (dataReader.Read())
                        WriteLine($"-> Car #{dataReader["CarId"]} is a {dataReader["Make"]}.");
                }
            }
            ReadLine();
        }

        private static  void ShowError(string objectName) 
        {
            WriteLine($"There was an issue creating the {objectName}");
            ReadLine();
        }
    }
}