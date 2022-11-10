using Christmas.Model;

namespace Christmas.Services;

public class QuestionService
{
    public List<Question> GetQuestions()
    {
        return new List<Question>
        {
            new Question
            {
                Id = Guid.NewGuid(),
                Title = "What is the dress code?",
                Answer = "The dress code for the Christmas Conference is business casual. The dress code for the Christmas Party is smart."
            },
        };
    } 
}

