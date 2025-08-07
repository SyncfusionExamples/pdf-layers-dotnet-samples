using Syncfusion.Pdf.Parsing;

// This example demonstrates how to flatten or remove layers from a PDF document using Syncfusion's PDF library.
FlattenOrRemoveLayers(false);

// Remove layer with its graphical content
FlattenOrRemoveLayers(true);

// Function to flatten or remove layers from a PDF document
static void FlattenOrRemoveLayers(bool removeGraphicalContent)
{
    //Load the PDF document
    using (PdfLoadedDocument document = new PdfLoadedDocument("data/Layers.pdf"))
    {
        //Remove layers from the PDF document
        for (int i = document.Layers.Count - 1; i >= 0; i--)
        {
            document.Layers.RemoveAt(i, removeGraphicalContent);
        }

        //Save the modified PDF document
        document.Save(removeGraphicalContent ? "RemoveLayerWithGraphics.pdf" : "RemoveLayers.pdf");

        //Close the PDF file
        document.Close(true);
    }
}
