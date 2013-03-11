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

    private double abv;

    public double ABV
    {
      get { return abv; }
      set { abv = value; OnNotifyPropertyChanged("ABV"); }
    }


    private double growlerPrice;
    public double GrowlerPrice
    {
      get { return growlerPrice; }
      set { growlerPrice = value; OnNotifyPropertyChanged("GrowlerPrice"); }
    }

    private double pintPrice;
    public double PintPrice
    {
      get { return pintPrice; }
      set { pintPrice = value; OnNotifyPropertyChanged("PintPrice"); }
    }

    private string kind;

    public string Kind
    {
      get { return kind; }
      set { kind = value; OnNotifyPropertyChanged("Kind");  }
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
