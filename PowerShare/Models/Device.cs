using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace PowerShare.Models
{
    public class Device:DatabaseRecord
    {
        protected int _userID;
        protected int _deviceID;
        protected string _deviceType;
        protected string _deviceName;
        protected string _chargerType;
        protected string _description;

        #region Database string
        internal const string db_deviceID = "deviceID";
        internal const string db_userID = "userID";
        internal const string db_deviceType = "deviceType";
        internal const string db_deviceName = "deviceName";
        internal const string db_chargerType = "chargerType";
        internal const string db_description = "description";
        #endregion

        public Device()
        {

        }
        internal Device(MySql.Data.MySqlClient.MySqlDataReader dr)
        {
           Fill(dr);
        }


        public int UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        }
        public int DeviceID
        {
            get
            {
                return _deviceID;
            }
            set
            {
                _deviceID = value;
            }
        }
        public  string DeviceType
        {
            get
            {
                return _deviceType;
            }
            set
            {
                _deviceType = value;
            }
        }
        public string DeviceName
        {
            get
            {
                return _deviceName;
            }
            set
            {
                _deviceName = value;
            }
        }
        public string ChargerType
        {
            get
            {
                return _chargerType;
            }
            set
            {
                _chargerType = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
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
            _deviceID = dr.GetInt32(db_deviceID);
            _userID = dr.GetInt32(db_userID);
            _deviceType = dr.GetString(db_deviceType);
            _deviceName = dr.GetString(db_deviceName);
            _chargerType = dr.GetString(db_chargerType);
            _description = dr.GetString(db_description);
        }
         public override string ToString()
        {
            return this.GetType().ToString();
        }
        }
}
