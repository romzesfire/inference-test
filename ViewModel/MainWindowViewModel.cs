using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestInference.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SpecificationNodeViewModel> _specificationNodes;

        public ObservableCollection<SpecificationNodeViewModel> SpecificationNodes
        {
            get
            {
                return _specificationNodes;
            }
            set
            {
                _specificationNodes = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
