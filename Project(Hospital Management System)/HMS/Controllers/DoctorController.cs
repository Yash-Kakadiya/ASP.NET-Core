using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;

//public int DoctorID { get; set; }
//public string Name { get; set; }
//public string Phone { get; set; }
//public string Email { get; set; }
//public string Qualification { get; set; }
//public string Specialization { get; set; }
//public bool IsActive { get; set; }
//public DateTime Created { get; set; }
//public DateTime Modified { get; set; }
//public int UserID { get; set; }

namespace HMS.Controllers
{
    public class DoctorController : Controller
    {
        // The DoctorController class is a controller in an ASP.NET Core application that handles doctor-related actions.


        #region configuration

        //This code is used to inject the IConfiguration service into the DoctorController.

        private readonly IConfiguration _configuration; // Private field to hold the injected configuration

        public DoctorController(IConfiguration configuration)
        {
            _configuration = configuration; // Assign the injected configuration to the private field
        }

        #endregion


        #region DoctorList
        // This action method retrieves a list of doctors from the database and returns it to the DoctorList view.

        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult DoctorList() // This method handles GET requests to the DoctorList action.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration using


            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.

            sqlConnection.Open(); // Open the SQL connection to the database.


            SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.


            command.CommandText = "PR_Doctor_SelectAll"; // Set the command text to the name of the stored procedure that will be executed.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.

            DataTable table = new DataTable(); // Create a new DataTable object to hold the results of the query.

            table.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            return View(table); // Return the DataTable to the DoctorList view.
        }

        #endregion


        #region DoctorDelete
        // This action method deletes a doctor from the database based on the provided DoctorID.

        //[HttpDelete] // This attribute indicates that this method should handle HTTP DELETE requests.
        public IActionResult DoctorDelete(int @DoctorID) // This method handles DELETE requests to the DoctorDelete action, where @DoctorID is the ID of the doctor to be deleted.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.

            SqlCommand command = sqlConnection.CreateCommand();// Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_Doctor_Delete"; // Set the command text to the name of the stored procedure that will be executed to delete the doctor.

            command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = @DoctorID; // Add a parameter to the command for the DoctorID, which is the ID of the doctor to be deleted.

            command.ExecuteNonQuery(); // Execute the command to delete the doctor from the database.

            return RedirectToAction("DoctorList"); // Redirect to the DoctorList action after the doctor is deleted.
        }
        #endregion

        #region DoctorAddEdit (GET)
        // This action method retrieves a doctor by DoctorID for editing or adds a new doctor if DoctorID is null.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult DoctorAddEdit(int? DoctorID) // This method handles GET requests to the DoctorAddEdit action, where DoctorID is an optional parameter.
        {
            // Retrieve the list of users from the database to populate a dropdown for selecting a user associated with the doctor.
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

            DoctorModel doctorModel = new DoctorModel(); // Create a new instance of the DoctorModel class to hold doctor data.

            if (DoctorID != null) // Check if DoctorID is not null, indicating that we are editing an existing doctor.
            {
                string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnection
                using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
                sqlConnection.Open(); // Open the SQL connection to the database.
                using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.

                command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
                command.CommandText = "PR_Doctor_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the doctor by DoctorID.
                command.Parameters.AddWithValue("@DoctorID", DoctorID); // Add a parameter to the command for the DoctorID, which is the ID of the doctor to be retrieved.
                using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
                if (reader.Read()) // Check if the SqlDataReader has any rows to read, indicating that a doctor with the specified DoctorID was found.
                {
                    doctorModel.DoctorID = Convert.ToInt32(reader["DoctorID"]);
                    doctorModel.DoctorName = reader["DoctorName"].ToString();
                    doctorModel.Phone = reader["Phone"].ToString();
                    doctorModel.Email = reader["Email"].ToString();
                    doctorModel.Qualification = reader["Qualification"].ToString();
                    doctorModel.Specialization = reader["Specialization"].ToString();
                    doctorModel.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    doctorModel.Created = Convert.ToDateTime(reader["Created"]);
                    doctorModel.Modified = Convert.ToDateTime(reader["Modified"]);
                    doctorModel.UserID = Convert.ToInt32(reader["UserID"]);
                    // Populate the doctorModel properties with the values retrieved from the database.
                }
            }

            // If DoctorID is null, we are adding a new doctor, so doctorModel will remain with default values.
            return View(doctorModel); // Return the view with the doctorModel to display validation errors.
        }
        #endregion

        #region DoctorAddEdit (POST)
        // This action method handles the form submission for adding or editing a doctor.
        [HttpPost] // This attribute indicates that this method should handle HTTP POST requests.
        public IActionResult DoctorAddEdit(DoctorModel doctorModel) // This method handles POST requests to the DoctorAddEdit action, where doctorModel is the model containing doctor data submitted from the form.
        {
            // Check if the model state is valid, meaning that all required fields are filled out correctly.
            // If the model state is not valid, we return the view with the doctorModel to display validation errors.
            //if (!ModelState.IsValid)
            //{
            //    Console.WriteLine(ModelState.IsValid);
            //    Console.WriteLine(value: doctorModel.UserID.GetType());
            //    return View(doctorModel); // Return the view with the doctorModel to display validation errors.
            //}

            // If the model state is valid, we proceed to add or update the doctor in the database.

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.

            // Check if the DoctorID is greater than 0, indicating that we are updating an existing doctor.
            if (doctorModel.DoctorID > 0)
            {
                // If DoctorID is greater than 0, we are updating an existing doctor, so we set the command text to the update stored procedure.

                command.CommandText = "PR_Doctor_Update";// Set the command text to the name of the stored procedure that will be executed to update the doctor.
                command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorModel.DoctorID; // Add a parameter to the command for the DoctorID, which is the ID of the doctor to be updated.
            }
            else
            {
                // If DoctorID is not greater than 0, we are adding a new doctor, so we set the command text to the insert stored procedure.
                command.CommandText = "PR_Doctor_Insert"; // Set the command text to the name of the stored procedure that will be executed to insert a new doctor.
                // No need to add DoctorID parameter for insert, as it will be generated by the database.
            }

            // Add parameters for the doctorModel properties to the command.
            command.Parameters.Add("@DoctorName", SqlDbType.NVarChar).Value = doctorModel.DoctorName;
            command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = doctorModel.Phone;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = doctorModel.Email;
            command.Parameters.Add("@Qualification", SqlDbType.NVarChar).Value = doctorModel.Qualification;
            command.Parameters.Add("@Specialization", SqlDbType.NVarChar).Value = doctorModel.Specialization;
            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = doctorModel.IsActive;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = doctorModel.UserID;

            command.ExecuteNonQuery(); // Execute the command to add or update the doctor in the database.

            return RedirectToAction("DoctorList"); // Redirect to the DoctorList action after the doctor is added or updated.
        }
        #endregion

        #region DoctorDetail
        // This action method retrieves the details of a doctor by DoctorID and returns it to the DoctorDetail view.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult DoctorDetail(int DoctorID) // This method handles GET requests to the DoctorDetail action, where DoctorID is the ID of the doctor whose details are to be retrieved.
        {

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_Doctor_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the doctor by DoctorID.
            command.Parameters.AddWithValue("@DoctorID", DoctorID); // Add a parameter to the command for the DoctorID, which is the ID of the doctor whose details are to be retrieved.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
            DataTable dt = new DataTable(); // Create a new DataTable object to hold the doctor details retrieved from the database.
            dt.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            DataRow row = dt.Rows.Count > 0 ? dt.Rows[0] : null; // Check if the DataTable has any rows, and if so, get the first row; otherwise, set row to null.
            // The DataRow class is part of the System.Data namespace and represents a single row in a DataTable.
            return View(row); // Return the DataRow object to the DoctorDetail view for display.
        }
        #endregion

    }
}
