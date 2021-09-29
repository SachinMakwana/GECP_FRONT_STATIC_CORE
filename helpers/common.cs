using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GECP_Front_End_Static
{
    public class Settings
    {
        public string _host;
        public string _from;
        public string _username;
        public string _password;
        public string _port;
        public string _alias;
        public Settings(IConfiguration iConfiguration)
        {
          
            var smtpSection = iConfiguration.GetSection("SMTP");
            if (smtpSection != null)
            {
                _host = smtpSection.GetSection("Host").Value;
                _from = smtpSection.GetSection("From").Value;
                _port = smtpSection.GetSection("Port").Value;
                _username = smtpSection.GetSection("UserName").Value;
                _password = smtpSection.GetSection("Passowrd").Value;
                _alias = smtpSection.GetSection("Alias").Value;
            }
        }

        public string GetHost()
        {
            return _host;
        }
        public string GetFromID()
        {
            return _from;
        }
        public string GetPort()
        {
            return _port;
        }
        public string GetUserName()
        {
            return _username;
        }
        public string GetPassword()
        {
            return _password;
        }

        public string GetAlias()
        {
            return _alias;
        }
    }
    public static class common
    {
        public static string GetEmailByDeptID(int id)
        {
            string email = string.Empty;
            switch (id)
            {
                case 1:
                    email = "djvaria@gmail.com";
                    break;
                case 2:
                    email = "dkpatel09@gmail.com";
                    break;
                case 3:
                    break;
                case 4:
                    email = "hbjethva@gmail.com";
                    break;
                case 5:
                    email = "profgap09@gmail.com";
                    break;
                case 6:
                    email = "sdjoshi_74@gmail.com";
                    break;
                case 7:
                    email = "nareshcchavda@gmail.com";
                    break;
                case 8:
                    email = "dkpatel09@gmail.com";
                    break;
                case 9:
                    email = "djvaria@gmail.com";
                    break;
                case 10:
                    email = "principalgecpatan@gmail.com";
                    break;
                case 11:
                    email = "nareshcchavda@gmail.com";
                    break;
                default:
                    break;
            }
            return email;
        }
    }
}

