using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;


using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument("data/Layers.pdf"))
{
    //Get layers
    PdfDocumentLayerCollection layerCollection = loadedDocument.Layers;

    if(layerCollection != null  && layerCollection.Count > 0)
    {
       //Get the first layer
       PdfLayer layer1= layerCollection[0];

        //Modify the visibility of the layer
        layer1.Visible = false;

        //Set the print state of the layer
        layer1.PrintState = PdfPrintState.PrintWhenVisible;

        //Get the second layer and rename it
        PdfLayer layer2= layerCollection[1];

        //Rename the layer
        layer2.Name = "Renamed Layer";

        //Get the layer3
        PdfLayer layer3 = layerCollection[2];

        //Lock the layer
        layer3.Locked = true;      
    }
    // Save the document
    loadedDocument.Save("LayerCustomization.pdf");
}
