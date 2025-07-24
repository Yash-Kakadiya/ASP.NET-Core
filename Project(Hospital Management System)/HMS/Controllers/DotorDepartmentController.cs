using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;

//public int DoctorDepartmentID { get; set; }
//public int DoctorID { get; set; }
//public int DepartmentID { get; set; }
//public DateTime Created { get; set; }
//public DateTime Modified { get; set; }
//public int UserID { get; set; }

namespace HMS.Controllers
{
    public class DoctorDepartmentController : Controller
    {
        // The DoctorDepartmentController class is a controller in an ASP.NET Core application that handles dotordepartment-related actions.


        #region configuration

        //This code is used to inject the IConfiguration service into the DoctorDepartmentController.

        private readonly IConfiguration _configuration; // Private field to hold the injected configuration

        public DoctorDepartmentController(IConfiguration configuration)
        {
            _configuration = configuration; // Assign the injected configuration to the private field
        }

        #endregion


        #region DoctorDepartmentList
        // This action method retrieves a list of dotorDepartments from the database and returns it to the DoctorDepartmentList view.

        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult DoctorDepartmentList() // This method handles GET requests to the DoctorDepartmentList action.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration using


            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.

            sqlConnection.Open(); // Open the SQL connection to the database.


            SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.


            command.CommandText = "PR_DoctorDepartment_SelectAll"; // Set the command text to the name of the stored procedure that will be executed.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.

            DataTable table = new DataTable(); // Create a new DataTable object to hold the results of the query.

            table.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            return View(table); // Return the DataTable to the DoctorDepartmentList view.
        }

        #endregion


        #region DoctorDepartmentDelete
        // This action method deletes a dotordepartment from the database based on the provided DoctorDepartmentID.

        //[HttpDelete] // This attribute indicates that this method should handle HTTP DELETE requests.
        public IActionResult DoctorDepartmentDelete(int @DoctorDepartmentID) // This method handles DELETE requests to the DoctorDepartmentDelete action, where @DoctorDepartmentID is the ID of the dotordepartment to be deleted.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.

            SqlCommand command = sqlConnection.CreateCommand();// Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_DoctorDepartment_Delete"; // Set the command text to the name of the stored procedure that will be executed to delete the dotordepartment.

            command.Parameters.Add("@DoctorDepartmentID", SqlDbType.Int).Value = @DoctorDepartmentID; // Add a parameter to the command for the DoctorDepartmentID, which is the ID of the dotordepartment to be deleted.

            command.ExecuteNonQuery(); // Execute the command to delete the dotordepartment from the database.

            return RedirectToAction("DoctorDepartmentList"); // Redirect to the DoctorDepartmentList action after the dotordepartment is deleted.
        }
        #endregion

        #region DoctorDepartmentAddEdit (GET)
        // This action method retrieves a dotordepartment by DoctorDepartmentID for editing or adds a new dotordepartment if DoctorDepartmentID is null.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult DoctorDepartmentAddEdit(int? DoctorDepartmentID) // This method handles GET requests to the DoctorDepartmentAddEdit action, where DoctorDepartmentID is an optional parameter.
        {
            // Retrieve the list of users from the database to populate a dropdown for selecting a user associated with the dotordepartment.

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".

            // Retrieve the list of users, patients, doctors from the database to populate a dropdown for selecting a user, patient, doctosd associated with the dotordepartment.


            // Doctor List
            List<DoctorModel> doctorList = new List<DoctorModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PR_Doctor_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            doctorList.Add(new DoctorModel
                            {
                                DoctorID = Convert.ToInt32(reader["DoctorID"]),
                                DoctorName = reader["DoctorName"].ToString()
                            });
                        }
                    }
                }
            }
            ViewBag.DoctorList = doctorList;

            // Department List
            List<DepartmentModel> patientList = new List<DepartmentModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PR_Department_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patientList.Add(new DepartmentModel
                            {
                                DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                                DepartmentName = reader["DepartmentName"].ToString()
                            });
                        }
                    }
                }
            }
            ViewBag.DepartmentList = patientList;

            // User List
            List<UserModel> userList = new List<UserModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PR_User_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userList.Add(new UserModel
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                UserName = reader["UserName"].ToString()
                            });
                        }
                    }
                }
            }
            ViewBag.UserList = userList;

            DoctorDepartmentModel dotorDepartmentModel = new DoctorDepartmentModel(); // Create a new instance of the DoctorDepartmentModel class to hold dotordepartment data.

            if (DoctorDepartmentID != null) // Check if DoctorDepartmentID is not null, indicating that we are editing an existing dotordepartment.
            {
                using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
                sqlConnection.Open(); // Open the SQL connection to the database.
                using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.

                command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
                command.CommandText = "PR_DoctorDepartment_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the dotordepartment by DoctorDepartmentID.
                command.Parameters.AddWithValue("@DoctorDepartmentID", DoctorDepartmentID); // Add a parameter to the command for the DoctorDepartmentID, which is the ID of the dotordepartment to be retrieved.
                using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
                if (reader.Read()) // Check if the SqlDataReader has any rows to read, indicating that a dotordepartment with the specified DoctorDepartmentID was found.
                {
                    dotorDepartmentModel.DoctorDepartmentID = Convert.ToInt32(reader["DoctorDepartmentID"]);
                    dotorDepartmentModel.DoctorID = Convert.ToInt32(reader["DoctorID"]);
                    dotorDepartmentModel.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);

                    dotorDepartmentModel.Created = Convert.ToDateTime(reader["Created"]);
                    dotorDepartmentModel.Modified = Convert.ToDateTime(reader["Modified"]);
                    dotorDepartmentModel.UserID = Convert.ToInt32(reader["UserID"]);
                    // Populate the dotorDepartmentModel properties with the values retrieved from the database.
                }
            }

            // If DoctorDepartmentID is null, we are adding a new dotordepartment, so dotorDepartmentModel will remain with default values.
            return View(dotorDepartmentModel); // Return the view with the dotorDepartmentModel to display validation errors.
        }
        #endregion

        #region DoctorDepartmentAddEdit (POST)
        // This action method handles the form submission for adding or editing a dotordepartment.
        [HttpPost] // This attribute indicates that this method should handle HTTP POST requests.
        public IActionResult DoctorDepartmentAddEdit(DoctorDepartmentModel dotorDepartmentModel) // This method handles POST requests to the DoctorDepartmentAddEdit action, where dotorDepartmentModel is the model containing dotordepartment data submitted from the form.
        {
            // Check if the model state is valid, meaning that all required fields are filled out correctly.
            // If the model state is not valid, we return the view with the dotorDepartmentModel to display validation errors.
            //if (!ModelState.IsValid)
            //{
            //    Console.WriteLine(ModelState.IsValid);
            //    Console.WriteLine(value: dotorDepartmentModel.UserID.GetType());
            //    return View(dotorDepartmentModel); // Return the view with the dotorDepartmentModel to display validation errors.
            //}

            // If the model state is valid, we proceed to add or update the dotordepartment in the database.

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.

            // Check if the DoctorDepartmentID is greater than 0, indicating that we are updating an existing dotordepartment.
            if (dotorDepartmentModel.DoctorDepartmentID > 0)
            {
                // If DoctorDepartmentID is greater than 0, we are updating an existing dotordepartment, so we set the command text to the update stored procedure.

                command.CommandText = "PR_DoctorDepartment_Update";// Set the command text to the name of the stored procedure that will be executed to update the dotordepartment.
                command.Parameters.Add("@DoctorDepartmentID", SqlDbType.Int).Value = dotorDepartmentModel.DoctorDepartmentID; // Add a parameter to the command for the DoctorDepartmentID, which is the ID of the dotordepartment to be updated.
            }
            else
            {
                // If DoctorDepartmentID is not greater than 0, we are adding a new dotordepartment, so we set the command text to the insert stored procedure.
                command.CommandText = "PR_DoctorDepartment_Insert"; // Set the command text to the name of the stored procedure that will be executed to insert a new dotordepartment.
                // No need to add DoctorDepartmentID parameter for insert, as it will be generated by the database.
            }

            // Add parameters for the dotorDepartmentModel properties to the command.
            command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = dotorDepartmentModel.DoctorID; // Add a parameter for the DoctorID, which is the ID of the doctor associated with the dotordepartment.
            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = dotorDepartmentModel.DepartmentID; // Add a parameter for the DepartmentID, which is the ID of the patient associated with the dotordepartment.
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = dotorDepartmentModel.UserID;

            command.ExecuteNonQuery(); // Execute the command to add or update the dotordepartment in the database.

            return RedirectToAction("DoctorDepartmentList"); // Redirect to the DoctorDepartmentList action after the dotordepartment is added or updated.
        }
        #endregion

        #region DoctorDepartmentDetail
        // This action method retrieves the details of a dotordepartment by DoctorDepartmentID and returns it to the DoctorDepartmentDetail view.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult DoctorDepartmentDetail(int DoctorDepartmentID) // This method handles GET requests to the DoctorDepartmentDetail action, where DoctorDepartmentID is the ID of the dotordepartment whose details are to be retrieved.
        {

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_DoctorDepartment_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the dotordepartment by DoctorDepartmentID.
            command.Parameters.AddWithValue("@DoctorDepartmentID", DoctorDepartmentID); // Add a parameter to the command for the DoctorDepartmentID, which is the ID of the dotordepartment whose details are to be retrieved.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
            DataTable dt = new DataTable(); // Create a new DataTable object to hold the dotordepartment details retrieved from the database.
            dt.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            DataRow row = dt.Rows.Count > 0 ? dt.Rows[0] : null; // Check if the DataTable has any rows, and if so, get the first row; otherwise, set row to null.
            // The DataRow class is part of the System.Data namespace and represents a single row in a DataTable.
            return View(row); // Return the DataRow object to the DoctorDepartmentDetail view for display.
        }
        #endregion

    }
}
