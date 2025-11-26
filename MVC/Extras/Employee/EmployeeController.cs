using ClosedXML.Excel;
using HMS.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Text;

    //public int EmployeeID { get; set; }
    //public string FirstName { get; set; } = string.Empty;
    //public string LastName { get; set; } = string.Empty;
    //public string Email { get; set; } = string.Empty;
    //public string PhoneNumber { get; set; } = string.Empty;
    //public DateTime DateOfBirth { get; set; }
    //public string Gender { get; set; }
    //public DateTime HireDate { get; set; }
    //public string JobTitle { get; set; } = string.Empty;
    //public string Department { get; set; } = string.Empty;
    //public decimal Salary { get; set; }
    //public bool IsActive { get; set; } = true;
    //public DateTime CreatedAt { get; set; } = DateTime.Now;
    //public DateTime? UpdatedAt { get; set; }

namespace HMS.Controllers
{
    [CheckAccess]
    public class EmployeeController : Controller
    {
        // The EmployeeController class is a controller in an ASP.NET Core application that handles employee-related actions.


        #region configuration

        //This code is used to inject the IConfiguration service into the EmployeeController.

        private readonly IConfiguration _configuration; // Private field to hold the injected configuration

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration; // Assign the injected configuration to the private field
        }

        #endregion


        #region EmployeeList
        // This action method retrieves a list of employees from the database and returns it to the EmployeeList view.

        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult EmployeeList() // This method handles GET requests to the EmployeeList action.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration using


            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.

            sqlConnection.Open(); // Open the SQL connection to the database.


            SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.


            command.CommandText = "PR_Employee_SelectAll"; // Set the command text to the name of the stored procedure that will be executed.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.

            DataTable table = new DataTable(); // Create a new DataTable object to hold the results of the query.

            table.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            return View(table); // Return the DataTable to the EmployeeList view.
        }

        #endregion


        #region EmployeeDelete
        // This action method deletes a employee from the database based on the provided EmployeeID.

        //[HttpDelete] // This attribute indicates that this method should handle HTTP DELETE requests.
        public IActionResult EmployeeDelete(int @EmployeeID) // This method handles DELETE requests to the EmployeeDelete action, where @EmployeeID is the ID of the employee to be deleted.
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.

            SqlCommand command = sqlConnection.CreateCommand();// Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_Employee_Delete"; // Set the command text to the name of the stored procedure that will be executed to delete the employee.

            command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = @EmployeeID; // Add a parameter to the command for the EmployeeID, which is the ID of the employee to be deleted.

            command.ExecuteNonQuery(); // Execute the command to delete the employee from the database.

            return RedirectToAction("EmployeeList"); // Redirect to the EmployeeList action after the employee is deleted.
        }
        #endregion

        #region EmployeeAddEdit (GET)
        // This action method retrieves a employee by EmployeeID for editing or adds a new employee if EmployeeID is null.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult EmployeeAddEdit(int? EmployeeID) // This method handles GET requests to the EmployeeAddEdit action, where EmployeeID is an optional parameter.
        {
            EmployeeModel employeeModel = new EmployeeModel(); // Create a new instance of the EmployeeModel class to hold employee data.

            if (EmployeeID != null) // Check if EmployeeID is not null, indicating that we are editing an existing employee.
            {
                string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnection
                using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
                sqlConnection.Open(); // Open the SQL connection to the database.
                using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
                command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
                command.CommandText = "PR_Employee_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the employee by EmployeeID.
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID); // Add a parameter to the command for the EmployeeID, which is the ID of the employee to be retrieved.
                using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
                if (reader.Read()) // Check if the SqlDataReader has any rows to read, indicating that a employee with the specified EmployeeID was found.
                {
                    employeeModel.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    employeeModel.FirstName = reader["FirstName"].ToString();
                    employeeModel.LastName = reader["LastName"].ToString();
                    employeeModel.Email = reader["Email"].ToString();
                    employeeModel.PhoneNumber = reader["PhoneNumber"].ToString();
                    employeeModel.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    employeeModel.Gender = reader["Gender"].ToString();
                    employeeModel.HireDate = Convert.ToDateTime(reader["HireDate"]);
                    employeeModel.JobTitle = reader["JobTitle"].ToString();
                    employeeModel.Department = reader["Department"].ToString();
                    employeeModel.Salary = Convert.ToDecimal(reader["Salary"]);
                    employeeModel.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    employeeModel.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    employeeModel.UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"]);
                    // Populate the employeeModel properties with the values retrieved from the database.
                }
            }
            // If EmployeeID is null, we are adding a new employee, so employeeModel will remain with default values.
            return View(employeeModel); // Return the view with the employeeModel to display validation errors.
        }
        #endregion

        #region EmployeeAddEdit (POST)
        // This action method handles the form submission for adding or editing a employee.
        [HttpPost] // This attribute indicates that this method should handle HTTP POST requests.
        public IActionResult EmployeeAddEdit(EmployeeModel employeeModel) // This method handles POST requests to the EmployeeAddEdit action, where employeeModel is the model containing employee data submitted from the form.
        {
            // Check if the model state is valid, meaning that all required fields are filled out correctly.
            // If the model state is not valid, we return the view with the employeeModel to display validation errors.
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState.IsValid);
                return View(employeeModel); // Return the view with the employeeModel to display validation errors.
            }

            // If the model state is valid, we proceed to add or update the employee in the database.

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.

            // Check if the EmployeeID is greater than 0, indicating that we are updating an existing employee.
            if (employeeModel.EmployeeID > 0)
            {
                // If EmployeeID is greater than 0, we are updating an existing employee, so we set the command text to the update stored procedure.

                command.CommandText = "PR_Employee_Update";// Set the command text to the name of the stored procedure that will be executed to update the employee.
                command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employeeModel.EmployeeID; // Add a parameter to the command for the EmployeeID, which is the ID of the employee to be updated.
            }
            else
            {
                // If EmployeeID is not greater than 0, we are adding a new employee, so we set the command text to the insert stored procedure.
                command.CommandText = "PR_Employee_Insert"; // Set the command text to the name of the stored procedure that will be executed to insert a new employee.
                // No need to add EmployeeID parameter for insert, as it will be generated by the database.
            }

            // Add parameters for the employeeModel properties to the command.
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = employeeModel.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = employeeModel.LastName;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = employeeModel.Email;
            command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = employeeModel.PhoneNumber;
            command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = employeeModel.DateOfBirth;
            command.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = employeeModel.Gender;
            command.Parameters.Add("@HireDate", SqlDbType.Date).Value = employeeModel.HireDate;
            command.Parameters.Add("@JobTitle", SqlDbType.NVarChar).Value = employeeModel.JobTitle;
            command.Parameters.Add("@Department", SqlDbType.NVarChar).Value = employeeModel.Department;
            command.Parameters.Add("Salary", SqlDbType.Decimal).Value = employeeModel.Salary;

            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = employeeModel.IsActive;

            command.ExecuteNonQuery(); // Execute the command to add or update the employee in the database.

            return RedirectToAction("EmployeeList"); // Redirect to the EmployeeList action after the employee is added or updated.
        }
        #endregion

        #region EmployeeDetail
        // This action method retrieves the details of a employee by EmployeeID and returns it to the EmployeeDetail view.
        [HttpGet] // This attribute indicates that this method should handle HTTP GET requests.
        public IActionResult EmployeeDetail(int EmployeeID) // This method handles GET requests to the EmployeeDetail action, where EmployeeID is the ID of the employee whose details are to be retrieved.
        {

            string connectionString = _configuration.GetConnectionString("MyConnectionString"); // Retrieve the connection string from the configuration file using the name "MyConnectionString".
            using SqlConnection sqlConnection = new SqlConnection(connectionString); // Create a new SqlConnection object using the connection string.
            sqlConnection.Open(); // Open the SQL connection to the database.
            using SqlCommand command = sqlConnection.CreateCommand(); // Create a new SqlCommand object to execute a SQL command against the database.
            command.CommandType = CommandType.StoredProcedure; // Set the command type to StoredProcedure, indicating that the command will execute a stored procedure.
            command.CommandText = "PR_Employee_SelectByID"; // Set the command text to the name of the stored procedure that will be executed to retrieve the employee by EmployeeID.
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID); // Add a parameter to the command for the EmployeeID, which is the ID of the employee whose details are to be retrieved.
            using SqlDataReader reader = command.ExecuteReader(); // Execute the command and retrieve the results using a SqlDataReader object.
            DataTable dt = new DataTable(); // Create a new DataTable object to hold the employee details retrieved from the database.
            dt.Load(reader); // Load the results from the SqlDataReader into the DataTable.

            DataRow row = dt.Rows.Count > 0 ? dt.Rows[0] : null; // Check if the DataTable has any rows, and if so, get the first row; otherwise, set row to null.
            // The DataRow class is part of the System.Data namespace and represents a single row in a DataTable.
            return View(row); // Return the DataRow object to the EmployeeDetail view for display.
        }
        #endregion
        #region Export
        [HttpGet]
        public IActionResult ExportEmployees(string exportType)
        {
            // Step 1: Fetch data same as EmployeeList
            string ConnectionString = _configuration.GetConnectionString("MyConnectionString");
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Employee_SelectAll";
            using SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            // Step 2: Export based on type
            switch (exportType?.ToLower())
            {
                case "excel":
                    return ExportToExcel(table);
                case "csv":
                    return ExportToCsv(table);
                case "pdf":
                    return ExportToPdf(table);
                default:
                    return RedirectToAction("EmployeeList");
            }
        }

        private FileResult ExportToExcel(DataTable table)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Employees");

            // Insert DataTable as an Excel table (structured table)
            var xlTable = worksheet.Cell(1, 1).InsertTable(table, "EmployeesTable", true);
            // Apply built-in Excel Table Style (Ice Blue - Medium 23)
            xlTable.Theme = XLTableTheme.TableStyleMedium23;

            // Autofit columns
            worksheet.Columns().AdjustToContents();

            // Apply borders and styling
            var rngTable = worksheet.RangeUsed();
            rngTable.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            rngTable.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // Header styling
            var headerRow = rngTable.Row(1);
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Employees.xlsx");
        }


        private FileResult ExportToCsv(DataTable table)
        {
            var sb = new StringBuilder();

            // Headers
            IEnumerable<string> columnNames = table.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            // Rows
            foreach (DataRow row in table.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Employees.csv");
        }
        private FileResult ExportToPdf(DataTable table)
        {
            using (var ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                // Title
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, new BaseColor(91, 155, 213));
                Paragraph title = new Paragraph("Employees List", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                doc.Add(new Paragraph("\n"));

                // Table
                PdfPTable pdfTable = new PdfPTable(table.Columns.Count);
                pdfTable.WidthPercentage = 100;
                pdfTable.SpacingBefore = 10f;
                pdfTable.SpacingAfter = 10f;

                // Header row
                foreach (DataColumn column in table.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(
                        column.ColumnName,
                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, new BaseColor(255, 255, 255))
                    ));
                    cell.BackgroundColor = new BaseColor(91, 155, 213); // Ice Blue
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 6;

                    // Full border
                    cell.BorderWidth = 1;
                    cell.BorderColor = new BaseColor(0, 0, 0);

                    pdfTable.AddCell(cell);
                }

                // Data rows with alternating colors
                bool isAlternate = false;
                foreach (DataRow row in table.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(
                            item?.ToString() ?? "",
                            FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK)
                        ));
                        cell.Padding = 5;
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;

                        // Background zebra striping
                        cell.BackgroundColor = isAlternate
                            ? new BaseColor(221, 235, 247) // Light Blue
                            : BaseColor.WHITE;

                        // Full border
                        cell.BorderWidth = 1;
                        cell.BorderColor = new BaseColor(0, 0, 0);

                        pdfTable.AddCell(cell);
                    }
                    isAlternate = !isAlternate;
                }

                doc.Add(pdfTable);
                doc.Close();

                return File(ms.ToArray(), "application/pdf", "Employees.pdf");
            }
        }



        #endregion

    }

}
