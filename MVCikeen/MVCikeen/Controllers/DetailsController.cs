using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCikeen.Models;
using System.Data.SqlClient;

namespace MVCikeen.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        public ActionResult Index()
        {
            var details = GetDetailsdata();
            return View(details);
        }
        private IEnumerable<DetailsModel> GetDetailsdata()
        {
            string selectQuery = string.Format("SELECT * FROM tblDetails");
            var details = new List<DetailsModel>();
            // Creating the connection with sql sever and executing the query
            using (var conn = new SqlConnection("Data Source=LAPTOP-43JGC8TA\\NAVADEEPSQL; Database=sample 1;Integrated security=SSPI"))
            {
                conn.Open();
                var com = new SqlCommand(selectQuery, conn);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    details.Add(new DetailsModel 
                    {
                            Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Salary = Convert.ToDecimal(dr["Salary"]),
                        
                    });
                }
                return details;
            }
        }

        public PartialViewResult GetDetailsDetail(int id)
        {
            var details = GetDetailsdata();
            var detailDetail = details.FirstOrDefault(x => x.Id == id);
            return PartialView(detailDetail);
        }

        public PartialViewResult GetAllDetails()
        {
            var details = GetDetailsdata();
            return PartialView(details);
        }
    }
}