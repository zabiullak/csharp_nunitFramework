using Framework.Utilities;
using System;
using Xunit;
using Xunit.Sdk;

namespace FreeCodeCamp.xUnitTest
{
    public class PDF_validate
    {
        [Fact]
        public void Test1()
        {
            string pdf_text = PDFExtractor.ExtractTextFromPDF(Utils.GetFilePathName("PDF_Validate_sample.pdf"));
            Console.WriteLine(pdf_text);

            if (!pdf_text.Contains("11.04")) { throw new XunitException(); }
            if (!pdf_text.Contains("W_FUI")) { throw new XunitException(); }
            if (!pdf_text.Contains("06/27/2022")) { throw new XunitException(); }
            if (!pdf_text.Contains("Fedelity1")) { throw new XunitException(); }
            if (pdf_text.Contains("Mohamad")) { throw new XunitException("mohamad Name not contain in the PDF pages :)"); }
        }
    }
}
