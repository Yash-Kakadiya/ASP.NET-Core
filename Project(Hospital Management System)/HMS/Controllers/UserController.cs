    using HMS.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;

//public int UserID { get; set; }
//public string UserName { get; set; }
//public string Password { get; set; }
//public string Email { get; set; }
//public string MobileNo { get; set; }
//public bool IsActive { get; set; }
//public DateTime Created { get; set; }
//public DateTime Modified { get; set; }
namespace HMS.Controllers
{
    // The namespace declaration indicates that this code is part of the HMS.Controllers namespace.
    // The UserController class is defined within the HMS.Controllers namespace, which is a common practice in ASP.NET Core applications to organize controllers.

    public class UserController : Controller
    {
        // The UserController class is a controller in an ASP.NET Core application that handles user-related actions.
        // The UserController class inherits from the Controller base class, which provides methods and properties for handling HTTP requests and responses.

        #region configuration

        //This code is used to inject the IConfiguration service into the UserController.

        // The IConfiguration interface is part of the Microsoft.Extensions.Configuration namespace and is used to access configuration settings in ASP.NET Core applications.
        // It allows you to read configuration values from various sources, such as appsettings.json, environment variables, or command-line arguments.
        // The IConfiguration service is typically registered in the Startup class of an ASP.NET Core application, allowing it to be injected into controllers and other services.
        // This allows the UserController to access configuration settings throughout its methods.
        // The IConfiguration interface provides methods to retrieve configuration values by key, such as GetConnectionString, GetValue, and GetSection.

        // The UserController class has a private field _configuration of type IConfiguration.
        private readonly IConfiguration _configuration;
        // This field is used to store the configuration settings for the application, which can be accessed throughout the UserController methods.

        // The constructor of the UserController class takes an IConfiguration parameter, which is automatically injected by the ASP.NET Core dependency injection system.
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration; // Assign the injected configuration to the private field
        }
        // This constructor allows the UserController to access configuration settings, such as connection strings or application settings, by using the _configuration field.
        // The constructor is called when an instance of the UserController is created, and it ensures that the _configuration field is initialized with the provided IConfiguration instance.
        // This allows the UserController to access configuration settings, such as connection strings or application settings, by using the _configuration field.

        #endregion

        #region UserList
        // This action method retrieves a list of users from the database and returns it to the UserList view.

        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult UserList() // This method handles GET requests to the UserList action.
        {
            // The connection string is retrieved from the configuration file using
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString");
            // the name "MyConnectionString" will be used to connect to the database.
            // The GetConnectionString method is part of the IConfiguration interface, which allows you to access configuration settings in ASP.NET Core applications.
            // The connection string is typically defined in the appsettings.json file or other configuration sources.
            // It contains the necessary information to establish a connection to the database, such as the server name, database name, user credentials, and other connection parameters.

            // The SqlConnection class is used to create a connection to a SQL Server database.
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            // A new SqlConnection object is created using the connection string.
            // The SqlConnection class is part of the System.Data.SqlClient namespace, which provides classes for working with SQL Server databases.
            // The SqlConnection object is used to establish a connection to the database.
            sqlConnection.Open(); // Open the SQL connection to the database.


            SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            // The CommandType enumeration is part of the System.Data namespace and specifies the type of command being executed.


            command.CommandText = "PR_User_SelectAll"; // Set the command text to the name of the stored procedure that will be executed.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
            // The ExecuteReader method executes the command and returns a SqlDataReader object that can be used to read the results of the query.
            // The SqlDataReader class is part of the System.Data.SqlClient namespace and provides a way to read a forward-only stream of rows from a SQL Server database.
            // The SqlDataReader object allows you to read the results of the query row by row.

            DataTable table = new DataTable(); // Create a new DataTable object to hold the results of the query.
            // The DataTable class is part of the System.Data namespace and represents an in-memory table of data.
            // A DataTable can hold multiple rows and columns of data, making it suitable for storing query results.
            // The DataTable object is used to store the results of the query in a tabular format.
            // The DataTable class provides methods and properties to manipulate and access the data in a tabular format.

            // The Load method of the DataTable class is used to load the results from the SqlDataReader into the DataTable.
            // The Load method reads the data from the SqlDataReader and populates the DataTable with the results.
            // This allows you to work with the results in a structured way, such as binding it to a view or performing further processing.
            // The DataTable can then be used to display the results in a view or perform further processing.
            table.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            return View(table); // Return the DataTable to the UserList view.
        }

        #endregion

        #region UserDelete
        // This action method deletes a user from the database based on the provided UserID.

        //[HttpDelete] // This attribute indicates that this method should handle HTTP DELETE requests.
        public IActionResult UserDelete(int @UserID) // This method handles DELETE requests to the UserDelete action, where @UserID is the ID of the user to be deleted.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.

            SqlCommand command = sqlConnection.CreateCommand();// Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_User_Delete"; // Set the command text to the name of the stored procedure that will be executed to delete the user.


            // The SqlParameterCollection class is part of the System.Data.SqlClient namespace and provides a way to manage parameters for a SQL command.
            // The SqlParameter class is part of the System.Data.SqlClient namespace and represents a parameter to a SQL command.
            // The SqlParameter class provides properties and methods to define the parameter's name, type, value, and other attributes.
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = @UserID; // Add a parameter to the command for the UserID, which is the ID of the user to be deleted.
            // The Add method of the SqlParameterCollection class is used to add a parameter to the command.
            // The Value property of the SqlParameter class is used to set the value of the parameter.
            // The SqlDbType enumeration is part of the System.Data.SqlClient namespace and specifies the data type of the parameter.
            // The SqlDbType.Int indicates that the parameter is of type integer.

            command.ExecuteNonQuery(); // Execute the command to delete the user from the database.
            // The ExecuteNonQuery method is typically used for commands that do not return any data, such as INSERT, UPDATE, or DELETE statements.
            // After executing the command, the user is added/updated or deleted in the database.
            // The ExecuteNonQuery method returns the number of rows affected by the command, but in this case, we do not need to use that value.

            return RedirectToAction("UserList"); // Redirect to the UserList action after the user is deleted.
        }
        #endregion

        #region UserAddEdit (GET)
        // This action method retrieves a user by UserID for editing or adds a new user if UserID is null.
        // It returns a UserModel object to the UserAddEdit view.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult UserAddEdit(int? UserID) // This method handles GET requests to the UserAddEdit action, where UserID is an optional parameter.
        {
            UserModel userModel = new UserModel(); // Create a new instance of the UserModel class to hold user data.

            if (UserID != null) // Check if UserID is not null, indicating that we are editing an existing user.
            {
                string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnection
                using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
                sqlConnection.Open(); // Open the SQL connection to the database.
                using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
                command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
                command.CommandText = "PR_User_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the user by UserID.
                command.Parameters.AddWithValue("@UserID", UserID); // Add a parameter to the command for the UserID, which is the ID of the user to be retrieved.
                using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
                if (reader.Read()) // Check if the SqlDataReader has any rows to read, indicating that a user with the specified UserID was found.
                {
                    userModel.UserID = Convert.ToInt32(reader["UserID"]);
                    userModel.UserName = reader["UserName"].ToString();
                    userModel.Password = reader["Password"].ToString();
                    userModel.Email = reader["Email"].ToString();
                    userModel.MobileNo = reader["MobileNo"].ToString();
                    userModel.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    userModel.Created = Convert.ToDateTime(reader["Created"]);
                    userModel.Modified = Convert.ToDateTime(reader["Modified"]);
                    // Populate the userModel properties with the values retrieved from the database.
                }
            }
            // If UserID is null, we are adding a new user, so userModel will remain with default values.
            return View(userModel); // Return the UserModel object to the UserAddEdit view for display or editing.
        }
        #endregion

        #region UserAddEdit (POST)
        // This action method handles the form submission for adding or editing a user.
        [HttpPost] // This attribute indicates that this method should handle HTTP POST requests.
        public IActionResult UserAddEdit(UserModel userModel) // This method handles POST requests to the UserAddEdit action, where userModel is the model containing user data submitted from the form.
        {
            // Check if the model state is valid, meaning that all required fields are filled out correctly.
            // If the model state is not valid, we return the view with the userModel to display validation errors.
            if (!ModelState.IsValid)
            {
                return View(userModel); // Return the view with the userModel to display validation errors.
            }
            // The ModelState is a collection of key-value pairs that represent the state of the model and any validation errors that may have occurred during model binding.
            // The ModelState.IsValid property is used to check if the model state is valid, meaning that all required fields are filled out correctly and any validation rules are satisfied.

            // If the model state is valid, we proceed to add or update the user in the database.

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.

            // Check if the UserID is greater than 0, indicating that we are updating an existing user.
            if (userModel.UserID > 0)
            {
                // If UserID is greater than 0, we are updating an existing user, so we set the command text to the update stored procedure.

                command.CommandText = "PR_User_Update";// Set the command text to the name of the stored procedure that will be executed to update the user.
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userModel.UserID; // Add a parameter to the command for the UserID, which is the ID of the user to be updated.
            }
            else
            {
                // If UserID is not greater than 0, we are adding a new user, so we set the command text to the insert stored procedure.
                command.CommandText = "PR_User_Insert"; // Set the command text to the name of the stored procedure that will be executed to insert a new user.
                // No need to add UserID parameter for insert, as it will be generated by the database.
            }

            // Add parameters for the userModel properties to the command.
            command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userModel.UserName;
            command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = userModel.Password;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = userModel.Email;
            command.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = userModel.MobileNo;
            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = userModel.IsActive;

            command.ExecuteNonQuery(); // Execute the command to add or update the user in the database.

            return RedirectToAction("UserList"); // Redirect to the UserList action after the user is added or updated.
        }
        #endregion

        #region UserDetail
        // This action method retrieves the details of a user by UserID and returns it to the UserDetail view.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult UserDetail(int UserID) // This method handles GET requests to the UserDetail action, where UserID is the ID of the user whose details are to be retrieved.
        {

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_User_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the user by UserID.
            command.Parameters.AddWithValue("@UserID", UserID); // Add a parameter to the command for the UserID, which is the ID of the user whose details are to be retrieved.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
            DataTable dt = new DataTable(); // Create a new DataTable object to hold the user details retrieved from the database.
            dt.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            DataRow row = dt.Rows.Count > 0 ? dt.Rows[0] : null; // Check if the DataTable has any rows, and if so, get the first row; otherwise, set row to null.
            // The DataRow class is part of the System.Data namespace and represents a single row in a DataTable.
            return View(row); // Return the DataRow object to the UserDetail view for display.
        }
        #endregion
    }
}