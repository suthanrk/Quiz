using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyWebApp.Pages;

public class ResultsModel : PageModel
{
    public string[] Questions { get;  set; }
    public string[] CorrectAnswers { get; set; }
    public string[] UserAnswers { get; set; }
    public string[][] Answers { get; set; }

    public int Score { get; private set; }

    public void OnGet() {
        // Receive the user's answers and correct answers from the Quiz page
        //UserAnswers = userAnswers;
        //CorrectAnswers = correctAnswers;
        //Score = score;
    }
}
