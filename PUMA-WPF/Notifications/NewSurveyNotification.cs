using Prism.Interactivity.InteractionRequest;
using System.Collections.Generic;

namespace PumaWpf.Notifications
{
    public class NewSurveyNotification : Confirmation, INewSurveyNotification
    {
        public IList<string> Missions { get; private set; }
        public string SelectedMission { get; set; }

        public NewSurveyNotification()
        {
            this.Missions = new List<string>();
            this.SelectedMission = null;
            BuildMissionList();
        }

        void BuildMissionList()
        {
            this.Missions.Add("mission1");
            this.Missions.Add("mission2");
            this.Missions.Add("mission3");
        }
    }
}
