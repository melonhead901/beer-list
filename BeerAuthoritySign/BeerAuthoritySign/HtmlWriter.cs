using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAuthoritySign
{
  class HtmlWriter
  {

    private BeerList list;
    private StreamWriter writer;
    private string outputPath;
    private int indentLevel;

    public HtmlWriter(BeerList list, string outputPath)
    {
      this.list = list;
      this.outputPath = outputPath;
      this.indentLevel = 0;
    }

    public void Write()
    {
      OpenWriter();
      OpenHtml();

      WriteHead();
      WriteBody();

      CloseHtml();
      CloseWriter();
    }

    #region Body Writing

    private void WriteBody()
    {
      OpenTag("body");

      WriteTable();

      CloseTag("body");
    }

    #region Table Writing

    private void WriteHeaderRow()
    {
      OpenTag("tr");
      WriteTableData("Name");
      WriteTableData("Brewery");
      WriteTableData("Kind");
      WriteTableData("ABV");
      WriteTableData("Pint");
      WriteTableData("Growler");
      CloseTag("tr");
    }

    private void WriteTable()
    {
      OpenTag("table");

      WriteHeaderRow();
      WriteBeerRows();

      CloseTag("table");
    }

    private void WriteBeerRows()
    {
      //throw new NotImplementedException();
      foreach (var beer in this.list.Beers)
      {
        WriteBeer(beer);
      }
    }

    private void WriteBeer(Beer beer)
    {
      OpenTag("tr");
      WriteTableData(beer.Name);
      WriteTableData(beer.Brewery);
      WriteTableData(beer.Kind);
      WriteTableData(beer.ABV.ToString());
      WriteTableData(beer.PintPrice.ToString());
      WriteTableData(beer.GrowlerPrice.ToString());
      CloseTag("tr");
    }

    private void WriteTableData(string p)
    {
      WriteIndents();
      writer.WriteLine("<td>" + p + "</td>");
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

    private void CloseHtml()
    {
      CloseTag("html");
    }

    private void OpenHtml()
    {
      OpenTag("html", " xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"en\" lang=\"en\"");
    }

    private void CloseWriter()
    {
      this.writer.Close();
    }

    private void OpenWriter()
    {
      this.writer = new StreamWriter(this.outputPath);
      writer.WriteLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">");
    }

    private void WriteIndents()
    {
      StringBuilder builder = new StringBuilder();
      for (int i = 0; i < indentLevel; i++)
      {
        builder.Append("\t");
      }
      writer.Write(builder);
    }

    #region Tag Management

    private void SelfClosingTag(string tag, params string[] attributes)
    {
      WriteIndents();
      StringBuilder builder = new StringBuilder();
      builder.Append("<" + tag + " ");

      for (int i = 0; i < attributes.Length; i++)
      {
        builder.Append(attributes[i] + " ");
      }

      // Remove last space
      builder.Remove(builder.Length - 1, 1);
      builder.Append("/>");
      this.writer.WriteLine(builder.ToString());
    }

    private void OneLineTag(string tag, string value)
    {
      WriteIndents();
      writer.Write("<" + tag + ">");
      writer.Write(value);
      writer.Write("</" + tag + ">");
      writer.WriteLine();
    }

    private void OpenTag(string tag, params string[] attributes)
    {
      WriteIndents();
      StringBuilder builder = new StringBuilder();
      builder.Append("<" + tag + " ");

      for (int i = 0; i < attributes.Length; i++)
      {
        builder.Append(attributes[i] + " ");
      }

      // Remove last space
      builder.Remove(builder.Length - 1, 1);
      builder.Append(">");
      this.writer.WriteLine(builder.ToString());
      indentLevel++;
    }

    private void CloseTag(string tag)
    {
      indentLevel--;
      WriteIndents();
      this.writer.WriteLine("</" + tag + ">");
    }

    #endregion
  }
}
