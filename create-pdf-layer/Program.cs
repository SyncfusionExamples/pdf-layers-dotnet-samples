using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NRAiBiAaIQQuGjN/VkZ+XU9FfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hTH5Vd0ViUH5XdXxdT2dYWkd2");

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    //Set page margin as zero
    document.PageSettings.Margins.All = 0;

    // Add a new page to the document
    PdfPage page = document.Pages.Add();

    // Create the first layer for background content
    PdfPageLayer backgroundLayer = page.Layers.Add("Background");

    // Add background content
    PdfBrush backgroundBrush = new PdfSolidBrush(Color.LightBlue);
    backgroundLayer.Graphics.DrawRectangle(backgroundBrush, new RectangleF(0, 0, page.Size.Width, page.Size.Height));

    // Create a layer for main content
    PdfPageLayer mainContentLayer = page.Layers.Add("Main Content");
    // Add main content
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
    PdfBrush textBrush = new PdfSolidBrush(Color.Black);
    mainContentLayer.Graphics.DrawString("Welcome to PDF Layers!", font, textBrush, new PointF(50, 50));

    //S the document with layers
    document.Save("LayeredDocument.pdf");
}

