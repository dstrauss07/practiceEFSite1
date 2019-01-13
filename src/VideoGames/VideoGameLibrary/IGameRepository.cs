using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameLibrary
{
    public interface IGameRepository
    {
        List<Games> ListAll();
        Games GetByID(int id);
        void AddGame(Games NewGame);
        void EditGame(Games EditedGame);
        void DeleteGame(int id);
    }
}
