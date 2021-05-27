

using DocumentFormat.OpenXml.Wordprocessing;

namespace SchoolBusinessLogic.HelperModel
{
    public class WordParagraphProperties
    {
        public string Size { get; set; }

        public bool Bold { get; set; }

        public JustificationValues JustificationValues { get; set; }
    }
}
