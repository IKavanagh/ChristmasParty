using CommunityToolkit.Mvvm.ComponentModel;

namespace Christmas.ViewModel;
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string title;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;
    
    [ObservableProperty]
    private bool isRefreshing;

    public bool IsNotBusy => !IsBusy;
}
