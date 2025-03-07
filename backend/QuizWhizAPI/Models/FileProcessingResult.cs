﻿namespace QuizWhizAPI.Models;

public class FileProcessingResult
{
    public FileProcessingResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public bool Success { get; }
    public string Message { get; }
}