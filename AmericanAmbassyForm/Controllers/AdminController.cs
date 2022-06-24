using Microsoft.AspNetCore.Mvc;
using AmericanAmbassyForm.Data;
using AmericanAmbassyForm.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;



namespace AmericanAmbassyForm.Controllers
{
    public class AdminController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<FormInformation> forminformation = new List<FormInformation>();
        List<RegisteredUser> registeredUsers = new List<RegisteredUser>();

        public AdminController(ILogger<AdminController> logger, AmericanAmbassyDBContex americanAmbassyDBContex)
        {
           
            con.ConnectionString = AmericanAmbassyForm.Properties.Resources.ConnectionString;

        }

        private void DataFetch()
        {
            if (forminformation.Count > 0)
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
                    forminformation.Add(new FormInformation()
                    {
                        Name = dr["Name"].ToString()
                        ,
                        Age = dr["Age"].ToString()
                        ,
                        Email = dr["Email"].ToString()
                        ,
                        DOB = dr["DOB"].ToString()
                        ,
                        Phone = dr["Phone"].ToString()
                        ,
                        Surname = dr["Surname"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public IActionResult Index()
        {

            DataFetch();
            return View(forminformation);
        }


        private void FetchUserData()
        {
            if (forminformation.Count > 0)
            {
                forminformation.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [Id],[FirstName],[LastName],[UserName],[Email],[PhoneNumber] FROM[AmericanAmbassyForm].[dbo].[AspNetUsers]";
                 dr = com.ExecuteReader();
                while (dr.Read())
                {
                    registeredUsers.Add(new RegisteredUser()
                    {
                        FirstName = dr["FirstName"].ToString()
                        ,LastName = dr["LastName"].ToString()
                        ,UserName = dr["UserName"].ToString()
                        ,Email = dr["Email"].ToString()
                        ,PhoneNumber = dr["PhoneNumber"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public IActionResult RegisteredUsers()
        {
            FetchUserData();
            return View(registeredUsers);
        }
    }
}
