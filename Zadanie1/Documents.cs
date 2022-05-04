abstract class AbstractDocument {

  public AbstractDocument(string input) {
     this.ChangeFileName(input);
  }
  private string fileName { get; set; }

  public void ChangeFileName(string input) {
    this.fileName = input;
  }

  public string GetFileName() {
    return this.fileName;
  }

}

class PDFDocument: AbstractDocument, IDocument {

    public PDFDocument(string input) : base(input) {
  }
  public FormatType GetFormatType() {
    return FormatType.PDF;
  }
  
 }

class TextDocument: AbstractDocument, IDocument {
      public TextDocument(string input) : base(input) {
  }
  public FormatType GetFormatType() {
    return FormatType.TXT;
  }
  
 }

class ImageDocument: AbstractDocument, IDocument {
      public ImageDocument(string input):base(input){
  }
  public FormatType GetFormatType() {
    return FormatType.JPG;
  }
  
 }

interface IDocument {
   string GetFileName();
   FormatType GetFormatType();
 }

enum FormatType {
   TXT,
   PDF,
   JPG
 }
