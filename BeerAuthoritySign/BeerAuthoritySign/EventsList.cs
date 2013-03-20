using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

    /// <summary>
    /// Attempt to load the event list from the given path. Returns a blank event list if none 
    /// could be loaded.
    /// </summary>
    /// <param name="path">Path of the file to load the event list from</param>
    /// <returns></returns>
    internal static EventsList LoadEventsList(string path)
    {
      try
      {
        var text = File.ReadAllText(path);
        return new EventsList() { EventsText = text };
      }
      catch
      {
        return new EventsList();
      }
    }

    /// <summary>
    /// Write the contents of this events list to the file at the given path.
    /// </summary>
    /// <param name="path">Path of the file to write the events to</param>
    /// <returns>True if the file could be written, otherwise fase</returns>
    internal bool SaveToFile(string path)
    {
      try
      {
        File.WriteAllText(path, this.EventsText);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
