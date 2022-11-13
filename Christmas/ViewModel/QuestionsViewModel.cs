using Christmas.Model;
using Christmas.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Christmas.ViewModel;

public partial class QuestionsViewModel : BaseViewModel
{
    public ObservableCollection<Question> Questions { get; } = new();

    private readonly QuestionService questionService;

    public QuestionsViewModel(QuestionService questionService)
    {
        Title = "Frequently Asked Questions";

        this.questionService = questionService;
    }

    [RelayCommand]
    private async void GetEvents()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = !IsRefreshing;

            await Task.Delay(1); // Hack to make activity indicator display until GetEvents is async

            var questions = questionService.GetQuestions();
            if (questions.Count != 0)
            {
                Questions.Clear();
            }

            foreach (var question in questions)
            {
                Questions.Add(question);
            }
        }
        catch (Exception ex)
        {
            // TODO: Add better error handling
            Debug.WriteLine($"Unable to get events: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }
}
