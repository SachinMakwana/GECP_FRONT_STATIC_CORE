using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GECP_Front_End_Static
{
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

