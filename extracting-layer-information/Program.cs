using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document
PdfLoadedDocument document = new PdfLoadedDocument("data/Layers.pdf");

Console.WriteLine($"Total layers: {document.Layers.Count}");

//Extract layer information
foreach (PdfLayer layer in document.Layers)
{    
    Console.WriteLine($"Layer Name: {layer.Name}");
    Console.WriteLine($"Visible: {layer.Visible}");
    Console.WriteLine($"Print: {layer.PrintState.ToString()}");
    Console.WriteLine($"Locked: {layer.Locked}");
    Console.WriteLine("---");
}

//Close the PDF file
document.Close(true);