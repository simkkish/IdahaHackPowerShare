using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowerShare.Models
{
    public class LoginModel:DatabaseRecord
    {
        #region Constructors
        public LoginModel()
        {
        }
        internal LoginModel(MySql.Data.MySqlClient.MySqlDataReader dr)
        {
            Fill(dr);
        }
        #endregion

        #region private variable
        private string _FirstName;
        private string _LastName;
        private string _EmailAddress;
        private string _Address;
        private string _UserName;
        private string _Password;
        private string _ConfirmPassword;
        private string _Salt;
        #endregion

        #region Database String
        internal const string db_ID = "ID";
        internal const string db_FirstName = "FirstName";
        internal const string db_MiddleName = "MiddleName";
        internal const string db_LastName = "LastName";
        internal const string db_EmailAddress = "EmailAddress";
        internal const string db_Address = "Address";
        internal const string db_UserName = "UserName";
        internal const string db_Password = "Password";
        internal const string db_DateCreated = "DateCreated";
        internal const string db_Salt = "Salt";

        #endregion

        #region public Properites
        [Required]
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        [Required]
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        [Required]
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { _EmailAddress = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        [Required]
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        [Required]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set { _ConfirmPassword = value; }
        }
        /// <summary>
        /// Gets or sets the Salt for this PeerVal.User object
        /// </summary>
        public string Salt
        {
            get { return _Salt; }
            set { _Salt = value; }
        }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }


        #endregion

        #region Public Functions

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
        #endregion

        #region Public Subs
        /// <summary>
        /// Fills object from a MySqlClient Data Reader
        /// </summary>
        /// <remarks></remarks>
        public override void Fill(MySql.Data.MySqlClient.MySqlDataReader dr)
        {
            _ID = dr.GetInt32(db_ID);
            _FirstName = dr.GetString(db_FirstName);
            _LastName = dr.GetString(db_LastName);
            _EmailAddress = dr.GetString(db_EmailAddress);
            _UserName = dr.GetString(db_UserName);
            _Password = dr.GetString(db_Password);
            _Salt = dr.GetString(db_Salt);
        }
        #endregion

        public override string ToString()
        {
            return this.GetType().ToString();
        }
    }
}
