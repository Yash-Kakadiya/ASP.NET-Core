using CRUDRevision.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace CRUDRevision.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IConfiguration _config;

        public DepartmentController(IConfiguration config)
        {
            _config = config;
        }

        // ----------------- SELECT ALL -----------------
        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            string con = _config.GetConnectionString("ConnectionString");

            using (SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("PR_Department_SelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                }
            }

            return View(dt);
        }

        // ----------------- ADD/EDIT -----------------
        public IActionResult AddEdit(int? DeptID)
        {
            DepartmentModel model = new DepartmentModel();

            if (DeptID != null)
            {
                string con = _config.GetConnectionString("ConnectionString");

                using (SqlConnection sql = new SqlConnection(con))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("PR_Department_SelectByPK", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DeptID", DeptID);

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            model.DeptID = Convert.ToInt32(dr["DeptID"]);
                            model.DepartmentName = dr["DepartmentName"].ToString();
                        }
                    }
                }
            }

            return View(model);
        }

        // ----------------- SAVE -----------------
        [HttpPost]
        public IActionResult Save(DepartmentModel model)
        {
            string con = _config.GetConnectionString("ConnectionString");

            using (SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                using (SqlCommand cmd = sql.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (model.DeptID == 0)
                        cmd.CommandText = "PR_Department_Insert";
                    else
                    {
                        cmd.CommandText = "PR_Department_Update";
                        cmd.Parameters.AddWithValue("@DeptID", model.DeptID);
                    }

                    cmd.Parameters.AddWithValue("@DepartmentName", model.DepartmentName);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        // ----------------- DELETE -----------------
        public IActionResult Delete(int DeptID)
        {
            string con = _config.GetConnectionString("ConnectionString");

            using (SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("PR_Department_Delete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptID", DeptID);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
