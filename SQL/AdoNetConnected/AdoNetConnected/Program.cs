using System;
using System.Data.SqlClient;

namespace AdoNetConnected
{
    class Program
    {
        static void Main(string[] args)
        {
            //ADO.NET
            //originally Active Data Objects, ADO.  Later ADO.NET
            //ADO.NET is the "brand name"/namespace for all .NET data access stuff
            //But in practice, when we say "ADO.NET" we mean the old fashioned way
            //  we're about to see

            //ADO.NET has things in System.Data namespace
            //we need a data provider, - use NuGet package System.Data.SqlClient

            var connString = SecretConfiguration.ConnectionString;
            var condition = Console.ReadLine();
            var commString = $"SELECT * FROM Movie.Movie WHERE {condition}";

            //SQL injection:
            //user could enter "1 = 1"; DROP TABLE Movie.Movie;" and drop table
            //Solution: sanitize and validate all user input
            

            //for connected architecture

            using (var connection = new SqlConnection(connString))
            {
                //1. open the connection
                connection.Open();

                //2.  execute query
                var connString2 = "SELECT * FROM Movie.Movie;";

                using (var command = new SqlCommand(connString2, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //we have command.ExecuteReader which returns a DataReader
                        //  for SELECt queries...
                        //we have command.ExecuteNonQuery whicih just returns number
                        //  of rows affected, for DELETE, INSERT, etc.

                        //3.  process the results
                        if (reader.HasRows)
                        {
                            //"read.Read" advances the "cursor" through the results
                            //  one row at a time
                            //the results are coming into the computer's network buffer
                            //  and DataReader is reading them each as soon as they come in
                            //(networks are slow compared to code)

                            while (reader.Read())
                            {
                                object id = reader["MovieId"];
                                object title = reader["Title"];
                                object fullTitle = reader.GetString(5); //fifth column

                                //I could do downcasting and instantiate some Movie class
                                //Or jsut print the results directly

                                Console.WriteLine($"Movie #{ id}: { fullTitle}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("no rows returned");
                        }

                        //4. close the connection
                        connection.Close();


                    }

                }


            }

                SqlConnection connection = new SqlConnection();

        }
    }
}
