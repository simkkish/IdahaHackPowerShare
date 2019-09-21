using System;
using PowerShare.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PowerShare.Models
{
    public class role:DatabaseRecord
    {
        #region Constructors
        public role()
        {
        }
        internal role(MySql.Data.MySqlClient.MySqlDataReader dr)
        {
            Fill(dr);
        }

        #endregion

        #region Database String
        internal const string db_ID = "ID";
        internal const string db_Name = "Name";
        internal const string db_IsAdmin = "IsAdmin";
        internal const string db_Users = "Users";
        internal const string db_Role = "Role";
        internal const string db_Assignment = "Assignment";
        internal const string db_Group = "Group";
        #endregion

        #region Private Variables
        private string _Name;
        private PermissionSet _Users;
        #endregion

        #region public Properites
        /// <summary>
        /// Gets or sets the Name for this PeerVal.Role object.
        /// </summary>
        /// <remarks></remarks>
        /// 
        [Required]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value.Trim();
            }
        }

        /// <summary>
        /// Gets or sets the Users for this PeerVal.Role object.
        /// </summary>
        /// <remarks></remarks>

        [Required]
        [Display(Name = "Users Permissionset")]
        public PermissionSet Users
        {
            get
            {
                return _Users;
            }
            set
            {
                _Users = value;
            }
        }
        #endregion

        #region Public Functions

        public override string ToString()
        {
            return this.GetType().ToString();
        }

        public override int dbSave()
        {
            throw new NotImplementedException();
        }

        protected override int dbAdd()
        {
            _ID = DAL.AddRole(this);
            return ID;
        }

        protected override int dbUpdate()
        {
            return DAL.UpdateRole(this);
        }
        /// <summary>
        /// Calls DAL function to remove Role from the database.
        /// </summary>
        /// <remarks></remarks>
        #endregion

        #region Public Subs
        /// <summary>
        /// Fills object from a MySqlClient Data Reader
        /// </summary>
        /// <remarks></remarks>
        public override void Fill(MySql.Data.MySqlClient.MySqlDataReader dr)
        {
            _ID = dr.GetInt32(db_ID);
            _Name = dr.GetString(db_Name);
            _Users = new PermissionSet((byte)dr.GetUInt64(db_Users));
        }
        #endregion
    }
}