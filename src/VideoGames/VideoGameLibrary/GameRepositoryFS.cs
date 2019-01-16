using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VideoGameLibrary
{
    public class GameRepositoryFS : IGameRepository
    {
        public static List<Games> _games;
        public static int _nextId = 1;

        public const string PATH = "E:/CodingRepo/Data/GameData";
        public const string FILENAME = "gamedata.json";

        private readonly string _fileFullPath = Path.Combine(PATH, FILENAME);

        public GameRepositoryFS()
        {
           
            if(_games == null)
            {
                _games = LoadFile();
            }
        }

        public List<Games> LoadFile()
        {
            try
            {
                string rawListStr = File.ReadAllText(_fileFullPath);
                List<Games> rawGameList = JsonConvert.DeserializeObject<List<Games>>(rawListStr);
                return rawGameList;
            }
            catch(Exception)
            {
                //TODO log the exceptions
            }
            return new List<Games>();

        }

        public void SaveFile()
        {
            if(!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }
            try
            {
                string rawListString = JsonConvert.SerializeObject(_games);
                File.WriteAllText(_fileFullPath, rawListString);
            }
            catch(Exception)
            {
                //  todo LOG THE EXCEPTION
            }

        }

        public void AddGame(Games NewGame)
        {
            NewGame.GameId = _nextId++;
            _games.Add(NewGame);
            SaveFile();
        }

        public void DeleteGame(int id)
        {
            _games.Remove(GetByID(id));
            SaveFile();
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
            SaveFile();
        }

        public Games GetByID(int id)
        {
            return _games.Find(g => g.GameId == id);
        }

        public List<Games> ListAll()
        {
            return _games;
        }
    }
}
