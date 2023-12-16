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
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Test PDF Document";

            // Create an empty page
            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.Letter;

            // Get an XGraphic object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create fonts
            XFont fontTitle = new XFont("Verdana", 22);
            XFont fontSubtitle = new XFont("Times New Roman", 18);
            XFont fontBody = new XFont("Arial", 12);

            // Create a text formatter
            XTextFormatter tf = new XTextFormatter(gfx);

            // Color the page for fun
            XRect rect = new XRect(0, 0, page.Width, page.Height);
            gfx.DrawRectangle(XBrushes.BlanchedAlmond, rect);

            // Title
            rect = new XRect(0, 10, page.Width, 50);
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString("My Resume!", fontTitle, XBrushes.Red, rect);

            // Add Peeps Text
            float yPosition = 80;

            yPosition = DrawSectionHeader(tf, "References", fontSubtitle, yPosition);
            yPosition = DrawSectionContent(tf, FormatReferences(ree), fontBody, yPosition + 10); // Add some extra spacing

            yPosition = DrawSectionHeader(tf, "Phone Numbers", fontSubtitle, yPosition);
            yPosition = DrawSectionContent(tf, FormatPhoneNumbers(ph), fontBody, yPosition + 10); // Add some extra spacing

            yPosition = DrawSectionHeader(tf, "Hobbies", fontSubtitle, yPosition);
            yPosition = DrawSectionContent(tf, FormatHobbies(hob), fontBody, yPosition + 10); // Add some extra spacing

            yPosition = DrawSectionHeader(tf, "Work Experience", fontSubtitle, yPosition);
            yPosition = DrawSectionContent(tf, FormatWorkExperience(people), fontBody, yPosition + 10); // Add some extra spacing

            yPosition = DrawSectionHeader(tf, "Education", fontSubtitle, yPosition);
            yPosition = DrawSectionContent(tf, FormatEducation(ed), fontBody, yPosition + 10); // Add some extra spacing


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



        private static string FormatReferences(List<References> ree)
        {
            StringBuilder text = new StringBuilder();
            foreach (References re in ree)
            {
                text.AppendLine($"His name is {re.Name} you can contact him on his email {re.Email}. He is an {re.Description}, and if he does't respond throw email, you can call him on his phone number which is {re.PhoneNumber}.");
            }
            return text.ToString();
        }

        private static string FormatPhoneNumbers(List<PhoneNumber> ph)
        {
            StringBuilder text = new StringBuilder();
            foreach (PhoneNumber phe in ph)
            {
                text.AppendLine($"My phone number is {phe.Number}. It's my {phe.Type} phone number where you can contact me.");
            }
            return text.ToString();
        }

        private static string FormatHobbies(List<Hobbies> hob)
        {
            StringBuilder text = new StringBuilder();
            foreach (Hobbies he in hob)
            {
                text.AppendLine($"A little description of my hobbie: {he.Description} and the type would be: {he.Type}.");
            }
            return text.ToString();
        }

        private static string FormatWorkExperience(List<WorkExperience> people)
        {
            StringBuilder text = new StringBuilder();
            foreach (WorkExperience p in people)
            {
                text.AppendLine($"A company I used to work for is called {p.CompanyName}. My job over there was a {p.JobTitle}. I spent {p.YearsSpent} years in this company.");
            }
            return text.ToString();
        }

        private static string FormatEducation(List<Education> ed)
        {
            StringBuilder text = new StringBuilder();
            foreach (Education e in ed)
            {
                text.AppendLine($"The name of the institution I graduaded is {e.InstitutionName}.It was a {e.Level} level. The institution was located on {e.Address}.");
            }
            return text.ToString();
        }

        private static float DrawSectionHeader(XTextFormatter tf, string header, XFont font, float yPosition)
        {
            float sectionHeight = 20;
            XRect rect = new XRect(250, yPosition, 0, sectionHeight);
            tf.DrawString(header, font, XBrushes.Black, rect, XStringFormat.TopLeft);
            return yPosition + sectionHeight;
        }

        private static float DrawSectionContent(XTextFormatter tf, string content, XFont font, float yPosition)
        {
            float sectionHeight = 40;
            XRect rect = new XRect(50, yPosition, 500, 50);
            tf.DrawString(content, font, XBrushes.Black, rect, XStringFormat.TopLeft);
            return yPosition + sectionHeight;
        }
    }
}
