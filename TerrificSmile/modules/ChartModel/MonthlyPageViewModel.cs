using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrificSmile.modules.Codes;

namespace TerrificSmile.modules.ChartModel
{
    public class MonthlyPageViewModel : INotifyPropertyChanged
    {
        Income inc = new Income();
        public MonthlyPageViewModel()
        {
            inc = new Income();
            Series = new List<SeriesData>();

            Monthly = new ObservableCollection<MonthlyModelClass>();

            for (int i = 1; i <= 12; i++)
            {
                inc._computation(i.ToString(), ucontrol_monthlyIncome._comboxYear());
            }
            //Errors.Add(new TestClass() { Category = "Globalization", Number = 66 });
            //Errors.Add(new TestClass() { Category = "Features", Number = 23 });
            //Errors.Add(new TestClass() { Category = "Content Types", Number = 12 });
            //Errors.Add(new TestClass() { Category = "Correctness", Number = 94 });
            //Errors.Add(new TestClass() { Category = "Naming", Number = 45 });
            //Errors.Add(new TestClass() { Category = "Best Practices", Number = 29 });

            //Warnings.Add(new TestClass() { Category = "Globalization", Number = 34 });
            //Warnings.Add(new TestClass() { Category = "Features", Number = 23 });
            //Warnings.Add(new TestClass() { Category = "Content Types", Number = 15 });
            //Warnings.Add(new TestClass() { Category = "Correctness", Number = 66 });
            //Warnings.Add(new TestClass() { Category = "Naming", Number = 56 });
            //Warnings.Add(new TestClass() { Category = "Best Practices", Number = 34 });

            //Series.Add(new SeriesData() { DisplayName = "Errors", Items = Errors });
            //Series.Add(new SeriesData() { DisplayName = "Warnings", Items = Warnings });
        }
        

        private object selectedItem = null;
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }
        }

        public List<SeriesData> Series
        {
            get;
            set;
        }

        public ObservableCollection<MonthlyModelClass> Monthly
        {
            get;
            set;
        }


        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
