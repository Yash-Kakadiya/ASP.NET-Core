using Microsoft.AspNetCore.Mvc;
using System.Data;
using FinalTask.Models;

using System.Data.SqlClient;

namespace FinalTask.Controllers
{
    public class StudentController : Controller
    {

        private readonly IConfiguration _configuration;

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Student List
        public IActionResult List()
        {
            string connectionString = _configuration.GetConnectionString("MyConnectionString");
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("PR_Student_SelectAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return View(dt);
        }
        #endregion

        #region Add/Edit Student
        public IActionResult AddEdit(int? id)
        {
            if (id.HasValue && id > 0)
            {
                // --- Edit Mode ---
                string connectionString = _configuration.GetConnectionString("MyConnectionString");
                StudentModel model = new StudentModel();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("PR_Student_SelectByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                model.Id = Convert.ToInt32(reader["Id"]);
                                model.EnrollmentNo = reader["EnrollmentNo"].ToString();
                                model.Name = reader["Name"].ToString();
                                model.MobileNo = reader["MobileNo"].ToString();
                                model.Address = reader["Address"].ToString();
                                model.Email = reader["Email"].ToString();
                                model.Gender = reader["Gender"].ToString();
                                model.IsPlayingCricket = Convert.ToBoolean(reader["IsPlayingCricket"]);
                                model.TwelfthPercentage = Convert.ToDouble(reader["TwelfthPercentage"]);
                                model.LiveInRajkot = Convert.ToBoolean(reader["LiveInRajkot"]);
                                model.Password = reader["Password"].ToString();
                                model.ConfirmPassword = reader["Password"].ToString();
                            }
                        }
                    }
                }
                return View(model);
            }
            else
            {
                // --- Add Mode ---
                return View(new StudentModel());
            }
        }

        [HttpPost]
        public IActionResult AddEdit(StudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string connectionString = _configuration.GetConnectionString("MyConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string procedureName = model.Id > 0 ? "PR_Student_Update" : "PR_Student_Insert";

                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (model.Id > 0)
                    {
                        command.Parameters.AddWithValue("@Id", model.Id);
                    }

                    command.Parameters.AddWithValue("@EnrollmentNo", model.EnrollmentNo);
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                    command.Parameters.AddWithValue("@Address", (object)model.Address ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@IsPlayingCricket", model.IsPlayingCricket);
                    command.Parameters.AddWithValue("@Password", model.Password); 
                    command.Parameters.AddWithValue("@TwelfthPercentage", model.TwelfthPercentage);
                    command.Parameters.AddWithValue("@LiveInRajkot", model.LiveInRajkot);

                    command.ExecuteNonQuery();
                }
            }

            TempData["SuccessMessage"] = model.Id > 0 ? "Student record updated successfully!" : "New student registered successfully!";
            return RedirectToAction("List");
        }
        #endregion

        #region Delete Student
        public IActionResult Delete(int id)
        {
            string connectionString = _configuration.GetConnectionString("MyConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("PR_Student_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            TempData["SuccessMessage"] = "Student record deleted successfully.";
            return RedirectToAction("List");
        }
        #endregion
    }
}

