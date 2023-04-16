using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyWebApp.Pages;

public class RadioModel : PageModel
{
     [BindProperty]
    public int SelectedOption { get; set; }
    public SelectList Radio { get; set; }
    private readonly ILogger<IndexModel> _logger;
    public string FileContent { get; private set; }

    public RadioModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var optionsList = new List<SelectListItem>();
        //FileContent = System.IO.File.ReadAllText("./abc.txt");
        foreach (string CurrentLine in System.IO.File.ReadLines(@"./abc.txt"))
        {
            optionsList.Add(new SelectListItem
            {
                Value = CurrentLine,
                Text = "Option " + CurrentLine
            });
        }
        Radio = new SelectList(optionsList, "Value", "Text");
    }
}
