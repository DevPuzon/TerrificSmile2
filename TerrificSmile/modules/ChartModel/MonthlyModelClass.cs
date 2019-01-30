using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrificSmile.modules.ChartModel
{
    public class SeriesData
    {
        public ObservableCollection<MonthlyModelClass> ItemsMonthly { get; set; }
    }

    public class MonthlyModelClass : INotifyPropertyChanged
    {
        public string Month { get; set; }

        private float _number = 0;
        public float Income
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Income"));
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
