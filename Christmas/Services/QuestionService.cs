using Christmas.Model;

namespace Christmas.Services;
public class QuestionService : BaseService
{
    #region Configuration Parameters
    private static string QuestionsUrl => "questions.json";
    #endregion

    public async Task<List<Question>> GetQuestions()
    {
        return await GetAsync<List<Question>>(QuestionsUrl);
    }
}