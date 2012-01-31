using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace TwoViews.ViewModels
{
    /// <summary>
    /// This is our MainViewModel that is tied to the MainWindow via the 
    /// ViewModelLocator class.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The current view.
        /// </summary>
        private ViewModelBase _currentViewModel;

        /// <summary>
        /// Static instance of one of the ViewModels.
        /// </summary>
        readonly static SecondViewModel _secondViewModel = new SecondViewModel();


        /// <summary>
        /// Static instance of one of the ViewModels.
        /// </summary>
        readonly static FirstViewModel _firstViewModel = new FirstViewModel();


        /// <summary>
        /// The CurrentView property.  The setter is private since only this 
        /// class can change the view via a command.  If the View is changed,
        /// we need to raise a property changed event (via INPC).
        /// </summary>
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        /// <summary>
        /// Simple property to hold the 'FirstViewCommand' - when executed
        /// it will change the current view to the 'FirstView'
        /// </summary>
        public ICommand FirstViewCommand { get; private set; }

        /// <summary>
        /// Simple property to hold the 'SecondViewCommand' - when executed
        /// it will change the current view to the 'SecondView'
        /// </summary>
        public ICommand SecondViewCommand { get; private set; }

        /// <summary>
        /// Default constructor.  We set the initial view-model to 'FirstViewModel'.
        /// We also associate the commands with their execution actions.
        /// </summary>
        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._firstViewModel;
            FirstViewCommand = new RelayCommand(() => ExecuteFirstViewCommand());
            SecondViewCommand = new RelayCommand(() => ExecuteSecondViewCommand());
        }         

        /// <summary>
        /// Set the CurrentViewModel to 'FirstViewModel'
        /// </summary>
        private void ExecuteFirstViewCommand()
        {
            CurrentViewModel = MainViewModel._firstViewModel;
        }

        /// <summary>
        /// Set the CurrentViewModel to 'SecondViewModel'
        /// </summary>
        private void ExecuteSecondViewCommand()
        {
            CurrentViewModel = MainViewModel._secondViewModel;
        }
    }
}
