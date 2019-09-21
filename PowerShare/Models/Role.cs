using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerShare.Models
{
    public class Role
    {
        protected bool _isAnAdmin;
        protected int _userID;

        public Role()
        {

        }
        public Role(bool isAnAdmin, int Userid)
        {
            IsAnAdmin = isAnAdmin;
            UserId = Userid;
        }

        public bool IsAnAdmin {
            get { return _isAnAdmin; }
            set { _isAnAdmin = value; }
        }

        public int UserId {
            get { return _userID; }
            set { _userID = value; }
        }
    }
}
