using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Modularity;
using Prism.Mvvm;
using PumaWpf.Modules.Survey;
using PumaWpf.Notifications;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace PumaWpf.ViewModels
{
    
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Puma Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public InteractionRequest<INewSurveyNotification> NewSurveyNotificationRequest { get; set; }
        public DelegateCommand StartNewSurveyCommand { get; set; }

        private ModuleManager _moduleManager;


        public MainWindowViewModel(ModuleManager moduleManager)
        {            
            StartNewSurveyCommand = new DelegateCommand(this.StartNewSurvey);
            NewSurveyNotificationRequest = new InteractionRequest<INewSurveyNotification>();
            _moduleManager = moduleManager;
        }

        


        public void StartNewSurvey()
        {
            // Use this to open New Survey View
            this.NewSurveyNotificationRequest.Raise(new NewSurveyNotification { Title = "Custom Notification" }, r =>
            {
                if (r.Confirmed && r.SelectedMission != null)
                {
                    Title = $"User selected: { r.SelectedMission}";
                    LoadSurveyModule();
                }

                else
                    Title = "User cancelled or didn't select an item";
            });
        }

        private void LoadSurveyModule()
        {
            // Load Survey View
            _moduleManager.LoadModule(typeof(SurveyModule).Name);
            // Create event to load all Survey Views
            //this.eventAggregator.GetEvent<LoadAllSurveyViewsEvent>().Publish(null); 
            // Load Header Region

            // Load Action Region

            // Load 
        }                

    }

}
