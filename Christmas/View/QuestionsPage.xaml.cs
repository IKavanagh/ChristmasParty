using Christmas.ViewModel;

namespace Christmas.View;

public partial class QuestionsPage : ContentPage
{
    public QuestionsPage(QuestionsViewModel questionsViewModel)
    {
        InitializeComponent();
        BindingContext = questionsViewModel;
    }
}