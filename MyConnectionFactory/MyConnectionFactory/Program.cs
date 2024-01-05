using System;
using static System.Console;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Net.Http.Headers;
using System.Configuration;

namespace MyConnectionFactory
{
    enum DataProvider
    {
        SqlServer, OleDb, Odbc, None
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Very Simple Connection Factory *****\n");

            string dataProviderString = ConfigurationManager.AppSettings["provider"];

            DataProvider dataProvider = DataProvider.None;

            if(Enum.IsDefined(typeof(DataProvider), dataProviderString))
            {
                dataProvider =
                    (DataProvider)Enum.Parse(typeof(DataProvider),dataProviderString);
            }
            else
            {
                WriteLine("Sorry, no provider exists!");
                ReadLine();
                return;
            }

            IDbConnection myConnection = GetConnection(dataProvider);

            WriteLine($"Your connection is a {myConnection.GetType().Name ?? "unrecognized type"}");
            ReadLine();
        }

        static IDbConnection GetConnection(DataProvider dataProvider) 
        {
            IDbConnection connection = null;
            switch (dataProvider)
            {
                case DataProvider.SqlServer:
                    connection = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    connection = new OdbcConnection();
                    break;
            }
            return connection;
        }


    }
}