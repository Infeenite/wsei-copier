using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Copier;

namespace Zadanie3
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

          hp.printer.Print(in printable);
          hp.scanner.Scan(out doc);
          
          Assert.AreEqual(hp.scanner.ScanCounter, 0, 1, "Scan action fired with a printer that's turned off");
          Assert.AreEqual(hp.printer.PrintCounter, 0, 1, "Print action fired with a printer that's turned off");
        }

         [TestMethod]
        public void ShouldCountPrintsAndScans()
        {
          Copier hp = new Copier();
          var printable = new PDFDocument("VeryImportantDocument.pdf");
          IDocument doc;

          hp.printer.PowerOn();
          hp.scanner.PowerOn();
          hp.printer.Print(in printable);
          hp.scanner.Scan(out doc);
          hp.scanner.Scan(out doc);
          hp.scanner.PowerOff();
          hp.printer.Print(in printable);
          hp.printer.PowerOff();

          Assert.AreEqual(hp.printer.Counter, 1, 1, "Invalid number of power-ons");
          Assert.AreEqual(hp.scanner.Counter, 1, 1, "Invalid number of power-ons");
          Assert.AreEqual(hp.scanner.ScanCounter, 2, 1, "Invalid number of scans");
          Assert.AreEqual(hp.printer.PrintCounter, 1, 1, "Invalid number of prints");
        }
    }
}
