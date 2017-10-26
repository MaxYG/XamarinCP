﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinCP.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
