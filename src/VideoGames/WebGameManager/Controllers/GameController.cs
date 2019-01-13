using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameLibrary;

namespace WebGameManager.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _GameRepo;

        public GameController(IGameRepository gameRepository)
        {
            _GameRepo = gameRepository;
        }
        // GET: Game
        public ActionResult Index()
        {
            return View(_GameRepo.ListAll());
        }

        // GET: Game/Details/5
        public ActionResult Details(int id)
        {
            return View(_GameRepo.GetByID(id));
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View(new Games());
        }

        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Games NewGame, IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View(NewGame);
            }
            try
            {
                _GameRepo.AddGame(NewGame);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
               //TODO Log the exception
            }
            return  View(NewGame);
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_GameRepo.GetByID(id));
        }

        // POST: Game/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Games EditedGame, IFormCollection collection)
        {
            try
            {
                _GameRepo.EditGame(EditedGame);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
               //LOG THE ERRORS
            }
            return View(EditedGame);
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_GameRepo.GetByID(id));
        }

        // POST: Game/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _GameRepo.DeleteGame(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
               //TODO log the errors
            }
            return View(_GameRepo.GetByID(id));
        }
    }
}