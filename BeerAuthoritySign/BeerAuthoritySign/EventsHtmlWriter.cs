using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAuthoritySign
{
  class EventsHtmlWriter : HtmlWriter
  {
    public string EventsText { get; private set; }

    public EventsHtmlWriter(string path, string eventstext) : base(path)
    {
      this.EventsText = eventstext;
    }

    protected override void WriteBody()
    {
      base.WriteList(EventsText.Split('\n').ToList<string>());
    }

    protected override void WriteHead()
    {
      OpenTag("head");
      OneLineTag("title", "Beer Authority");
      SelfClosingTag("link", "rel=\"stylesheet\"", "type=\"text/css\"", "href=\"events.css\"");
      CloseTag("head");
    }
  }
}
