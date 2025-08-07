using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Add a page to the document
    PdfPage page = document.Pages.Add();

    // Create parent layer group
    PdfLayer engineeringGroup = document.Layers.Add("Engineering");

    // Create child layers
    PdfLayer mechanicalLayer = engineeringGroup.Layers.Add("Mechanical");

    // Add content to mechanical layer
    PdfGraphics mechanicalLayerGraphics = mechanicalLayer.CreateGraphics(page);
    mechanicalLayerGraphics.DrawRectangle(PdfBrushes.Blue, new RectangleF(50, 50, 100, 50));

    // Create child layers
    PdfLayer electricalLayer = engineeringGroup.Layers.Add("Electrical");

    // Add content to electrical layer
    PdfGraphics electricalLayerGraphics = electricalLayer.CreateGraphics(page);
    electricalLayerGraphics.DrawEllipse(PdfBrushes.Yellow, new RectangleF(200, 50, 100, 50));

    // Create child layers
    PdfLayer plumbingLayer = engineeringGroup.Layers.Add("Plumbing");

    // Add content to plumbing layer
    PdfGraphics plumbingLayerGraphics = plumbingLayer.CreateGraphics(page);
    plumbingLayerGraphics.DrawLine(new PdfPen(Color.Green, 3), new PointF(50, 150), new PointF(300, 150));

    // Save the document to a file
    document.Save("NestedLayers.pdf");
}