using Microsoft.Win32;
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNET2
{
    public static class ExportToPDF
    {
        public static void exportToPDF(List<WorkExperience> people, List<Education> ed,List<Hobbies> hob, List<PhoneNumber> ph, List<References> ree)
        {
            //create a new pdf document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Test PDF Document";

            //create empty page
            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.Letter;

            //Get an Xgraphic Object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //create a font
            XFont fontTitle = new XFont("Verdana", 22);

            XFont subtitle = new XFont("Times New Roman", 18);

            XFont fontBody = new XFont("Arial", 12);

            //create text formatter

            XTextFormatter tf = new XTextFormatter(gfx);

            //color page for fun
            XRect rect = new XRect(0, 0, page.Width, page.Height);
            gfx.DrawRectangle(XBrushes.BlanchedAlmond, rect);

            //title
            rect = new XRect(0, 10, page.Width - 20, 50);
            tf.Alignment = XParagraphAlignment.Center;
            string title = "My Resume!";
            tf.DrawString(title, fontTitle, XBrushes.Red, rect);

            //Add Peeps Text
            string text = "";
            foreach (WorkExperience p in people)
            {
                text += String.Format("\n{0} {1} lives in {2} ans is {3} years old. ", p.CompanyName, p.JobTitle,p.YearsSpent);
            }

            string text2 = "";
            foreach (Education e in ed)
            {
                text2 += String.Format("\n{0} {1} lives in {2} ans is {3} years old. ",e.InstitutionName, e.Level, e.Address);
            }

            string text3 = "";
            foreach (Hobbies he in hob)
            {
                text3 += String.Format("\n{0} {1} lives in {2}. ", he.Description, he.Type);
            }

            string text4 = "";
            foreach (PhoneNumber phe in ph)
            {
                text4 += String.Format("\n{0} {1} lives in {2}. ", phe.Number, phe.Type);
            }
            string text5 = "";
            foreach (References re in ree)
            {
                text5 += String.Format("\n{0} {1} lives in {2} he is {3} his phone number is {4}. ", re.Name, re.Email, re.Description, re.PhoneNumber);
            }

            rect = new XRect(10, 220, page.Width - 20, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString(text, fontBody, XBrushes.Black, rect, XStringFormat.TopLeft);
            tf.DrawString(text2, fontBody, XBrushes.Black, rect, XStringFormat.TopCenter);
            tf.DrawString(text3, fontBody, XBrushes.Black, rect, XStringFormat.BottomCenter);
            tf.DrawString(text4, fontBody, XBrushes.Black, rect, XStringFormat.Center);
            tf.DrawString(text5, fontBody, XBrushes.Black, rect, XStringFormat.Default);

            const string filename = "Resume.pdf";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files(*.pdf)| *.pdf| All files(*.*)|*.*";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Title = filename;
            saveFileDialog.OverwritePrompt = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                document.Save(saveFileDialog.FileName);
            }
        }
    }
}
