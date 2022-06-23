using AmericanAmbassyForm.Data;
using AmericanAmbassyForm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace AmericanAmbassyForm.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection(); 
        List<FormInformation> forminformation = new List<FormInformation>();

        private readonly ILogger<HomeController> _logger;
        private readonly AmericanAmbassyDBContex americanAmbassyDBContex;
        public HomeController(ILogger<HomeController> logger, AmericanAmbassyDBContex americanAmbassyDBContex)
        {
            _logger = logger;
            this.americanAmbassyDBContex = americanAmbassyDBContex;
            con.ConnectionString = AmericanAmbassyForm.Properties.Resources.ConnectionString;

        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Index(FormInformation info)
        {
            americanAmbassyDBContex.FormInformations.Add(info);
            americanAmbassyDBContex.SaveChanges();

            return View();
        }

        private void DataFetch()
        {
            if(forminformation.Count>0)
            {
                forminformation.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [Id],[Name],[Email],[Phone],[DOB],[Age],[Surname] FROM[AmericanAmbassyForm].[dbo].[FormInfo]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    forminformation.Add(new FormInformation() {
                        Name = dr["Name"].ToString()
                        ,Age = dr["Age"].ToString()
                        ,Email = dr["Email"].ToString()
                        ,DOB = dr["DOB"].ToString()
                        ,Phone = dr["Phone"].ToString()
                        ,Surname = dr["Surname"].ToString()
                    });
                }
                con.Close();
            }
            catch(Exception ex)
            {
                throw ex;

            }
            
        }

        public IActionResult Privacy()
        {
            DataFetch();
            return View(forminformation);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}