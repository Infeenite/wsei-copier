using System;

abstract class BaseDevice: IDevice {
  private DeviceState State { get; set; }
  public int Counter { get; set; }

  public BaseDevice() {
   this.Counter = 0; 
  }
  public DeviceState GetState() {
    return this.State;
  }

  public void PowerOn() {
    this.State = DeviceState.Active;
    this.Counter++;
  }

    public void PowerOff() {
    this.State = DeviceState.Inactive;
  }
}

class Copier {
  public Printer printer;
  public Scanner scanner;

  public Copier() {
    this.printer = new Printer();
    this.scanner = new Scanner();
  }
}

class Scanner: BaseDevice, IDevice {
    public int ScanCounter { get; set; }
    public Scanner() {
      this.ScanCounter = 0;
    }

    public void Scan(out IDocument doc) {
      doc = new PDFDocument($"PDFScan{this.ScanCounter + 1}.pdf");
      if (this.GetState() == DeviceState.Active) {
        Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy H:mm:ss")} Scan {doc.GetFileName()}");
        this.ScanCounter++;
      } 
  }
}

class Printer: BaseDevice, IDevice {
   public int PrintCounter { get; set; }

   public Printer() {
       this.PrintCounter = 0;
   }

    public void Print<T>(in T doc) where T: IDocument {
    if (this.GetState() == DeviceState.Active) {
      Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy H:mm:ss")} Print {doc.GetFileName()}");
    this.PrintCounter++;
    } 

  }
}

enum DeviceState {
  Active,
  Inactive
} 

interface IDevice {
  DeviceState GetState();
  void PowerOff();
  void PowerOn();
}

interface IPrinter: IDevice {
  void Print();
}

interface IScanner: IDevice {
  void Scan();
}

