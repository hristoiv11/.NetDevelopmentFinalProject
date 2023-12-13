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
        public static void exportToPDF(List<References> ree, List<PhoneNumber> ph, List<Hobbies> hob, List<WorkExperience> people, List<Education> ed)
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

            string text1 = "";
            foreach (References re in ree)
            {
                text1 += String.Format("\n His name is {0} and his email is {1} ,he is {2}, his phone number is {3}. ", re.Name, re.Email, re.Description, re.PhoneNumber);
            }

            string text2 = "";
            foreach (PhoneNumber phe in ph)
            {
                text2 += String.Format("\n The number is {0} and the type is {1}.", phe.Number, phe.Type);
            }

            string text3 = "";
            foreach (Hobbies he in hob)
            {
                text3 += String.Format("\n Desctiption:{0} and Type:{1}.", he.Description, he.Type);
            }

            string text4 = "";
            foreach (WorkExperience p in people)
            {
                text4 += String.Format("\n Company Name is:{0},Job Title is:{1}, Years Spent:{2}.", p.CompanyName, p.JobTitle,p.YearsSpent);
            }

            string text5 = "";
            foreach (Education e in ed)
            {
                text5 += String.Format("\n Institution Name is:{0}, Level:{1} and the address is:{2}.",e.InstitutionName, e.Level, e.Address);
            }


            rect = new XRect(10, 220, page.Width - 20, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString(text1, fontBody, XBrushes.Black, rect, XStringFormat.TopLeft);
            tf.DrawString(text2, fontBody, XBrushes.Black, rect, XStringFormat.TopCenter);
            tf.DrawString(text3, fontBody, XBrushes.Black, rect, XStringFormat.BottomCenter);
            tf.DrawString(text4, fontBody, XBrushes.Black, rect, XStringFormat.Center);
            tf.DrawString(text5, fontBody, XBrushes.Black, rect, XStringFormat.BottomCenter);

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
