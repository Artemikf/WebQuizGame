using Main.Data;
using Main.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Main.Pages;

public class QuizModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public QuizModel(ApplicationDbContext context) => _context = context;

    [BindProperty] public int SelectedAnswerId { get; set; }
    [BindProperty(SupportsGet = true)] public string UserName { get; set; }
    [BindProperty(SupportsGet = true)] public int Index { get; set; } = 0;

    public Question Question { get; set; }
    public List<Question> AllQuestions { get; set; }
    public int CorrectCount { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        AllQuestions = await _context.Questions.Include(q => q.Answers).ToListAsync();
        if (Index >= AllQuestions.Count)
        {
            return RedirectToPage("/Result", new { userName = UserName, correct = 0 });
        }
        Question = AllQuestions[Index];
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        AllQuestions = await _context.Questions.Include(q => q.Answers).ToListAsync();
        Question = AllQuestions[Index];
        bool isCorrect = Question.Answers.First(a => a.Id == SelectedAnswerId).IsCorrect;
        int correct = Request.Query.ContainsKey("correct") ? int.Parse(Request.Query["correct"]) : 0;
        if (isCorrect) correct++;

        Index++;
        if (Index >= AllQuestions.Count)
        {
            var result = new Result
            {
                UserName = UserName,
                CorrectAnswersCount = correct,
                SubmittedAt = DateTime.UtcNow
            };
            _context.Results.Add(result);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Result", new { userName = UserName, correct });
        }
        return RedirectToPage("/Quiz", new { userName = UserName, index = Index, correct });
    }
}
