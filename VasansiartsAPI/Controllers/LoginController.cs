using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BAL;
using Common;
using System.Net.Http;
using System.Net;
using DAL;

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

        public HttpResponseMessage Post(BAL.BALLogin login)
        {
            if (login != null)
            {
                if (ComonFuction.ValidateStringValue(login.userName)
                  && ComonFuction.ValidateStringValue(login.password))
                {
                    ClsLogin Obj = new ClsLogin();
                    string SK = Obj.Validate();
                    return Request.CreateErrorResponse(HttpStatusCode.OK, SK );
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.OK, CommonMessage.EmptyNameAndPassword);
                }
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.OK, CommonMessage.UserNameWrong);
           



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
