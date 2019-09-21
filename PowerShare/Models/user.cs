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
        protected string _userName;
        protected string _lastName;
        protected string _emailAddress;
        protected int _phoneNumber;
        protected int _karmaPoints;
        protected string _password;
        protected string _salt;
        protected role _role;
        protected int _roleID;

        #region Database String
        internal const string db_ID = "userID";
        internal const string db_FirstName = "firstName";
        internal const string db_UserName = "userName";
        internal const string db_LastName = "lastName";
        internal const string db_EmailAddress = "emailAddress";
        internal const string db_Salt = "salt";
        internal const string db_KarmaPoint = "karmapoints";
        internal const string db_Role = "roleID";
        internal const string db_Password = "password";
        internal const string db_PhoneNumber = "phoneNumber";
        internal const string db_DateModified = "DateModified";
        internal const string db_DateDeleted = "DateDeleted";
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
        public string Salt
        {
            get { return _salt; }
            set { _salt = value; }
        }
        public int KarmaPoint
        {
            get { return _karmaPoints; }
            set { _karmaPoints = value; }
        }
        public int phoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string UserName {
            get { return _userName; }
            set { _userName = value; }
        }

        public string LastName {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string EmailAddress {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }
        public int PhoneNumber {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
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
            _userName = dr.GetString(db_UserName);
            _lastName = dr.GetString(db_LastName);
            _emailAddress = dr.GetString(db_EmailAddress);
            _password = dr.GetString(db_Password);
            _salt = dr.GetString(db_Salt);
            _karmaPoints = dr.GetInt32(db_KarmaPoint);
            _phoneNumber = dr.GetInt32(db_PhoneNumber);
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
                if (_roleID == null)
                {
                    _role = Roles.Get(_roleID);
                }
                return _role;
            }
            set
            {
                _role = value;
                if (value == null)
                {
                    _roleID = -1;
                }
                else
                {
                    _roleID = value.ID;
                }
            }
        }
    }
}