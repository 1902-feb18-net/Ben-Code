using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NETDisconnected
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter condition: ");
            var condition = Console.ReadLine();
            var commandString = $"SELECT * FROM Movie.Movie WHERE {condition}";

            //Disconnected architecture
            //rather than maximizing the speeed of getting the results
            //  we want to minimize the time the connection spends open

            //still need NuGet  package System.Data.SqlClient (for SQL Server)
            //  and using directing "using System.Data"

            //System.Data.DataSet can store data that DataReader gets
            //  with the help of DataAdapter
            var dataSet = new DataSet();

            var connectionString = Secret_Configuration.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                //disconnected architecture with ADO.NET

                //step 1: Open the connection
                connection.Open();
                using (var command = new SqlCommand(commandString, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    //step 2. Execute the query, filling the dataset
                    adapter.Fill(dataSet);
                    //(the DataAdapter is internally using DataReader)
                }
                //step 3.  Close the connection
                connection.Close();
            }

            //step 4.  Process the results
            //(not while connection is open, to get it close ASAP)

            //inside DataSet is some DataTables
            //inside DataTAble is DataColumn, DataRow
            //inside DataRow is object[]
            //this is on-generic

            //old-fashioned non-generic foeach (based on non-generic IEnumerable)
            //  does implicit downcasting
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                DataColumn idCol = dataSet.Tables[0].Columns["GenreId"];
                Console.WriteLine($"Genre #{row[idCol]}: {row[1]}");
            }
        }
    }
}
