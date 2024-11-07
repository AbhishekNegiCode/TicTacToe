using Microsoft.AspNetCore.Mvc;
using TicTacToeGame.Models;

namespace TicTacToeGame.Controllers
{
    public class TicTacToeController : Controller
    {
        private static TicTacToeModel game = new TicTacToeModel();

        public IActionResult Index()
        {
            return View(game);
        }

        [HttpPost]
        public IActionResult MakeMove(int index)
        {
            game.MakeMove(index);
            return RedirectToAction("Index");
        }

        public IActionResult ResetGame()
        {
            game = new TicTacToeModel();
            return RedirectToAction("Index");
        }
    }
}
