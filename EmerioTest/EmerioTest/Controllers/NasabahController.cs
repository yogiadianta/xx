using EmerioTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmerioTest.Controllers
{
    public class NasabahController : Controller
    {
        string connectionString = @"Data Source =  (local); Initial Catalog = EmerioTest; Integrated Security=True";
        // GET: Nasabah
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtbNasabah = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * From tbNasabah",sqlCon);
                sqlDa.Fill(dtbNasabah);
            }
            return View(dtbNasabah);
        }

        // GET: Nasabah/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Nasabah/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new NasabahModel());
        }

        // POST: Nasabah/Create
        [HttpPost]
        public ActionResult Create(NasabahModel nasabahModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO tbNasabah Values(@Name)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Name", nasabahModel.Name);

                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Nasabah/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Nasabah/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Nasabah/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Nasabah/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
