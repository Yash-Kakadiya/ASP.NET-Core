using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;

//public int PatientID { get; set; }
//public string PatientName { get; set; }
//public DateTime DateOfBirth { get; set; }
//public string Gender { get; set; }
//public string Email { get; set; }
//public string Phone { get; set; }
//public string Address { get; set; }
//public string City { get; set; }
//public string State { get; set; }
//public bool IsActive { get; set; }
//public DateTime Created { get; set; }
//public DateTime Modified { get; set; }
//public int UserID { get; set; }

namespace HMS.Controllers
{
    public class PatientController : Controller
    {
        // The PatientController class is a controller in an ASP.NET Core application that handles patient-related actions.


        #region configuration

        //This code is used to inject the IConfiguration service into the PatientController.

        private readonly IConfiguration _configuration; // Private field to hold the injected configuration

        public PatientController(IConfiguration configuration)
        {
            _configuration = configuration; // Assign the injected configuration to the private field
        }

        #endregion


        #region PatientList
        // This action method retrieves a list of patients from the database and returns it to the PatientList view.

        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult PatientList() // This method handles GET requests to the PatientList action.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration using


            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.

            sqlConnection.Open(); // Open the SQL connection to the database.


            SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.


            command.CommandText = "PR_Patient_SelectAll"; // Set the command text to the name of the stored procedure that will be executed.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.

            DataTable table = new DataTable(); // Create a new DataTable object to hold the results of the query.

            table.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            return View(table); // Return the DataTable to the PatientList view.
        }

        #endregion


        #region PatientDelete
        // This action method deletes a patient from the database based on the provided PatientID.

        //[HttpDelete] // This attribute indicates that this method should handle HTTP DELETE requests.
        public IActionResult PatientDelete(int @PatientID) // This method handles DELETE requests to the PatientDelete action, where @PatientID is the ID of the patient to be deleted.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.

            SqlCommand command = sqlConnection.CreateCommand();// Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_Patient_Delete"; // Set the command text to the name of the stored procedure that will be executed to delete the patient.

            command.Parameters.Add("@PatientID", SqlDbType.Int).Value = @PatientID; // Add a parameter to the command for the PatientID, which is the ID of the patient to be deleted.

            command.ExecuteNonQuery(); // Execute the command to delete the patient from the database.

            return RedirectToAction("PatientList"); // Redirect to the PatientList action after the patient is deleted.
        }
        #endregion

        #region PatientAddEdit (GET)
        // This action method retrieves a patient by PatientID for editing or adds a new patient if PatientID is null.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult PatientAddEdit(int? PatientID) // This method handles GET requests to the PatientAddEdit action, where PatientID is an optional parameter.
        {
            // Retrieve the list of users from the database to populate a dropdown for selecting a user associated with the patient.
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

            PatientModel patientModel = new PatientModel(); // Create a new instance of the PatientModel class to hold patient data.

            if (PatientID != null) // Check if PatientID is not null, indicating that we are editing an existing patient.
            {
                string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnection
                using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
                sqlConnection.Open(); // Open the SQL connection to the database.
                using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.

                command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
                command.CommandText = "PR_Patient_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the patient by PatientID.
                command.Parameters.AddWithValue("@PatientID", PatientID); // Add a parameter to the command for the PatientID, which is the ID of the patient to be retrieved.
                using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
                if (reader.Read()) // Check if the SqlDataReader has any rows to read, indicating that a patient with the specified PatientID was found.
                {
                    patientModel.PatientID = Convert.ToInt32(reader["PatientID"]);
                    patientModel.PatientName = reader["PatientName"].ToString();
                    patientModel.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    patientModel.Gender = reader["Gender"].ToString();
                    patientModel.Email = reader["Email"].ToString();
                    patientModel.Phone = reader["Phone"].ToString();
                    patientModel.Address = reader["Address"].ToString();
                    patientModel.City = reader["City"].ToString();
                    patientModel.State = reader["State"].ToString();

                    patientModel.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    patientModel.Created = Convert.ToDateTime(reader["Created"]);
                    patientModel.Modified = Convert.ToDateTime(reader["Modified"]);
                    patientModel.UserID = Convert.ToInt32(reader["UserID"]);
                    // Populate the patientModel properties with the values retrieved from the database.
                }
            }

            // If PatientID is null, we are adding a new patient, so patientModel will remain with default values.
            return View(patientModel); // Return the view with the patientModel to display validation errors.
        }
        #endregion

        #region PatientAddEdit (POST)
        // This action method handles the form submission for adding or editing a patient.
        [HttpPost] // This attribute indicates that this method should handle HTTP POST requests.
        public IActionResult PatientAddEdit(PatientModel patientModel) // This method handles POST requests to the PatientAddEdit action, where patientModel is the model containing patient data submitted from the form.
        {
            // Check if the model state is valid, meaning that all required fields are filled out correctly.
            // If the model state is not valid, we return the view with the patientModel to display validation errors.
            //if (!ModelState.IsValid)
            //{
            //    Console.WriteLine(ModelState.IsValid);
            //    Console.WriteLine(value: patientModel.UserID.GetType());
            //    return View(patientModel); // Return the view with the patientModel to display validation errors.
            //}

            // If the model state is valid, we proceed to add or update the patient in the database.

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.

            // Check if the PatientID is greater than 0, indicating that we are updating an existing patient.
            if (patientModel.PatientID > 0)
            {
                // If PatientID is greater than 0, we are updating an existing patient, so we set the command text to the update stored procedure.

                command.CommandText = "PR_Patient_Update";// Set the command text to the name of the stored procedure that will be executed to update the patient.
                command.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientModel.PatientID; // Add a parameter to the command for the PatientID, which is the ID of the patient to be updated.
            }
            else
            {
                // If PatientID is not greater than 0, we are adding a new patient, so we set the command text to the insert stored procedure.
                command.CommandText = "PR_Patient_Insert"; // Set the command text to the name of the stored procedure that will be executed to insert a new patient.
                // No need to add PatientID parameter for insert, as it will be generated by the database.
            }

            // Add parameters for the patientModel properties to the command.
            command.Parameters.Add("@PatientName", SqlDbType.NVarChar).Value = patientModel.PatientName;
            command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = patientModel.DateOfBirth;
            command.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = patientModel.Gender;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = patientModel.Email;
            command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = patientModel.Phone;
            command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = patientModel.Address;
            command.Parameters.Add("@City", SqlDbType.NVarChar).Value = patientModel.City;
            command.Parameters.Add("@State", SqlDbType.NVarChar).Value = patientModel.State;

            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = patientModel.IsActive;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = patientModel.UserID;

            command.ExecuteNonQuery(); // Execute the command to add or update the patient in the database.

            return RedirectToAction("PatientList"); // Redirect to the PatientList action after the patient is added or updated.
        }
        #endregion

        #region PatientDetail
        // This action method retrieves the details of a patient by PatientID and returns it to the PatientDetail view.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult PatientDetail(int PatientID) // This method handles GET requests to the PatientDetail action, where PatientID is the ID of the patient whose details are to be retrieved.
        {

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_Patient_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the patient by PatientID.
            command.Parameters.AddWithValue("@PatientID", PatientID); // Add a parameter to the command for the PatientID, which is the ID of the patient whose details are to be retrieved.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
            DataTable dt = new DataTable(); // Create a new DataTable object to hold the patient details retrieved from the database.
            dt.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            DataRow row = dt.Rows.Count > 0 ? dt.Rows[0] : null; // Check if the DataTable has any rows, and if so, get the first row; otherwise, set row to null.
            // The DataRow class is part of the System.Data namespace and represents a single row in a DataTable.
            return View(row); // Return the DataRow object to the PatientDetail view for display.
        }
        #endregion

    }
}
