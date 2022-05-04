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

class Copier: BaseDevice, IDevice {
  public int PrintCounter { get; set; }
   public int ScanCounter { get; set; }

  public Copier() {
    this.PrintCounter = 0;
    this.ScanCounter = 0;
  }
  
  public void Print<T>(in T doc) where T: IDocument {
    if (this.GetState() == DeviceState.Active) {
      Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy H:mm:ss")} Print {doc.GetFileName()}");
    this.PrintCounter++;
    } 

  }

    public void Scan(out IDocument doc) {
      doc = new PDFDocument($"PDFScan{this.ScanCounter + 1}.pdf");
    if (this.GetState() == DeviceState.Active) {
      Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy H:mm:ss")} Scan {doc.GetFileName()}");
      this.ScanCounter++;
    } 
  }

      public void ScanAndPrint() {
    if (this.GetState() == DeviceState.Active) {
      Console.WriteLine(" -= Scan And Print =-");
      var doc = new ImageDocument($"JPGScan{this.ScanCounter + 1}.pdf");
      Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy H:mm:ss")} Scan  {doc.GetFileName()}");
      this.ScanCounter++;
      this.Print(doc);
      Console.WriteLine(" -= End Scan And Print =-");
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

