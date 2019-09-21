using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace PowerShare.Models
{
    public class DAL
    {
        private static string EditOnlyConnectionString = "Server=localhost;Database=powershare;Uid=root;Pwd='';Convert Zero Datetime=True;Allow Zero Datetime=True";
        private static string ReadOnlyConnectionString = "Server=localhost;Database=powershare;Uid=root;Pwd='';Convert Zero Datetime=True;Allow Zero Datetime=True";

        internal static List<role> GetRoles()
        {
            throw new NotImplementedException();
        }

        public static string _Pepper = "gLj23Epo084ioAnRfgoaHyskjasf";
        public static int _Stretches = 10000;
        private DAL()
        {
        }
        internal enum dbAction
        {
            Read,
            Edit
        }
        internal static void ConnectToDatabase(MySqlCommand comm, dbAction action = dbAction.Read)
        {
            try
            {
                if (action == dbAction.Edit)
                    comm.Connection = new MySqlConnection(EditOnlyConnectionString);
                else
                    comm.Connection = new MySqlConnection(ReadOnlyConnectionString);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
            }
            catch (Exception ex)
            {
                Exception  s = ex;
            }
        }

        internal static List<User> UserGetAll()
        {
            throw new NotImplementedException();
        }

        internal static User UserGetByID(int? uid)
        {
            throw new NotImplementedException();
        }

        public static int GetIntReader(MySqlCommand comm)
        {
            try
            {
                ConnectToDatabase(comm);
                comm.Connection.Open();
                int count = Convert.ToInt32(comm.ExecuteScalar());
                return count;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return 0;
            }
        }
        internal static int AddObject(MySqlCommand comm, string parameterName)
        {
            int retInt = 0;
            try
            {
                comm.Connection = new MySqlConnection(EditOnlyConnectionString);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Connection.Open();
                MySqlParameter retParameter;
                retParameter = comm.Parameters.Add(parameterName, MySqlDbType.Int32);
                retParameter.Direction = System.Data.ParameterDirection.Output;
                comm.ExecuteNonQuery();
                retInt = (int)retParameter.Value;
                comm.Connection.Close();
            }
            catch (Exception ex)
            {
                if (comm.Connection != null)
                    comm.Connection.Close();

                retInt = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return retInt;
        }
        internal static int UpdateObject(MySqlCommand comm)
        {
            int retInt = 0;
            try
            {
                comm.Connection = new MySqlConnection(EditOnlyConnectionString);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Connection.Open();
                retInt = comm.ExecuteNonQuery();
                comm.Connection.Close();
            }
            catch (Exception ex)
            {
                if (comm.Connection != null)
                    comm.Connection.Close();

                retInt = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return retInt;
        }
        internal static List<User> GetAllUsers()
        {
            MySqlCommand comm = new MySqlCommand("sproc_UserGetAll");
            List<User> retList = new List<User>();
            try
            {
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader dr = GetDataReader(comm);
                while (dr.Read())
                {
                    User user = new User(dr);
                    retList.Add(user);
                }
                comm.Connection.Close();
            }
            catch (Exception ex)
            {
                comm.Connection.Close();
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return retList;
        }

        internal static int UpdateRole(role role)
        {
            throw new NotImplementedException();
        }

        internal static int AddRole(role role)
        {
            throw new NotImplementedException();
        }

        public static MySqlDataReader GetDataReader(MySqlCommand comm)
        {
            try
            {
                ConnectToDatabase(comm);
                comm.Connection.Open();
                return comm.ExecuteReader();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }


    }
}
