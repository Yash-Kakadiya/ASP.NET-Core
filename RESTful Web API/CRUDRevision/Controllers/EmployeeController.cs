using CRUDRevision.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using static CRUDRevision.Models.EmployeeModel;

namespace CRUDRevision.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _config;

        public EmployeeController(IConfiguration config)
        {
            _config = config;
        }

        // ---------- Load Department Dropdown ----------
        private void LoadDepartmentDropdown()
        {
            List<DepartmentDropDownModel> list = new List<DepartmentDropDownModel>();

            string con = _config.GetConnectionString("ConnectionString");

            using (SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("PR_Department_SelectAll", sql))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(new DepartmentDropDownModel()
                        {
                            DeptID = Convert.ToInt32(dr["DeptID"]),
                            DepartmentName = dr["DepartmentName"].ToString()
                        });
                    }
                }
            }

            ViewBag.DeptList = list;
        }

        // ------------------ SELECT ALL -------------------
        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            string con = _config.GetConnectionString("ConnectionString");

            using (SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("PR_Employee_SelectAll", sql))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                }
            }

            return View(dt);
        }

        // ------------------ ADD EDIT -------------------
        public IActionResult AddEdit(int? EmpID)
        {
            EmployeeModel model = new EmployeeModel();
            LoadDepartmentDropdown();

            if (EmpID != null)
            {
                string con = _config.GetConnectionString("ConnectionString");

                using (SqlConnection sql = new SqlConnection(con))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("PR_Employee_SelectByPK", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpID", EmpID);

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            model.EmpID = Convert.ToInt32(dr["EmpID"]);
                            model.EmpName = dr["EmpName"].ToString();
                            model.Salary = Convert.ToDecimal(dr["Salary"]);
                            model.JoiningDate = Convert.ToDateTime(dr["JoiningDate"]);
                            model.City = dr["City"].ToString();
                            model.DeptID = Convert.ToInt32(dr["DeptID"]);
                        }
                    }
                }
            }

            return View(model);
        }

        // ------------------ SAVE -------------------
        [HttpPost]
        public IActionResult Save(EmployeeModel model)
        {
            string con = _config.GetConnectionString("ConnectionString");

            using (SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                using (SqlCommand cmd = sql.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (model.EmpID == 0)
                        cmd.CommandText = "PR_Employee_Insert";
                    else
                    {
                        cmd.CommandText = "PR_Employee_Update";
                        cmd.Parameters.AddWithValue("@EmpID", model.EmpID);
                    }

                    cmd.Parameters.AddWithValue("@EmpName", model.EmpName);
                    cmd.Parameters.AddWithValue("@Salary", model.Salary);
                    cmd.Parameters.AddWithValue("@JoiningDate", model.JoiningDate);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@DeptID", model.DeptID);

                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        // ------------------ DELETE -------------------
        public IActionResult Delete(int EmpID)
        {
            string con = _config.GetConnectionString("ConnectionString");

            using (SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("PR_Employee_Delete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpID", EmpID);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
