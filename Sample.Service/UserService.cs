using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Data.Model;
using Sample.Data.DataModel;
using System.Data.SqlClient;
using System.Data;
namespace Sample.Service
{
    public class UserService
    {
        #region CreateUser
        public bool CreateUser(UserModel.User data)
        {
            // HttpContext.Current.Session["UserID"] = "";

            try
            {
                SqlCommand cmdGet = new SqlCommand();
                BaseSqlManager objBaseSqlManager = new BaseSqlManager();
                cmdGet.CommandType = CommandType.StoredProcedure;
                cmdGet.CommandText = "CreateUser";
                cmdGet.Parameters.AddWithValue("@FirstName", data.UserFirstName);
                cmdGet.Parameters.AddWithValue("@LastName", data.UserLastName);
                cmdGet.Parameters.AddWithValue("@Address", data.Address);
                cmdGet.Parameters.AddWithValue("@MobileNo", data.MobileNo);
                cmdGet.Parameters.AddWithValue("@City", data.City);
                cmdGet.Parameters.AddWithValue("@State", data.State);
                cmdGet.Parameters.AddWithValue("@Email", data.Email);
                cmdGet.Parameters.AddWithValue("@IsActive", data.Active);
                cmdGet.Parameters.AddWithValue("@UserName", data.UserName);
                cmdGet.Parameters.AddWithValue("@Password", data.Password);
                cmdGet.Parameters.AddWithValue("@Role", data.Role);
                cmdGet.Parameters.AddWithValue("@CreatedDate", data.CreatedODate);
                objBaseSqlManager.ExecuteNonQuery(cmdGet);
                objBaseSqlManager.ForceCloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion


        #region checklogin
        public UserLoginDetails checklogin(UserModel.RequestLogin data)
        {
            SqlCommand cmdGet = new SqlCommand();
            BaseSqlManager objBaseSqlManager = new BaseSqlManager();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "Userlogin";
            cmdGet.Parameters.AddWithValue("@username", data.UserName.ToString());
            cmdGet.Parameters.AddWithValue("@password", data.Password.ToString());
            cmdGet.Parameters.AddWithValue("@Role", data.Role);
            SqlDataReader dr = objBaseSqlManager.ExecuteDataReader(cmdGet);
            UserLoginDetails objuser = new UserLoginDetails();
            while (dr.Read())
            {
                objuser.UserID = objBaseSqlManager.GetInt64(dr, "UserID");
                objuser.UserName = objBaseSqlManager.GetTextValue(dr, "UserFullName");
                objuser.UserRoleID = objBaseSqlManager.GetInt64(dr, "Role");

            }
            dr.Close();
            objBaseSqlManager.ForceCloseConnection();

            return objuser;
        }
        #endregion
    }
}
