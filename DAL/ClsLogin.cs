using BAL;
using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class ClsLogin:sqlDML
    {
        public CommonProperty.IsSuccess ValidateUsers(Login login)
        {
            try
            {
                string StoreProcedureName = "CHECK_USER_CREDENTIALS";

                SqlParameter[] sqlParameter = {
                    new SqlParameter("USERNAME",login.userName),
                    new SqlParameter("PASSWORD",login.password),
                };
               ClsLogin.GetSingleRecord(StoreProcedureName, sqlParameter, CommandType.StoredProcedure);


                return CommonProperty.IsSuccess.Success;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
