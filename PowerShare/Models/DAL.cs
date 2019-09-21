using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;

namespace PowerShare.Models
{
    static class DAL
    {
        private static string _ConnectionString = "server = localhost; user id = root; persistsecurityinfo=True;database=powershare";

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

        
    }
}
