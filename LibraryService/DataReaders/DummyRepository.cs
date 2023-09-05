using LibraryService.Models;

namespace LibraryService.DataReaders
{
    public class DummyRepository : IDataRepository
    {
        private Game _game = new Game { Id = -1, Developer = new Developer { Id = -1, Name = "Rocky" }, Gerne = (int)Gernes.None, Name = "Dummy Game" };

        public void DeleteGame(Game game)
        {
            // ok;
        }

        public void EditGame(Game game)
        {
            // ok;
        }

        public Game GetGameById(int id)
        {
            return _game;
        }

        public IEnumerable<Game> GetGames(int? gerneFlag)
        {
            return new[] {_game };
        }
    }
}
