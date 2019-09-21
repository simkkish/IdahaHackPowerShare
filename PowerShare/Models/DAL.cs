using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerShare.Models
{
    static class DAL
    {
        private static string _ConnectionString = null;

        private static string ConnectionString {
            get {
                if (_ConnectionString == null)
                {
                    //the next three lines of code are to allow for relative paths 
                    // and is based on code found at:
                    // https://stackoverflow.com/questions/1833640/connection-string-with-relative-path-to-the-database-file
                    string exeLoc = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string path = (System.IO.Path.GetDirectoryName(exeLoc));
                    AppDomain.CurrentDomain.SetData("DataDirectory", path);
                    _ConnectionString = @"Data Source = localHost; Initial Catalog = powershare; Integrated Security = True
";
                }
                return _ConnectionString;
            }

        }

        //public static List<Employee> GetEmployee()
        //{
        //    List<Employee> em = new List<Employee>();
        //    SqlConnection conn = null;

        //    try
        //    {
        //        conn = new SqlConnection(ConnectionString);
        //        conn.Open();
        //        SqlCommand comm = new SqlCommand("SEELCT * From Employees");
        //        comm.Connection = conn;
        //        SqlDataReader dr = comm.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            Employee e = new Employee();
        //            e.ID = (int)dr["EmployeeID"];
        //            e.Number = (int)dr["Number"];
        //            e.FirstName = (string)dr["FirstName"];
        //            e.MiddleName = (string)dr["MiddleName"];
        //            e.LastName = (string)dr["LastName"];

        //            em.Add(e);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        if (conn != null) conn.Close();
        //    }
        //    return em;



        //}
    }
}
