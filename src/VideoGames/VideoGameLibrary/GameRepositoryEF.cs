using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VideoGameLibrary
{
    public class GameRepositoryEF : IGameRepository
    {
        private readonly GamesContext _gameContext;
        public GameRepositoryEF(GamesContext dbContext)
        {
            _gameContext = dbContext;
        }
        public void AddGame(Games NewGame)
        {
            _gameContext.Add(NewGame);
            _gameContext.SaveChanges();
        }

        public void DeleteGame(int id)
        {
            _gameContext.Remove(GetByID(id));
            _gameContext.SaveChanges();
        }

        public void EditGame(Games EditedGame)
        {
            var OrigGame = GetByID(EditedGame.GameId);
            OrigGame.GameName = EditedGame.GameName;
            OrigGame.Genre = EditedGame.Genre;
            OrigGame.Publisher = EditedGame.Publisher;
            OrigGame.PublisherId = EditedGame.PublisherId;
            OrigGame.Company = EditedGame.Company;
            OrigGame.CompanyId = EditedGame.CompanyId;
            _gameContext.SaveChanges();
        }

        public Games GetByID(int id)
        {
            return _gameContext.Games
                 .Single(b => b.GameId== id);
        }

        public List<Games> ListAll()
        {
            return _gameContext.Games.ToList();        }
    }
}
