using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAuthoritySign
{
  class BeerListHtmlWriter : HtmlWriter
  {
    private BeerList list;
        
    public BeerListHtmlWriter(BeerList list, string outputPath) : base(outputPath)
    {
      this.list = list;
    }
    

    #region Body Writing
    
    protected override void WriteBody()
    {
      OpenTag("body");

      WriteBanner();
      WriteTable();

      CloseTag("body");
    }
    
    private void WriteBanner()
    {
      OneLineTag("h1 class=\"center\"", "Beer On Tap");
    }

    #region Table Writing

    private void WriteTable()
    {
      OpenTag("table");

      WriteTableHeaderRow();
      WriteBeerRows();

      CloseTag("table");
    }

    private void WriteTableHeaderRow()
    {
      OpenTag("tr class=\"headerRow\"");
      WriteTableData("");
      WriteTableData("ABV");
      WriteTableData("Glass");
      WriteTableData("Growler");
      CloseTag("tr");
    }

    private void WriteBeerRows()
    {
      bool even = false;
      foreach (var beer in this.list.Beers)
      {
        WriteBeer(beer, even ? "even" : "odd");
        even = !even;
      }
    }

    private void WriteBeer(Beer beer, string rowClass)
    {
      if (beer.Name == "") { return;  }
      OpenTag("tr", "class", rowClass);
      WriteTableData(beer.Name + " " + beer.Brewery + " " + beer.Kind);
      WriteTableData(String.Format("{0:P1}", beer.ABV/100));
      WriteTableData(String.Format("{0:C2}", beer.PintPrice));
      WriteTableData(String.Format("{0:C2}", beer.GrowlerPrice));
      CloseTag("tr");
    }

    #endregion

    #endregion

    #region Header Writing

    private void WriteHead()
    {
      OpenTag("head");
      OneLineTag("title", "Beer Authority");
      SelfClosingTag("link", "rel=\"stylesheet\"", "type=\"text/css\"", "href=\"beerlist.css\"");
      CloseTag("head");
    }

    #endregion
  }
}
