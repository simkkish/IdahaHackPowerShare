
namespace PowerShare.Models
{
    public class user
    {
        protected int _userId;
        protected string _firstName;
        protected string _middleName;
        protected string _lastName;
        protected string _emailAddress;
        protected long _PhoneNumber;
        protected int _karmaPoints;
        protected string _password;



        public user()
        {

        }
        public user(string firstName, string middleName,string lastName, string emailAddress, long phoneNumber, int karmaPoints, string passWord)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            KarmaPoints = karmaPoints;
            Password = passWord;
              

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
           
    }
}