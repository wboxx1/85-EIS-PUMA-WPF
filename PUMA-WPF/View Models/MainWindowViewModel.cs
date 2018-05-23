using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace PUMA_WPF.View_Models
{
    
    public class MainWindowViewModel : BindableBase
    {        
        public MainWindowViewModel()
        {            
            this.StartNewSurveyCommand = new DelegateCommand(this.StartNewSurvey);
            this.InteractionRequest = new InteractionRequest<Confirmation>();
        }

        private string _title = "Puma Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public InteractionRequest<Confirmation> InteractionRequest { get; }
        public ICommand StartNewSurveyCommand { get; }
        public void StartNewSurvey()
        {
            // Use this to open New Survey View
            this.InteractionRequest.Raise(
                new Confirmation
                {
                    Title = "Confirm",
                    Content = "Do you want to continue?",
                },
                OnWindowClosed);
        }

        private void OnWindowClosed(Confirmation confirmation)
        {
            if (confirmation.Confirmed)
            {
                //perform the confirmed action...
                System.Windows.MessageBox.Show("Worked");
            }
            else
            {

            }
        }

    }

}
