using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();

            var sdns = new List<Sdn>();
            var sdn = new Sdn();

            watch.Start();
            using (var con = new SqlConnection("Data Source=10.10.10.200;Initial Catalog=Ofac;User ID=sa;Password=Password11"))
            {
                var cmd = new SqlCommand("SELECT * FROM Sdn;", con);
                con.Open();
                var reader = cmd.ExecuteReader(behavior: System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    sdn = reader.ConvertToObject<Sdn>();
                    sdns.Add(sdn);
                }
            }
            watch.Stop();
            Console.WriteLine($"Time elapesed: {watch.ElapsedMilliseconds}ms for {sdns.Count} records");
        }

    }
}
