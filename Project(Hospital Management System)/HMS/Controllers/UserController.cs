using HMS.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HMS.Controllers
{
    public class UserController : Controller
    {
        #region configuration
        private IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region UserList
        public IActionResult UserList()
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString");
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_User_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
        #endregion

        #region UserDelete
        public IActionResult UserDelete(int @UserID)
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString");
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_User_Delete";
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = @UserID;
            command.ExecuteNonQuery();
            return RedirectToAction("UserList");
        }
        #endregion

        //        CREATE TABLE[User]
        //(
        //    UserID INT PRIMARY KEY IDENTITY(1,1),
        //    UserName NVARCHAR(100) NOT NULL,
        //    Password NVARCHAR(100) NOT NULL,
        //    Email NVARCHAR(100) NOT NULL,
        //    MobileNo NVARCHAR(100) NOT NULL,
        //    IsActive BIT NOT NULL DEFAULT 1,
        //    Created DATETIME DEFAULT GETDATE(),
        //    Modified DATETIME NOT NULL
        //);
        #region UserAddEdit (GET)
        public IActionResult UserAddEdit(int? UserID)
        {
            UserModel userModel = new UserModel();

            if (UserID != null)
            {
                string connectionString = _configuration.GetConnectionString("MyConnectionString");
                using SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_User_SelectByID";
                cmd.Parameters.AddWithValue("@UserID", UserID);
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userModel.UserID = Convert.ToInt32(reader["UserID"]);
                    userModel.UserName = reader["UserName"].ToString();
                    userModel.Password = reader["Password"].ToString();
                    userModel.Email = reader["Email"].ToString();
                    userModel.MobileNo = reader["MobileNo"].ToString();
                    userModel.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    userModel.Created = Convert.ToDateTime(reader["Created"]);
                    userModel.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }

            return View(userModel);
        }
        #endregion

        #region UserAddEdit (POST)
        [HttpPost]
        public IActionResult UserAddEdit(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            string connectionString = _configuration.GetConnectionString("MyConnectionString");
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;

            if (userModel.UserID > 0)
            {
                command.CommandText = "PR_User_Update";
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userModel.UserID;
            }
            else
            {
                command.CommandText = "PR_User_Insert";
            }

            command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userModel.UserName;
            command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = userModel.Password;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = userModel.Email;
            command.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = userModel.MobileNo;
            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = userModel.IsActive;

            command.ExecuteNonQuery();


            return RedirectToAction("UserList");
        }
        #endregion

        #region UserDetail
        public IActionResult UserDetail(int UserID)
        {
            DataTable dt = new DataTable();
            string connectionString = _configuration.GetConnectionString("MyConnectionString");
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_User_SelectByID";
            cmd.Parameters.AddWithValue("@UserID", UserID);
            using SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);

            DataRow row = dt.Rows.Count > 0 ? dt.Rows[0] : null;
            return View(row);
        }
        #endregion
    }
}