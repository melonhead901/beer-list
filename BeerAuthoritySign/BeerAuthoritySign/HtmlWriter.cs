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
      this.list = new BeerList();
      this.outputPath = outputPath;
      this.indentLevel = 0;
    }

    public void Write()
    {
      OpenWriter();
      OpenHtml();
      CloseHtml();
      CloseWriter();
    }

    private void CloseHtml()
    {
      CloseTag("html");
    }

    private void OpenHtml()
    {
      OpenTag("html");
    }

    private void CloseWriter()
    {
      this.writer.Close();
    }

    private void OpenWriter()
    {
      this.writer = new StreamWriter(this.outputPath);
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

    private void OpenTag(string tag, params string[] attributes)
    {
      WriteIndents();
      StringBuilder builder = new StringBuilder();
      builder.Append("<" + tag + " ");
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
  }
}
