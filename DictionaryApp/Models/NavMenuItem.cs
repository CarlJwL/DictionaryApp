using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DictionaryApp.Models
{
    class NavMenuItem : INotifyPropertyChanged
    {
        public String Label { set; get; }
        public Symbol Symbol { set; get; }
        public Type DestinationPage { set; get; }
        public Object Description { set; get; }
        public Visibility SelectedVis { get; set; }
        public char SymbolAsChar => (char)this.Symbol;

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                SelectedVis = value ? Visibility.Visible : Visibility.Collapsed;
                this.OnPropertyChanged("IsSelected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged(string propertyName) => this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

    }
}
