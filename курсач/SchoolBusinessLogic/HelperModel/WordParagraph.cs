using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.HelperModel
{
    public class WordParagraph
    {
        public List<(string, WordParagraphProperties)> Texts { get; set; }

        public WordParagraphProperties TextProperties { get; set; }
    }
}
