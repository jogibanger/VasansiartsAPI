using System.Collections.Generic;
using System.Web.Http;
using BAL;
using Common;
using System.Net.Http;
using System.Net;
using DAL;
using System;


namespace VasansiartsAPI.Controllers
{
    public class LoginController : ApiController
    {
        
        // GET Api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET Login/values/5
        public string Get(int id)
        {
            return "value";
        }


        //   [Route("login/ValidateUsers")]
        // POST Login/values

        public HttpResponseMessage Post(Login login)
        {
            try
            {
                //if (login != null)
                //{
                //    if (ComonFuction.ValidateStringValue(login.userName)
                //      && ComonFuction.ValidateStringValue(login.password))
                //    {
                //        ClsLogin Obj = new ClsLogin();
                //        string IsValidate = Obj.ValidateUsers(login).ToString();
                //        return Request.CreateErrorResponse(HttpStatusCode.OK, IsValidate);
                //    }
                //    else
                //    {
                //        return Request.CreateErrorResponse(HttpStatusCode.OK, CommonMessage.EmptyNameAndPassword);
                //    }
                //}
                //else
                string MM = "asdfasdf";
                int i = Convert.ToInt32(MM);
                return Request.CreateErrorResponse(HttpStatusCode.OK, CommonMessage.UserNameWrong);
                
            }
            catch (System.Exception ex)
            {
                HandleApplicationException.WriteException(ex);
                throw ex;
            }
        }

        // PUT Login/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE Login/values/5
        public void Delete(int id)
        {
        }
    }
}
