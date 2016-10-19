using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class CommonMessage
    {
        private static string PleaseTryAgain = "Please Try Again Or Contact To Admin";
        public static string UserNamePasswordWrong = string.Format("User Name and Password Wrong {0}", PleaseTryAgain);
        public static string UserNameWrong = string.Format("User Name Wrong {0}", PleaseTryAgain);
        public static string PasswordWrong = string.Format("Your Password Wrong {0}", PleaseTryAgain);
        public static string ExceedAttempts = string.Format("You have Exceed Login Attempts {0}", PleaseTryAgain);
        public static string TempraryBlock = string.Format("Your Accounts Temprary Block {0}", PleaseTryAgain);
        public static string AccountBlock = string.Format("Your Accouts Block {0}", PleaseTryAgain);
        public static string EmptyNameAndPassword = string.Format("No allowed Blank User Name and Pass word {0} ", PleaseTryAgain);
    }
}
