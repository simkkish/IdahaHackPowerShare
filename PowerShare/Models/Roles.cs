using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerShare.Models
{
    public class Roles
    {
        private static List<role> _List;

        public static List<role> List
        {
            get
            {
                if (_List == null)
                    _List = DAL.GetRoles();
                return _List;
            }
            set { _List = value; }
        }

        public static void ResetList()
        {
            _List = null;
        }

        internal static role Get(int roleID)
        {
            return List.FirstOrDefault(r => r.ID == roleID);
        }
    }
}
