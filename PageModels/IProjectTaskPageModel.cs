using CommunityToolkit.Mvvm.Input;
using UI1.Models;

namespace UI1.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}