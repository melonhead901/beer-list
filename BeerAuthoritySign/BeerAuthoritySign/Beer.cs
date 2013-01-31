using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAuthoritySign
{
  [Serializable]
  class Beer : INotifyPropertyChanged
  {
    private string name;
    public string Name
    {
      get { return this.name; }
      set { this.name = value; OnNotifyPropertyChanged("Name"); }
    }

    private string brewery;
    public string Brewery
    {
      get { return brewery; }
      set { brewery = value; OnNotifyPropertyChanged("Brewery"); }
    }

    private double schoonerPrice;
    public double SchoonerPrice
    {
      get { return schoonerPrice; }
      set { schoonerPrice = value; OnNotifyPropertyChanged("SchoonerPrice"); }
    }

    private double pintPrice;
    public double PintPrice
    {
      get { return pintPrice; }
      set { pintPrice = value; OnNotifyPropertyChanged("PintPrice"); }
    }

    #region INotifyPropertyChanged Members

    private void OnNotifyPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    [field:NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

  }
}
