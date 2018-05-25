using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using Prism.Interactivity.InteractionRequest;
using PumaWpf.Notifications;

namespace PumaWpf.ViewModels
{
    public class NewSurveyViewModel : BindableBase, IInteractionRequestAware
    {
        public string SelectedMission { get; set; }

        public DelegateCommand LoadSurveyCommand { get; private set; }

        public DelegateCommand CancelCommand { get; private set; }

        protected readonly IEventAggregator eventAggregator;
        private ModuleManager _modulemanager;
        
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public NewSurveyViewModel(EventAggregator eventAggregator, ModuleManager moduleManager)
        {
            this.eventAggregator = eventAggregator;
            _modulemanager = moduleManager;

            this.LoadSurveyCommand = new DelegateCommand(this.LoadSurvey);
            this.CancelCommand = new DelegateCommand(this.Cancel);
        }

        private void Cancel()
        {
            _notification.SelectedMission = null;
            _notification.Confirmed = false;
            FinishInteraction?.Invoke();
        }

        public void LoadSurvey()
        {
            _notification.SelectedMission = SelectedMission;
            _notification.Confirmed = true;
            FinishInteraction?.Invoke();           
        }

        public Action FinishInteraction { get; set; }

        private INewSurveyNotification _notification;

        public INotification Notification
        {
            get { return _notification; }
            set { SetProperty(ref _notification, (INewSurveyNotification)value); }
        }


        
    }    
}
