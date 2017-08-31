namespace LoginApp
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly LoginViewModel loginViewModel = new LoginViewModel();
        private readonly ContentViewModel contentViewModel = new ContentViewModel();
        private object currentViewModel;

        public MainViewModel()
        {
            this.currentViewModel = this.loginViewModel;
            this.LoginCommand = new RelayCommand(
                _ => this.CurrentViewModel = this.contentViewModel,
                _ => !ReferenceEquals(this.currentViewModel, this.contentViewModel));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoginCommand { get; }

        public object CurrentViewModel
        {
            get => this.currentViewModel;
            set
            {
                if (ReferenceEquals(this.currentViewModel, value))
                {
                    return;
                }

                this.currentViewModel = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}