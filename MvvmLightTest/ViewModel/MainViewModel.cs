//  Example code only, feel free to copy and re-use.

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows;

namespace MvvmLightTest.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ShowPopUp = new RelayCommand(() => ShowPopUpExecute(), () => true);
            IncrementValue = new RelayCommand(() => IncrementValueExecute(), () => true);
            ExampleValue = 0;
        }

        public ICommand ShowPopUp { get; private set; }

        public ICommand IncrementValue { get; private set; }

        private void ShowPopUpExecute()
        {
            MessageBox.Show("Hello World!");
        }

        private void IncrementValueExecute()
        {
            ExampleValue += 1;
        }

        int _exampleValue;

        public int ExampleValue
        {
            get
            {
                return _exampleValue;
            }
            set
            {
                if (_exampleValue == value)
                    return;
                _exampleValue = value;
                RaisePropertyChanged("ExampleValue");
            }
        }

    }
}