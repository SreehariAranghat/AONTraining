using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Library.Entities;
using LibraryAdDbContext;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    [SimpleJob(RuntimeMoniker.Net461)]
    [SimpleJob(RuntimeMoniker.Net481)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net80)]
    public  class DataServices
    {
        LibraryAdDbContext.LibraryAdDbContext dbContent = new LibraryAdDbContext.LibraryAdDbContext();

        [Benchmark]
        public List<User> TakeTop100EfCore()
        {
            return dbContent.Users.Take(100).ToList(); 
        }

        [Benchmark]
        public User FindByIdEfCore()
        {
            var userId = new Random().Next(1, 9000);
            return dbContent.Users.Find(userId);
        }

        [Benchmark]
        public List<User> TakeTop100Ado() { 
        
            List<User> users = new List<User>();
            using(var con = new SqlConnection("Server=tcp:aranghat.database.windows.net,1433;Initial Catalog=AonTraining;Persist Security Info=False;User ID=rootadmin;Password=Matrix1234$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();
                var sqlCommand = new SqlCommand("select top 100 * from users",con);
                var reqder = sqlCommand.ExecuteReader();

                while(reqder.Read()) { 
                    User u = new User();
                    u.CreatedDate = DateTime.Now;
                    u.Email = reqder["Email"].ToString();
                    u.Name = reqder["Name"].ToString();
                    u.Id = (int)reqder["Id"];
                    u.Password = reqder["Password"].ToString();

                    users.Add(u);
                }
            }

            return users;

        }

        [Benchmark]
        public List<User> TakeTop100AdoDataTable()
        {

            List<User> users = new List<User>();
            using (var con = new SqlConnection("Server=tcp:aranghat.database.windows.net,1433;Initial Catalog=AonTraining;Persist Security Info=False;User ID=rootadmin;Password=Matrix1234$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();
                var sqlCommand = new SqlCommand("select top 100 * from users", con);
                var da = new SqlDataAdapter(sqlCommand);
                var dataTable = new DataTable();
                da.Fill(dataTable);

                foreach(DataRow dataRow in  dataTable.Rows)
                { 
                    User u = new User();
                    u.CreatedDate = DateTime.Now;
                    u.Email = dataRow["Email"].ToString();
                    u.Name = dataRow["Name"].ToString();
                    u.Id = (int)dataRow["Id"];
                    u.Password = dataRow["Password"].ToString();

                    users.Add(u);
                }
            }

            return users;

        }

        [Benchmark]
        public User FindByIdAdo() {

            User u;

            using (var con = new SqlConnection("Server=tcp:aranghat.database.windows.net,1433;Initial Catalog=AonTraining;Persist Security Info=False;User ID=rootadmin;Password=Matrix1234$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();
                var userId = new Random().Next(1, 9000);
                var sqlCommand = new SqlCommand("select * from users where id = " + userId,con);
                var reqder = sqlCommand.ExecuteReader();
                reqder.Read();

                u = new User();
                u.CreatedDate = DateTime.Now;
                u.Email = reqder["Email"].ToString();
                u.Name = reqder["Name"].ToString();
                u.Id = (int)reqder["Id"];
                u.Password = reqder["Password"].ToString();
            }

            return u;

        }

        [Benchmark]
        public User FindByIdAdoDataTable()
        {

            User u;

            using (var con = new SqlConnection("Server=tcp:aranghat.database.windows.net,1433;Initial Catalog=AonTraining;Persist Security Info=False;User ID=rootadmin;Password=Matrix1234$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();
                var userId = new Random().Next(1, 9000);
                var sqlCommand = new SqlCommand("select * from users where id = " + userId, con);
                var da = new SqlDataAdapter(sqlCommand);
                var dataTable = new DataTable();
                da.Fill(dataTable);

                DataRow row = dataTable.Rows[0];

                u = new User();
                u.CreatedDate = DateTime.Now;
                u.Email = row["Email"].ToString();
                u.Name = row["Name"].ToString();
                u.Id = (int)row["Id"];
                u.Password = row["Password"].ToString();
            }

            return u;

        }

    }
}
