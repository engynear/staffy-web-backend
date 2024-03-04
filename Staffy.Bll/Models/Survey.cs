namespace Staffy.Bll.Models;

public class Survey
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<SurveyQuestion> Questions { get; set; }
    public List<SurveyAnswer> Answers { get; set; }
}

public enum QuestionType
{
    Text,
    MultipleChoice,
    SingleChoice,
    Rating
}

public class SurveyQuestion
{
    public long Id { get; set; }
    public string Question { get; set; }
    public QuestionType Type { get; set; }
    public List<string>? Options { get; set; }
}

public class SurveyAnswer
{
    public long Id { get; set; }
    public long SurveyId { get; set; }
    public long QuestionId { get; set; }
    public string? Answer { get; set; }
    public int? Rating { get; set; }
}