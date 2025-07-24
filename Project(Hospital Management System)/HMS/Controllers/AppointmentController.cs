using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;

//public int AppointmentID { get; set; }
//public int AppointmentID { get; set; }
//public int PatientID { get; set; }
//public DateTime AppointmentDate { get; set; }
//public string AppointmentStatus { get; set; }
//public string Description { get; set; }
//public string SpecialRemarks { get; set; }
//public DateTime Created { get; set; }
//public DateTime Modified { get; set; }
//public int UserID { get; set; }
//public decimal? TotalConsultedAmount { get; set; }

namespace HMS.Controllers
{
    public class AppointmentController : Controller
    {
        // The AppointmentController class is a controller in an ASP.NET Core application that handles appointment-related actions.


        #region configuration

        //This code is used to inject the IConfiguration service into the AppointmentController.

        private readonly IConfiguration _configuration; // Private field to hold the injected configuration

        public AppointmentController(IConfiguration configuration)
        {
            _configuration = configuration; // Assign the injected configuration to the private field
        }

        #endregion


        #region AppointmentList
        // This action method retrieves a list of appointments from the database and returns it to the AppointmentList view.

        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult AppointmentList() // This method handles GET requests to the AppointmentList action.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration using


            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.

            sqlConnection.Open(); // Open the SQL connection to the database.


            SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.


            command.CommandText = "PR_Appointment_SelectAll"; // Set the command text to the name of the stored procedure that will be executed.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.

            DataTable table = new DataTable(); // Create a new DataTable object to hold the results of the query.

            table.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            return View(table); // Return the DataTable to the AppointmentList view.
        }

        #endregion


        #region AppointmentDelete
        // This action method deletes a appointment from the database based on the provided AppointmentID.

        //[HttpDelete] // This attribute indicates that this method should handle HTTP DELETE requests.
        public IActionResult AppointmentDelete(int @AppointmentID) // This method handles DELETE requests to the AppointmentDelete action, where @AppointmentID is the ID of the appointment to be deleted.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.

            SqlCommand command = sqlConnection.CreateCommand();// Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_Appointment_Delete"; // Set the command text to the name of the stored procedure that will be executed to delete the appointment.

            command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = @AppointmentID; // Add a parameter to the command for the AppointmentID, which is the ID of the appointment to be deleted.

            command.ExecuteNonQuery(); // Execute the command to delete the appointment from the database.

            return RedirectToAction("AppointmentList"); // Redirect to the AppointmentList action after the appointment is deleted.
        }
        #endregion

        #region AppointmentAddEdit (GET)
        // This action method retrieves a appointment by AppointmentID for editing or adds a new appointment if AppointmentID is null.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult AppointmentAddEdit(int? AppointmentID) // This method handles GET requests to the AppointmentAddEdit action, where AppointmentID is an optional parameter.
        {
            // Retrieve the list of users from the database to populate a dropdown for selecting a user associated with the appointment.

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".

            // Retrieve the list of users, patients, doctors from the database to populate a dropdown for selecting a user, patient, doctosd associated with the appointment.
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

            // Patient List
            List<PatientModel> patientList = new List<PatientModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PR_Patient_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patientList.Add(new PatientModel
                            {
                                PatientID = Convert.ToInt32(reader["PatientID"]),
                                PatientName = reader["PatientName"].ToString()
                            });
                        }
                    }
                }
            }
            ViewBag.PatientList = patientList;

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
            AppointmentModel appointmentModel = new AppointmentModel(); // Create a new instance of the AppointmentModel class to hold appointment data.

            if (AppointmentID != null) // Check if AppointmentID is not null, indicating that we are editing an existing appointment.
            {
                using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
                sqlConnection.Open(); // Open the SQL connection to the database.
                using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.

                command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
                command.CommandText = "PR_Appointment_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the appointment by AppointmentID.
                command.Parameters.AddWithValue("@AppointmentID", AppointmentID); // Add a parameter to the command for the AppointmentID, which is the ID of the appointment to be retrieved.
                using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
                if (reader.Read()) // Check if the SqlDataReader has any rows to read, indicating that a appointment with the specified AppointmentID was found.
                {
                    appointmentModel.AppointmentID = Convert.ToInt32(reader["AppointmentID"]);
                    appointmentModel.DoctorID = Convert.ToInt32(reader["DoctorID"]);
                    appointmentModel.PatientID = Convert.ToInt32(reader["PatientID"]);
                    appointmentModel.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    appointmentModel.AppointmentStatus = reader["AppointmentStatus"].ToString();
                    Console.WriteLine(reader["AppointmentStatus"].ToString());
                    appointmentModel.Description = reader["Description"].ToString();
                    appointmentModel.SpecialRemarks = reader["SpecialRemarks"].ToString();
                    appointmentModel.TotalConsultedAmount = reader["TotalConsultedAmount"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["TotalConsultedAmount"]) : null;
                    appointmentModel.Created = Convert.ToDateTime(reader["Created"]);
                    appointmentModel.Modified = Convert.ToDateTime(reader["Modified"]);
                    appointmentModel.UserID = Convert.ToInt32(reader["UserID"]);
                    // Populate the appointmentModel properties with the values retrieved from the database.
                }
            }

            // If AppointmentID is null, we are adding a new appointment, so appointmentModel will remain with default values.
            return View(appointmentModel); // Return the view with the appointmentModel to display validation errors.
        }
        #endregion

        #region AppointmentAddEdit (POST)
        // This action method handles the form submission for adding or editing a appointment.
        [HttpPost] // This attribute indicates that this method should handle HTTP POST requests.
        public IActionResult AppointmentAddEdit(AppointmentModel appointmentModel) // This method handles POST requests to the AppointmentAddEdit action, where appointmentModel is the model containing appointment data submitted from the form.
        {
            // Check if the model state is valid, meaning that all required fields are filled out correctly.
            // If the model state is not valid, we return the view with the appointmentModel to display validation errors.
            //if (!ModelState.IsValid)
            //{
            //    Console.WriteLine(ModelState.IsValid);
            //    Console.WriteLine(value: appointmentModel.UserID.GetType());
            //    return View(appointmentModel); // Return the view with the appointmentModel to display validation errors.
            //}

            // If the model state is valid, we proceed to add or update the appointment in the database.

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.

            // Check if the AppointmentID is greater than 0, indicating that we are updating an existing appointment.
            if (appointmentModel.AppointmentID > 0)
            {
                // If AppointmentID is greater than 0, we are updating an existing appointment, so we set the command text to the update stored procedure.

                command.CommandText = "PR_Appointment_Update";// Set the command text to the name of the stored procedure that will be executed to update the appointment.
                command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentModel.AppointmentID; // Add a parameter to the command for the AppointmentID, which is the ID of the appointment to be updated.
            }
            else
            {
                // If AppointmentID is not greater than 0, we are adding a new appointment, so we set the command text to the insert stored procedure.
                command.CommandText = "PR_Appointment_Insert"; // Set the command text to the name of the stored procedure that will be executed to insert a new appointment.
                // No need to add AppointmentID parameter for insert, as it will be generated by the database.
            }

            // Add parameters for the appointmentModel properties to the command.
            command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = appointmentModel.DoctorID; // Add a parameter for the DoctorID, which is the ID of the doctor associated with the appointment.
            command.Parameters.Add("@PatientID", SqlDbType.Int).Value = appointmentModel.PatientID; // Add a parameter for the PatientID, which is the ID of the patient associated with the appointment.
            command.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Value = appointmentModel.AppointmentDate; // Add a parameter for the AppointmentDate, which is the date and time of the appointment.
            command.Parameters.Add("@AppointmentStatus", SqlDbType.NVarChar, 20).Value = appointmentModel.AppointmentStatus; // Add a parameter for the AppointmentStatus, which is the status of the appointment.
            command.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value = appointmentModel.Description; // Add a parameter for the Description, which is a description of the appointment.
            command.Parameters.Add("@SpecialRemarks", SqlDbType.NVarChar, 100).Value = appointmentModel.SpecialRemarks; // Add a parameter for the SpecialRemarks, which are any special remarks related to the appointment.
            command.Parameters.Add("@TotalConsultedAmount", SqlDbType.Decimal).Value = appointmentModel.TotalConsultedAmount ?? (object)DBNull.Value; // Add a parameter for the TotalConsultedAmount, which is the total amount consulted for the appointment. If it is null, we set it to DBNull.Value.
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = appointmentModel.UserID;

            command.ExecuteNonQuery(); // Execute the command to add or update the appointment in the database.

            return RedirectToAction("AppointmentList"); // Redirect to the AppointmentList action after the appointment is added or updated.
        }
        #endregion

        #region AppointmentDetail
        // This action method retrieves the details of a appointment by AppointmentID and returns it to the AppointmentDetail view.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult AppointmentDetail(int AppointmentID) // This method handles GET requests to the AppointmentDetail action, where AppointmentID is the ID of the appointment whose details are to be retrieved.
        {

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_Appointment_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the appointment by AppointmentID.
            command.Parameters.AddWithValue("@AppointmentID", AppointmentID); // Add a parameter to the command for the AppointmentID, which is the ID of the appointment whose details are to be retrieved.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
            DataTable dt = new DataTable(); // Create a new DataTable object to hold the appointment details retrieved from the database.
            dt.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            DataRow row = dt.Rows.Count > 0 ? dt.Rows[0] : null; // Check if the DataTable has any rows, and if so, get the first row; otherwise, set row to null.
            // The DataRow class is part of the System.Data namespace and represents a single row in a DataTable.
            return View(row); // Return the DataRow object to the AppointmentDetail view for display.
        }
        #endregion

    }
}
