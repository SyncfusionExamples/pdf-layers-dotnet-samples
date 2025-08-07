using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create multilingual layers in a PDF document
MultilingualLayers();
//Create a technical drawing in a PDF document
TechnicalDrawing();
static void MultilingualLayers()
{
    string englishText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
    string spanishText = "Lorem Ipsum es simplemente un texto ficticio de la industria de la impresión y la composición tipográfica. Lorem Ipsum ha sido el texto ficticio estándar de la industria desde el siglo XVI, cuando un impresor desconocido tomó una galera de tipos y la mezcló para hacer un libro de muestras tipográficas. Ha sobrevivido no solo cinco siglos, sino también el salto a la composición tipográfica electrónica, permaneciendo esencialmente sin cambios. Se popularizó en los años 60 con la publicación de hojas de Letraset que contenían pasajes de Lorem Ipsum, y más recientemente con software de autoedición como Aldus PageMaker, que incluye versiones de Lorem Ipsum.";
    string frenchText = "Lorem Ipsum est simplement un faux texte utilisé dans l'industrie de l'impression et de la composition. Il est le texte factice standard de l'industrie depuis les années 1500, lorsqu'un imprimeur inconnu prit une galère de caractères et la brouilla pour créer un spécimen de livre. Il a survécu non seulement à cinq siècles, mais aussi au passage à la composition électronique, restant essentiellement inchangé. Il a été popularisé dans les années 1960 avec la sortie des feuilles Letraset contenant des passages de Lorem Ipsum, et plus récemment avec des logiciels de publication assistée par ordinateur comme Aldus PageMaker incluant des versions de Lorem Ipsum.";

    using (PdfDocument document = new PdfDocument())
    {
        // Create a new PDF document
        PdfPage page = document.Pages.Add();

        // Create a font for the text
        PdfTrueTypeFont font = new PdfTrueTypeFont("data/arial.ttf", 12);

        // Create language - specific layers
        PdfLayer englishLayer = document.Layers.Add("English");

        // Add English text to the English layer
        AddTextToLayer(page, englishLayer, englishText, font);

        // Add Spanish text to the Spanish layer
        PdfLayer spanishLayer = document.Layers.Add("Español");
        spanishLayer.Visible = false;

        // Add Spanish text to the Spanish layer
        AddTextToLayer(page, spanishLayer, spanishText, font);

        // Add French text to the French layer
        PdfLayer frenchLayer = document.Layers.Add("Français");
        frenchLayer.Visible = false;

        // Add French text to the French layer
        AddTextToLayer(page, frenchLayer, frenchText, font);

        //Save the document to a file
        document.Save("MultilingualLayers.pdf");
    }
}

static void AddTextToLayer(PdfPage page, PdfLayer layer, string text, PdfFont font)
{
    // Create a graphics object for the layer
    PdfGraphics graphics = layer.CreateGraphics(page);

    // Draw the text on the specified layer
    graphics.DrawString(text, font, PdfBrushes.Black, new RectangleF(0, 0, page.GetClientSize().Width, 200));
}

static void TechnicalDrawing()
{
    // Create a new PDF document for technical drawing
    using (PdfDocument document = new PdfDocument())
    {
        // Add a new page to the document
        PdfPage page = document.Pages.Add();

        // Basic layout layer
        PdfPageLayer layoutLayer = page.Layers.Add("Basic Layout");
        layoutLayer.Graphics.DrawRectangle(PdfBrushes.Gray, new RectangleF(50, 50, 200, 100));

        // Electrical layer
        PdfPageLayer electricalLayer = page.Layers.Add("Electrical");
        electricalLayer.Graphics.DrawLine(new PdfPen(Color.Red, 2), new PointF(60, 60), new PointF(180, 60));

        // Plumbing layer
        PdfPageLayer plumbingLayer = page.Layers.Add("Plumbing");
        plumbingLayer.Graphics.DrawEllipse(PdfBrushes.Blue, new RectangleF(70, 70, 50, 50));

        // Save document
        document.Save("TechnicalDrawing.pdf");
        document.Close(true);
    }
}
