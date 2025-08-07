using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

string text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum";

//Create new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add page.
    PdfPage page = document.Pages.Add();

    //Draw some text.
    page.Graphics.DrawString(text, new PdfStandardFont(PdfFontFamily.Helvetica, 12), PdfBrushes.Black, new RectangleF(0, 0, page.GetClientSize().Width, page.GetClientSize().Height));

    //Add the layer.
    PdfLayer layer = document.Layers.Add("Annotation Layer");    

    //Create square annotation.
    PdfSquareAnnotation annotation = new PdfSquareAnnotation(new RectangleF(200, 50, 50, 50), "Square annotation");

    //Set the annotation color.
    annotation.Color = new PdfColor(Syncfusion.Drawing.Color.Red);

    //Set layer to annotation.
    annotation.Layer = layer;

    //Add annotation to the created page.
    page.Annotations.Add(annotation);

    //Save the document
    document.Save("AnnotationOnLayer.pdf");
}
