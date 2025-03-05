﻿namespace QuizWhizAPI.Models;

public class Hint
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
}