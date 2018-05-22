using Prism.Mvvm;

namespace PUMA_WPF.View_Models
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Puma Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
