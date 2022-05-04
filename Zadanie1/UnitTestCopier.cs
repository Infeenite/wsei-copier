using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Copier;

namespace Zadanie1
{
    [TestClass]
    public class UnitTestCopier
    {
        [TestMethod]
        public void ShouldNotScanIfOff()
        {
          Copier hp = new Copier();
          var printable = new PDFDocument("VeryImportantDocument.pdf");
          IDocument doc;

          hp.Print(in printable);
          hp.Scan(out doc);
          
          Assert.AreEqual(hp.ScanCounter, 0, 1, "Scan action fired with a printer that's turned off");
          Assert.AreEqual(hp.PrintCounter, 0, 1, "Print action fired with a printer that's turned off");
        }

         [TestMethod]
        public void ShouldCountPrintsAndScans()
        {
          Copier hp = new Copier();
          var printable = new PDFDocument("VeryImportantDocument.pdf");
          IDocument doc;

          hp.PowerOn();
          hp.Print(in printable);
          hp.Scan(out doc);
          hp.Scan(out doc);
          hp.PowerOff();
          hp.Print(in printable);

          Assert.AreEqual(hp.Counter, 1, 1, "Invalid number of power-ons");
          Assert.AreEqual(hp.ScanCounter, 2, 1, "Invalid number of scans");
          Assert.AreEqual(hp.PrintCounter, 1, 1, "Invalid number of prints");
        }
    }
}
