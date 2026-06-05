using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Utilities
{
    public class Configuration
    {

        private static string _connectionString;
        private static string _emailconnectionString;
        private static int _companyID;
        private static int _userID;
        private static int _languageID;
        private static string _istaAPILink;
        private static string _zatcaAPILink;
        private static string _XInstaAuth;
        private static string _hospital_name;
        private static string _request_handler_key;
        private static int _expires_in;
        public static string ConnectionString { get => _connectionString; set => _connectionString = value; }

        public static string emailDbConnection { get => _emailconnectionString; set => _emailconnectionString = value; }
        public static int CompanyID { get => _companyID; set => _companyID = value; }
        public static int UserID { get => _userID; set => _userID = value; }
        public static int LanguageID { get => _languageID; set => _languageID = value; }

        public static string InstaAPILink { get => _istaAPILink; set => _istaAPILink = value; }

        public static string zatcaAPILink { get => _zatcaAPILink; set => _zatcaAPILink = value; }
        public static string XInstaAuth { get => _XInstaAuth; set => _XInstaAuth = value; }

        public static string hospital_name { get => _hospital_name; set => _hospital_name = value; }
        public static string request_handler_key { get => _request_handler_key; set => _request_handler_key = value; }
        public static int expires_in { get => _expires_in; set => _expires_in = value; }
    }
}
