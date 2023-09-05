using LibraryService.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.DataReaders
{
    public class DatabaseRepository : IDataRepository
    {
        private ApplicationContext _context;
        public DatabaseRepository(ApplicationContext context) 
        { 
            _context = context;
        }
        public void DeleteGame(Game game)
        {
            if (game != null && game.Id > 0)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
        }

        public void EditGame(Game game)
        {
            if (game == null)
            {
                _context.Games.Update(game);
                _context.SaveChanges();
            }
        }

        public Game GetGameById(int id)
        {
            var game = _context.Games
                .Include(_ => _.Developer)
                .AsNoTracking()
                .FirstOrDefault(_ => _.Id == id);

            return game;
        }

        public IEnumerable<Game> GetGames(int? gerneFlag)
        {
            var games = _context.Games
                .Where(_ => gerneFlag.HasValue ? (_.Gerne & gerneFlag.Value) != 0 : true)
                .Include(_ => _.Developer)
                .ToList();

            return games;
        }
    }
}
