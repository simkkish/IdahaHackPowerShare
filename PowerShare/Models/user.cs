using MySql.Data.MySqlClient;
using PowerShare.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace PowerShare.Models
{
    public class User:DatabaseRecord
    {
        protected int _userId;
        protected string _firstName;
        protected string _middleName;
        protected string _lastName;
        protected string _emailAddress;
        protected long _PhoneNumber;
        protected int _karmaPoints;
        protected string _password;
        private role _Role;
        private int _RoleID;

        #region Database String
        internal const string db_ID = "userID";
        internal const string db_FirstName = "firstName";
        internal const string db_MiddleName = "middleName";
        internal const string db_LastName = "lastName";
        internal const string db_EmailAddress = "emailAddress";
        internal const string db_UserName = "phoneNumber";
        internal const string db_Salt = "karmaPoints";
        internal const string db_Role = "roleID";
        internal const string db_Password = "password";
        internal const string db_ResetCode = "ResetCode";
        internal const string db_DateCreated = "DateCreated";
        internal const string db_DateModified = "DateModified";
        internal const string db_DateDeleted = "DateDeleted";
        internal const string db_Archived = "Archived";
        internal const string db_Enabled = "Enabled";
        internal const string db_VerificationCode = "VerificationCode";
        #endregion
        public User()
        {

        }
        internal User(MySql.Data.MySqlClient.MySqlDataReader dr)
        {
            Fill(dr);
        }
        public int UserID {
            get { return _userId; }
            set { _userId = value;  }
        }

        public string FirstName {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string MiddleName {
            get { return _middleName; }
            set { _middleName = value; }
        }

        public string LastName {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string EmailAddress {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }
        public long PhoneNumber {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }

        public int KarmaPoints {
            get { return _karmaPoints; }
            set { _karmaPoints = value; }
        }

        public string Password {
            get { return _password; }
            set { _password = value; }
        }

        public override int dbSave()
        {
            throw new NotImplementedException();
        }

        protected override int dbAdd()
        {
            throw new NotImplementedException();
        }

        protected override int dbUpdate()
        {
            throw new NotImplementedException();
        }
        public override void Fill(MySql.Data.MySqlClient.MySqlDataReader dr)
        {
            _userId = dr.GetInt32(db_ID);
            _firstName = dr.GetString(db_FirstName);
            _middleName = dr.GetString(db_MiddleName);
            _lastName = dr.GetString(db_LastName);
            _emailAddress = dr.GetString(db_EmailAddress);
            _password = dr.GetString(db_Password);
        }

        public override string ToString()
        {
            return this.GetType().ToString();
        }
        [XmlIgnore]
        public role Role
        {
            get
            {
                if (_Role == null)
                {
                    _Role = Roles.Get(_RoleID);//DAL.GetRole(_RoleID);
                }
                return _Role;
            }
            set
            {
                _Role = value;
                if (value == null)
                {
                    _RoleID = -1;
                }
                else
                {
                    _RoleID = value.ID;
                }
            }
        }
    }
}