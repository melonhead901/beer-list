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

    public HtmlWriter(BeerList list, string outputPath)
    {
      this.list = new BeerList();
      this.outputPath = outputPath;
    }

    public void Write()
    {
      OpenWriter();
      WriteHeader();
      WriterCloser();
      CloseWriter();
    }

    private void WriterCloser()
    {
      this.writer.Close();
    }

    private void WriteHeader()
    {
      OpenTag("html");
    }

    private void CloseWriter()
    {
      throw new NotImplementedException();
    }

    private void OpenWriter()
    {
      this.writer = new StreamWriter(this.outputPath);
    }

    private void OpenTag(string tag)
    {
      this.writer.WriteLine("<" + tag + ">");
    }

    private void CloseTag(string tag)
    {
      this.writer.WriteLine("</" + tag + ">");
    }
  }
}
