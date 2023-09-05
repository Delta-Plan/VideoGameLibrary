using LibraryService.Models;

namespace LibraryService.DataReaders
{
    public interface IDataRepository
    {
        public Game GetGameById(int id);
        public IEnumerable<Game> GetGames(int? gerneFlag);
        public void EditGame(Game game);
        public void DeleteGame(Game game);
    }
}
