using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewPatients()
        {
            WebApplication3.Models.PatientModel db = new WebApplication3.Models.PatientModel();
            return View(db.Patients1.ToList());
        }
        public ActionResult createPDF()
        {
            WebApplication3.Models.PatientModel db = new WebApplication3.Models.PatientModel();
            return View(db.Patients1.ToList());
        }
 
        public FileResult createPdf1()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            string strPDFFileName = string.Format("SamplePdf" + dTime.ToString("yyyyMMdd") + "-" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            PdfPTable tableLayout = new PdfPTable(5);
            doc.SetMargins(0f, 0f, 0f, 0f);
            string strAttachment = Server.MapPath("~/Downloadss/" + strPDFFileName);
            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();
            doc.Add(Add_Content_To_PDF(tableLayout));
            doc.Close();
            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;
            return File(workStream, "application/pdf", strPDFFileName);
        }
        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {

            float[] headers = { 50, 24, 45, 35, 50 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  
            PatientModel db = new PatientModel();
            var patients = db.Patients1.ToList();

            tableLayout.AddCell(new PdfPCell(new Phrase("Creating PDF file using iTextsharp", new Font(Font.FontFamily.HELVETICA, 13, 1)))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            ////Add header  
            AddCellToHeader(tableLayout, "Email");
            AddCellToHeader(tableLayout, "DOB");
            AddCellToHeader(tableLayout, "First Name");
            AddCellToHeader(tableLayout, "Last Name");
            AddCellToHeader(tableLayout, "Suburb");

            ////Add body  
            foreach (var p in patients)
            {

                AddCellToBody(tableLayout, p.EmailId);
                AddCellToBody(tableLayout, p.DOB.ToString());
                AddCellToBody(tableLayout, p.FirstName);
                AddCellToBody(tableLayout, p.LastName);
                AddCellToBody(tableLayout, p.SuburbId.ToString());

            }

            return tableLayout;
        }
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 3,
                BackgroundColor = new iTextSharp.text.BaseColor(0, 51, 102)
            });
        }
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 3
            });
        }


    }
}