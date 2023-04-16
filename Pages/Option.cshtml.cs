using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyWebApp.Pages;

public class OptionModel : PageModel
{
        public string[] Questions { get; private set; }
        public string[] CorrectAnswers { get; private set; }
        public string[] UserAnswers { get; private set; }
        public string[][] Answers { get; private set; }

        public void OnGet() {
            // Read the quiz questions and answers from a file
            string[] fileLines = System.IO.File.ReadAllLines("QA.txt");
            Questions = new string[fileLines.Length / 6];
            Answers = new string[fileLines.Length / 6][];
            CorrectAnswers = new string[fileLines.Length / 6];
            UserAnswers = new string[fileLines.Length / 6];

            for (int i = 0; i < fileLines.Length; i += 6) {
                Questions[i / 6] = fileLines[i];
                CorrectAnswers[i / 6] = fileLines[i + 5].Substring(10);
                Answers[i / 6] = new string[] {
                    fileLines[i + 1].Substring(3),
                    fileLines[i + 2].Substring(3),
                    fileLines[i + 3].Substring(3),
                    fileLines[i + 4].Substring(3),
                    CorrectAnswers[i/6]
                };
            }
        }
        public async Task<IActionResult> OnPostSubmitAsync()
        {
            string[] fileLines = System.IO.File.ReadAllLines("QA.txt");
            Questions = new string[fileLines.Length / 6];
            Answers = new string[fileLines.Length / 6][];
            CorrectAnswers = new string[fileLines.Length / 6];
            UserAnswers = new string[fileLines.Length / 6];

            for (int i = 0; i < fileLines.Length; i += 6) {
                Questions[i / 6] = fileLines[i];
                CorrectAnswers[i / 6] = fileLines[i + 5].Substring(10);
                Answers[i / 6] = new string[] {
                    fileLines[i + 1].Substring(3),
                    fileLines[i + 2].Substring(3),
                    fileLines[i + 3].Substring(3),
                    fileLines[i + 4].Substring(3),
                    CorrectAnswers[i/6]
                };
            }
            // iterate over each question and get the user's selected answer
            for (int i = 0; i < Questions.Length; i++) {
                string selectedAnswer = Request.Form[Questions[i]];
                UserAnswers[i] = selectedAnswer;
            }
            // create a dictionary to store the correct answers
            int Score = 0;
            for (int i = 0; i < Questions.Length; i++) {
                if (CorrectAnswers[i] == UserAnswers[i]){
                    Score++;
                }
            }
            var resModel = new ResultsModel();
            resModel.Questions = Questions;
            resModel.CorrectAnswers = CorrectAnswers;
            resModel.UserAnswers = UserAnswers;
            return RedirectToPage("Results", resModel);
    }

}
