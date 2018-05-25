using Prism.Interactivity.InteractionRequest;

namespace PumaWpf.Notifications
{
    public interface INewSurveyNotification : IConfirmation
    {
        string SelectedMission { get; set; }
    }
}
