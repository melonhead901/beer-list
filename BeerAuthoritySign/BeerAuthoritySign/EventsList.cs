using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BeerAuthoritySign
{
  class EventsList : INotifyPropertyChanged
  {
    private string eventsText;

    public string EventsText
    {
      get { return this.eventsText; }
      set { this.eventsText = value; this.OnNotifyPropertyChanged("EventsText"); }
    }


    #region INotifyPropertyChanged Members

    private void OnNotifyPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    internal static EventsList LoadEventsList(string p)
    {
      // TODO
      // throw new NotImplementedException();
      return new EventsList();
    }

    internal static void Save(string p)
    {
      throw new NotImplementedException();
    }
  }
}
