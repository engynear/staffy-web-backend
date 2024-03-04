namespace Staffy.Bll.Models;

public class Assesment
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class AssesmentCriteria
{
    public long Id { get; set; }
    public string Critera { get; set; }
    public string Description { get; set; }
}

public class AssesmentResponce
{
    public long Id { get; set; }
    public long AssesmentId { get; set; }
    public long CriteriaId { get; set; }
    public long EvaluatedBy { get; set; }
    public long EvaluatedTo { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}

