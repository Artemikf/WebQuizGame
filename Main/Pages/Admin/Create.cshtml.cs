using Main.Data;
using Main.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Main.Pages.Admin;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public CreateModel(ApplicationDbContext context) => _context = context;

    [BindProperty] public Question Question { get; set; }
    [BindProperty] public List<Answer> Answers { get; set; }

    public void OnGet()
    {
        Question = new Question();
        Answers = new List<Answer>()
        {
            new(), new(), new(), new()
        };
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Question.Answers = Answers;
        _context.Questions.Add(Question);
        await _context.SaveChangesAsync();
        return RedirectToPage("/Index");
    }
}
