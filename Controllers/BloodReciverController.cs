using BloodDonationbd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace BloodDonationbd.Controllers
{
    public class BloodReciverController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public BloodReciverController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll(string search)
        {
            List<BloodReciver> list = new List<BloodReciver>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllBloodRecivers0", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", string.IsNullOrEmpty(search) ? DBNull.Value : search);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BloodReciver
                    {
                            Id = (int)reader["Id"],
                            ReciverName = reader["ReciverName"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Address = reader["Address"].ToString(),
                            Country = reader["Country"].ToString(),
                            State = reader["State"].ToString(),
                            City = reader["City"].ToString(),
                            CraetedOn = (DateTime)reader["CraetedOn"]
                    });
                }
            }
            return Json(list);
        }

        [HttpPost]
        public JsonResult Create(BloodReciver bloodReciver)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertBloodReciver00", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReciverName", bloodReciver.ReciverName);
                cmd.Parameters.AddWithValue("@Phone", bloodReciver.Phone);
                cmd.Parameters.AddWithValue("@Address", bloodReciver.Address);
                cmd.Parameters.AddWithValue("@Country", bloodReciver.Country);
                cmd.Parameters.AddWithValue("@State", bloodReciver.State);
                cmd.Parameters.AddWithValue("@City", bloodReciver.City);
                cmd.Parameters.AddWithValue("@CraetedOn", bloodReciver.CraetedOn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult Update(BloodReciver bloodReciver)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateBloodReciver0", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", bloodReciver.Id);
                cmd.Parameters.AddWithValue("@ReciverName", bloodReciver.ReciverName);
                cmd.Parameters.AddWithValue("@Phone", bloodReciver.Phone);
                cmd.Parameters.AddWithValue("@Address", bloodReciver.Address);
                cmd.Parameters.AddWithValue("@Country", bloodReciver.Country);
                cmd.Parameters.AddWithValue("@State", bloodReciver.State);
                cmd.Parameters.AddWithValue("@City", bloodReciver.City);
                cmd.Parameters.AddWithValue("@CraetedOn", bloodReciver.CraetedOn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteBloodReciver0", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return Json(new { success = true });
        }
    }
}
