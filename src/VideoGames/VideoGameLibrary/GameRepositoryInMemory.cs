using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameLibrary
{
    public class GameRepositoryInMemory : IGameRepository
    {
        public static List<Games> _Games;
        public static int _nextId = 1;

        public GameRepositoryInMemory()
        {
            if(_Games ==null)
            {
                _Games = new List<Games>();
            }
        }
        public void AddGame(Games NewGame)
        {
            NewGame.GameId = _nextId++;
            _Games.Add(NewGame);
        }

        public void DeleteGame(int id)
        {
            _Games.Remove(GetByID(id));
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
        }

        public Games GetByID(int id)
        {
            return _Games.Find(b => b.GameId == id);
        }

        public List<Games> ListAll()
        {
            return _Games;
        }
    }
}
