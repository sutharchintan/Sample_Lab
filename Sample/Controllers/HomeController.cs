using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Sample.Data.Model;
using Sample.Service;
namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        private UserService objservice = new UserService();
        public ActionResult Registration()
        {
            return View();
        }


        #region CreateUsers
        [HttpPost]
        public JsonResult CreateUsers()
        {
            UserModel.User data = new UserModel.User();

            data.Role = Convert.ToInt32(Request.Form["UserRole"]); // for register user
            data.UserFirstName = Request.Form["UserFirstName"];
            data.UserLastName = Request.Form["UserLastName"];
            data.UserName = Request.Form["UserName"];
            data.Password = Request.Form["Password"];
            data.MobileNo = Request.Form["CellNo"];
            data.Email = Request.Form["Email"];
            data.Address = Request.Form["Address"];
            data.City = Request.Form["CityName"];
            data.State= Request.Form["StateName"];
            data.Active = true;
            data.CreatedODate = DateTime.Now;
            bool result = objservice.CreateUser(data);
            return Json(result, JsonRequestBehavior.AllowGet);


        }
        #endregion

        #region Login
        public ActionResult Login()
        {

            return View();
        }
        #endregion

        #region LOGIN
        [HttpPost]
        public JsonResult UserLogin()
        {
            UserModel.RequestLogin data = new UserModel.RequestLogin();
            data.UserName = Request.Form["UserName"];
            data.Password = Request.Form["Password"];
            data.Role = Convert.ToInt32(Request.Form["Role"]);
            UserLoginDetails responsedata = objservice.checklogin(data);

            if (responsedata != null && responsedata.UserID > 0)
            {
                #region MyRegion
                try
                {
                    Session["UserID"] = responsedata.UserID;
                    Session["UserName"] = responsedata.UserName;
                    Session["RoleID"] = responsedata.UserRoleID;
                    return Json(responsedata, JsonRequestBehavior.AllowGet);
                }
                catch
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                #endregion


            }
            else
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }

        }
        #endregion



        #region Login
        public ActionResult Home()
        {
            ViewBag.UserName = Session["UserName"];
            return View();
        }
        #endregion
    }
}