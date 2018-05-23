using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PumaWpf.Modules.Survey.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PumaWpf.Modules.Survey.ViewModels
{
    public class NewSurveyViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public NewSurveyViewModel(EventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.RunSurveyCommand = new DelegateCommand(this.RunSurvey);
        }

        protected readonly IEventAggregator eventAggregator;
        public ICommand RunSurveyCommand { get; }
        public void RunSurvey()
        {
            // Create event to load all Survey Views
            this.eventAggregator.GetEvent<LoadAllSurveyViewsEvent>().Publish(null); 
            // Load Header Region

            // Load Action Region

            // Load 
        }
    }
}
