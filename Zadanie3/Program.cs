using System;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
        var xerox = new Copier();
        xerox.printer.PowerOn();
        IDocument doc1 = new PDFDocument("aaa.pdf");
        xerox.printer.Print(in doc1);
        xerox.printer.PowerOff();

        IDocument doc2;
        xerox.scanner.PowerOn();
        xerox.scanner.Scan(out doc2);
        xerox.scanner.PowerOff();

        Console.WriteLine( xerox.printer.Counter );
        Console.WriteLine( xerox.scanner.Counter );
        Console.WriteLine( xerox.printer.PrintCounter );
        Console.WriteLine( xerox.scanner.ScanCounter );
        }
    }
}
