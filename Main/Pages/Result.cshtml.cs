using Main.Data;
using Main.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Pages
{
    public class ResultModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ResultModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Result> AllResults { get; set; } = new();

        //public async Task OnGetAsync()
        //{
        //    // ДОБАВЛЯЕМ ТЕСТОВЫЕ ДАННЫЕ (только если таблица пустая)
        //    if (!_context.Results.Any())
        //    {
        //        _context.Results.Add(new Result
        //        {
        //            UserName = "Тестовый пользователь",
        //            CorrectAnswersCount = 3,
        //            SubmittedAt = DateTime.UtcNow
        //        });
        //        await _context.SaveChangesAsync();
        //    }

        //    // Загружаем все результаты из базы
        //    AllResults = await _context.Results
        //        .OrderByDescending(r => r.SubmittedAt)
        //        .ToListAsync();
        //}



    }
}
