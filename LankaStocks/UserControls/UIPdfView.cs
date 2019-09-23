using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Grid;
using Spire.Pdf.Graphics;

namespace LankaStocks.UserControls
{
    public partial class UIPdfView : UserControl
    {
        public UIPdfView()
        {
            InitializeComponent();
        }
        private static void InsertImageIntoPDF()
        {

            string outputFile = @"..\..\output.pdf";
            
            //Create a pdf document

            PdfDocument doc = new PdfDocument();
           
            //Add a page for the pdf document

            PdfPageBase page = doc.Pages.Add();
            
            //Create a pdf grid

            PdfGrid grid = new PdfGrid();
            
            //Set the cell padding of pdf grid

            grid.Style.CellPadding = new PdfPaddings(1, 1, 1, 1);
           
            //Add a row for pdf grid
            PdfGridRow row = grid.Rows.Add();
            
            //Add two columns for pdf grid
            grid.Columns.Add(2);
            
            float width = page.Canvas.ClientSize.Width - (grid.Columns.Count + 1);
            
            //Set the width of the first column

            grid.Columns[0].Width = width * 0.25f;
            
            grid.Columns[1].Width = width * 0.25f;
            
            //Add a image

            PdfGridCellContentList lst = new PdfGridCellContentList();
            
            PdfGridCellContent textAndStyle = new PdfGridCellContent();
           
            textAndStyle.Image = PdfImage.FromFile("..\\..\\image1.jpg");
           
            //Set the size of image
            textAndStyle.ImageSize = new SizeF(50, 50);
            
            lst.List.Add(textAndStyle);
            
            //Add a image into the first cell.
            row.Cells[0].Value = lst;
           
            //Draw pdf grid into page at the specific location
            PdfLayoutResult result = grid.Draw(page, new PointF(10, 30));
           
            //Save to a pdf file
            doc.SaveToFile(outputFile, FileFormat.PDF);
          
            System.Diagnostics.Process.Start(outputFile);

        }
    }
}
