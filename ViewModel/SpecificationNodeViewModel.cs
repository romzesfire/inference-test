using Medzoom.CDSS.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Medzoom.CDSS.Common.CodeSystemReplacements;
using TestInference.Utils;

namespace TestInference.ViewModel
{
    public enum NodeType
    {
        Model,
        Specification
    }
    public class SpecificationNodeViewModel : INotifyPropertyChanged
    {
        private string _code;
        private string _name;
        private Coding _coding;
        private ObservableCollection<StateViewModel> _states;

        public Coding Coding 
        {
            get
            {
                return _coding;
            }
            set
            {
                _coding = value;
                OnPropertyChanged();
            }
        }
        public string Code 
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }

        }
        public List<string> NameSynonyms { get; set; }
        public NodeType NodeType { get; set; }

        public ObservableCollection<StateViewModel> States
        {
            get => _states;
            set
            {
                _states = value;
                OnPropertyChanged();
            } 
        }

        public SpecificationNodeViewModel(Coding code, NodeType nodeType = NodeType.Specification, List<string>? synonyms = null)
        {
            Code = Services.Services.GetService<ICodesConverter>().CodingToShort(code);
            Name = Services.Services.GetService<IDesignationsProvider>().GetDesignation(code);
            NodeType = nodeType;
            NameSynonyms = synonyms ?? new List<string>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
