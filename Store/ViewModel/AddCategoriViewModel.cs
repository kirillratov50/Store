using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Store.Model.Models;
using Store.Model;

namespace Store.ViewModel.AddViewModel
{
    internal class AddCategoriViewModel : NotifyPropertyChanged
    {
        private MainViewModel _mainViewModel;
        public AddCategoriViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private string _name; 
        public string Name
        {
            get { return _name;  }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _info;
        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;
                OnPropertyChanged("Info");
            }
        }

        private RelayCommand _addCategoriCommand;
        public RelayCommand AddCategoriCommand
        {
            get
            {
                if(_addCategoriCommand == null)
                {
                    _addCategoriCommand = new RelayCommand((o) =>
                    {
                        if(DataWorker.createCategori(Name, Info) == true)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                            Name = null;
                            Info = null;
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");
                        }
                    });
                }
                return _addCategoriCommand;
            }
        }


    }
}
