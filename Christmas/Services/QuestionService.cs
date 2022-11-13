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
            new Question
            {
                Id = Guid.NewGuid(),
                Title = "Where does the Azyra Christmas Conference take place?",
                Answer = "It takes place at the Herbert Park Hotel, Ballsbridge, Dublin 4."
            },
            new Question
            {
                Id = Guid.NewGuid(),
                Title = "Where does the Azyra Christmas Party take place?",
                Answer = "It takes place at the Roly's Bistro, Ballsbridge, Dublin 4. It is a 2 minute walk from the Herbert Park Hotel."
            },
        };
    } 
}

