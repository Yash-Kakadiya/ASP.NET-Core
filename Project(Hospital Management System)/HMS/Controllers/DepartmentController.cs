using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;

//public int DepartmentID { get; set; }
//public string DepartmentName { get; set; }
//public string Description { get; set; }
//public bool IsActive { get; set; }
//public DateTime Created { get; set; }
//public DateTime Modified { get; set; }
//public int UserID { get; set; }

namespace HMS.Controllers
{
    public class DepartmentController : Controller
    {
        // The DepartmentController class is a controller in an ASP.NET Core application that handles department-related actions.


        #region configuration

        //This code is used to inject the IConfiguration service into the DepartmentController.

        private readonly IConfiguration _configuration; // Private field to hold the injected configuration

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration; // Assign the injected configuration to the private field
        }

        #endregion


        #region DepartmentList
        // This action method retrieves a list of departments from the database and returns it to the DepartmentList view.

        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult DepartmentList() // This method handles GET requests to the DepartmentList action.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration using


            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.

            sqlConnection.Open(); // Open the SQL connection to the database.


            SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.


            command.CommandText = "PR_Department_SelectAll"; // Set the command text to the name of the stored procedure that will be executed.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.

            DataTable table = new DataTable(); // Create a new DataTable object to hold the results of the query.

            table.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            return View(table); // Return the DataTable to the DepartmentList view.
        }

        #endregion


        #region DepartmentDelete
        // This action method deletes a department from the database based on the provided DepartmentID.

        //[HttpDelete] // This attribute indicates that this method should handle HTTP DELETE requests.
        public IActionResult DepartmentDelete(int @DepartmentID) // This method handles DELETE requests to the DepartmentDelete action, where @DepartmentID is the ID of the department to be deleted.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.

            SqlCommand command = sqlConnection.CreateCommand();// Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_Department_Delete"; // Set the command text to the name of the stored procedure that will be executed to delete the department.

            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = @DepartmentID; // Add a parameter to the command for the DepartmentID, which is the ID of the department to be deleted.

            command.ExecuteNonQuery(); // Execute the command to delete the department from the database.

            return RedirectToAction("DepartmentList"); // Redirect to the DepartmentList action after the department is deleted.
        }
        #endregion

        #region DepartmentAddEdit (GET)
        // This action method retrieves a department by DepartmentID for editing or adds a new department if DepartmentID is null.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult DepartmentAddEdit(int? DepartmentID) // This method handles GET requests to the DepartmentAddEdit action, where DepartmentID is an optional parameter.
        {
            // Retrieve the list of users from the database to populate a dropdown for selecting a user associated with the department.
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString");
            using SqlConnection sqlConnectionForUser = new SqlConnection(ConnectionString);
            sqlConnectionForUser.Open();
            using SqlCommand commandForUser = sqlConnectionForUser.CreateCommand();
            commandForUser.CommandType = CommandType.StoredProcedure;
            commandForUser.CommandText = "PR_User_SelectAll";
            using SqlDataReader readerForUser = commandForUser.ExecuteReader();

            List<UserModel> userList = new List<UserModel>();
            while (readerForUser.Read())
            {
                userList.Add(
                    new UserModel()
                    {
                        UserID = Convert.ToInt32(readerForUser["UserID"]),
                        UserName = readerForUser["UserName"].ToString(),
                    });
            }
            ViewBag.UserList = userList; // Populate the ViewBag with a SelectList of users for dropdown selection in the view.

            DepartmentModel departmentModel = new DepartmentModel(); // Create a new instance of the DepartmentModel class to hold department data.

            if (DepartmentID != null) // Check if DepartmentID is not null, indicating that we are editing an existing department.
            {
                string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnection
                using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
                sqlConnection.Open(); // Open the SQL connection to the database.
                using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.

                command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
                command.CommandText = "PR_Department_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the department by DepartmentID.
                command.Parameters.AddWithValue("@DepartmentID", DepartmentID); // Add a parameter to the command for the DepartmentID, which is the ID of the department to be retrieved.
                using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
                if (reader.Read()) // Check if the SqlDataReader has any rows to read, indicating that a department with the specified DepartmentID was found.
                {
                    Console.WriteLine(departmentModel.UserID);
                    departmentModel.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                    departmentModel.DepartmentName = reader["DepartmentName"].ToString();
                    departmentModel.Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty; // Handle null values for Description.
                    departmentModel.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    departmentModel.Created = Convert.ToDateTime(reader["Created"]);
                    departmentModel.Modified = Convert.ToDateTime(reader["Modified"]);
                    departmentModel.UserID = Convert.ToInt32(reader["UserID"]);
                    // Populate the departmentModel properties with the values retrieved from the database.
                }
            }

            // If DepartmentID is null, we are adding a new department, so departmentModel will remain with default values.
            return View(departmentModel); // Return the view with the departmentModel to display validation errors.
        }
        #endregion

        #region DepartmentAddEdit (POST)
        // This action method handles the form submission for adding or editing a department.
        [HttpPost] // This attribute indicates that this method should handle HTTP POST requests.
        public IActionResult DepartmentAddEdit(DepartmentModel departmentModel) // This method handles POST requests to the DepartmentAddEdit action, where departmentModel is the model containing department data submitted from the form.
        {
            // Check if the model state is valid, meaning that all required fields are filled out correctly.
            // If the model state is not valid, we return the view with the departmentModel to display validation errors.
            //if (!ModelState.IsValid)
            //{
            //    Console.WriteLine(ModelState.IsValid);
            //    Console.WriteLine(value: departmentModel.UserID.GetType());
            //    return View(departmentModel); // Return the view with the departmentModel to display validation errors.
            //}

            // If the model state is valid, we proceed to add or update the department in the database.

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.

            // Check if the DepartmentID is greater than 0, indicating that we are updating an existing department.
            if (departmentModel.DepartmentID > 0)
            {
                // If DepartmentID is greater than 0, we are updating an existing department, so we set the command text to the update stored procedure.

                command.CommandText = "PR_Department_Update";// Set the command text to the name of the stored procedure that will be executed to update the department.
                command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentModel.DepartmentID; // Add a parameter to the command for the DepartmentID, which is the ID of the department to be updated.
            }
            else
            {
                // If DepartmentID is not greater than 0, we are adding a new department, so we set the command text to the insert stored procedure.
                command.CommandText = "PR_Department_Insert"; // Set the command text to the name of the stored procedure that will be executed to insert a new department.
                // No need to add DepartmentID parameter for insert, as it will be generated by the database.
            }

            // Add parameters for the departmentModel properties to the command.
            command.Parameters.Add("@DepartmentName", SqlDbType.NVarChar).Value = departmentModel.DepartmentName;
            command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(departmentModel.Description) ? (object)DBNull.Value : departmentModel.Description; // Handle null or empty Description.
            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = departmentModel.IsActive;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = departmentModel.UserID;

            command.ExecuteNonQuery(); // Execute the command to add or update the department in the database.

            return RedirectToAction("DepartmentList"); // Redirect to the DepartmentList action after the department is added or updated.
        }
        #endregion

        #region DepartmentDetail
        // This action method retrieves the details of a department by DepartmentID and returns it to the DepartmentDetail view.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult DepartmentDetail(int DepartmentID) // This method handles GET requests to the DepartmentDetail action, where DepartmentID is the ID of the department whose details are to be retrieved.
        {

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_Department_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the department by DepartmentID.
            command.Parameters.AddWithValue("@DepartmentID", DepartmentID); // Add a parameter to the command for the DepartmentID, which is the ID of the department whose details are to be retrieved.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
            DataTable dt = new DataTable(); // Create a new DataTable object to hold the department details retrieved from the database.
            dt.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            DataRow row = dt.Rows.Count > 0 ? dt.Rows[0] : null; // Check if the DataTable has any rows, and if so, get the first row; otherwise, set row to null.
            // The DataRow class is part of the System.Data namespace and represents a single row in a DataTable.
            return View(row); // Return the DataRow object to the DepartmentDetail view for display.
        }
        #endregion

    }
}
