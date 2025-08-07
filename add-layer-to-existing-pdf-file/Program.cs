using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;

//Load the PDF document
using (var loadedDocument = new PdfLoadedDocument("data/input.pdf"))
{
    // Find the first text and create the parent layer
    loadedDocument.FindText("PDF Succinctly", 0, out var matchRect);
    PdfLayer? parentLayer = null;

    if (matchRect != null && matchRect.Count > 0)
    {
        parentLayer = AddLayer(loadedDocument, "PDF Succinctly", matchRect[0], PdfBrushes.Red, null);

        // Subsequent texts as children of the parent layer
        var childTexts = new[]
        {
            new { Text = "Introduction", Brush = PdfBrushes.Green },
            new { Text = "The PDF Standard", Brush = PdfBrushes.Blue }
        };

        foreach (var item in childTexts)
        {
            loadedDocument.FindText(item.Text, 0, out var childRect);
            if (childRect != null && childRect.Count > 0)
            {
                AddLayer(loadedDocument, item.Text, childRect[0], item.Brush, parentLayer);
            }
        }
    }

    loadedDocument.Save("AddLayers.pdf");
}

PdfLayer AddLayer(PdfLoadedDocument loadedDocument, string layerName, RectangleF rect, PdfBrush brush, PdfLayer? parentLayer)
{
    var layer = parentLayer == null ? loadedDocument.Layers.Add(layerName) : parentLayer.Layers.Add(layerName);
    var graphics = layer.CreateGraphics(loadedDocument.Pages[0] as PdfLoadedPage);

    graphics.Save();
    graphics.SetTransparency(0.5f);
    graphics.DrawRectangle(brush, rect);
    graphics.Restore();

    return layer;
}