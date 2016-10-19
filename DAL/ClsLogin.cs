using BAL;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsLogin
    {
        public string ValidateUsers(Login login)
        {
             ComonFuction.Encrypt(login.userName,"Vasansiarts");

             ComonFuction.Encrypt(login.password, "Vasansiarts");
           
            
             return "sucess";
        }
    }
}
