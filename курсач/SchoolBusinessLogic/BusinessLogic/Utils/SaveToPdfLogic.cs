using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using SchoolBusinessLogic.HelperModel;


namespace SchoolBusinessLogic.BusinessLogic
{
    public class SaveToPdfLogic
    {
        public static void CreateDoc(PdfInfo info)
        {
            PdfWriter writer = new PdfWriter(info.FileName);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFont font = PdfFontFactory.CreateFont(@"C:\Windows\Fonts\Arial.ttf", "Identity-H", true);

            Paragraph header = new Paragraph(info.Title)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20)
               .SetFont(font);

            Paragraph dates = new Paragraph($"с {info.DateFrom.ToShortDateString()} по { info.DateTo.ToShortDateString()}")
                .SetFontSize(18)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFont(font);

            document.Add(header);
            document.Add(dates);

            foreach (var lesson in info.Lessons)
            {
                Paragraph lessonName = new Paragraph($"{lesson.LessonName} ({lesson.LessonCount} занятий)")
                .SetFontSize(18)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBold()
                .SetFont(font);

                document.Add(lessonName);


                Paragraph costHeader = new Paragraph("Оплаты")
                    .SetFontSize(16)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFont(font);

                document.Add(costHeader);

                Table tableCosts = new Table(3, false);

                Cell numberCell = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph("Номер оплаты"))
                        .SetFont(font);

                Cell sumCell = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Сумма"))
                    .SetFont(font);

                Cell dateCell = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Дата"))
                    .SetFont(font);

                tableCosts.AddCell(numberCell);
                tableCosts.AddCell(sumCell);
                tableCosts.AddCell(dateCell);
                tableCosts.SetMarginBottom(30);

                foreach (var payment in lesson.Payments)
                {
                    numberCell = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(payment.Id.ToString())
                        .SetFont(font));

                    sumCell = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(payment.Sum.ToString()))
                        .SetFont(font);

                    dateCell = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(payment.PaymentDate.ToShortDateString()))
                        .SetFont(font);

                    tableCosts.AddCell(numberCell);
                    tableCosts.AddCell(sumCell);
                    tableCosts.AddCell(dateCell);
                }

                document.Add(tableCosts);
            }

            document.Close();
        }
    }
}
