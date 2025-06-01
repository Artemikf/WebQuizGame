using System;

namespace Main.Models;

public class Result
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int CorrectAnswersCount { get; set; }
    public DateTime SubmittedAt { get; set; }
}
