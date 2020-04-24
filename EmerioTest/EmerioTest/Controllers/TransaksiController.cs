using EmerioTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmerioTest.Controllers;

namespace EmerioTest.Controllers
{
    public class TransaksiController : Controller
    {
        string connectionString = @"Data Source = (local); Initial Catalog = EmerioTest; Integrated Security=True";
        // GET: Transaksi
        public ActionResult Index()
        {
            DataTable dtbTransaksi = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * From tbTransaction",sqlCon);
                sqlDa.Fill(dtbTransaksi);
            }
            return View(dtbTransaksi);
        }

        // GET: Transaksi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transaksi/Create
        [HttpGet]
        public ActionResult Create()
        {
            /*
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from tbNasabah", sqlCon);
                DataTable dtbNasabah = new DataTable();
                sqlDa.Fill(dtbNasabah);
            }
            */
            return View(new TransaksiModel());
        }

        // POST: Transaksi/Create
        [HttpPost]
        public ActionResult Create(TransaksiModel transaksiModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "Insert Into tbTransaction values (@AccountID,@TransactionDate,@Description,@DebitCreditStatus,@Amount)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@AccountID",transaksiModel.AccountID);
                sqlCmd.Parameters.AddWithValue("@TransactionDate",transaksiModel.TransactionDate);
                sqlCmd.Parameters.AddWithValue("@Description",transaksiModel.Description);
                sqlCmd.Parameters.AddWithValue("@DebitCreditStatus", transaksiModel.DebitCreditStatus);
                sqlCmd.Parameters.AddWithValue("@Amount",transaksiModel.Amount);
                sqlCmd.ExecuteNonQuery();
            }
                return RedirectToAction("Index");
            
        }

        // GET: Transaksi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaksi/Edit/5
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

        // GET: Transaksi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaksi/Delete/5
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
