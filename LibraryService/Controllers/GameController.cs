using LibraryService.DataReaders;
using LibraryService.Models;
using Microsoft.AspNetCore.Mvc;
using StructureMap;

namespace LibraryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private Container _container;

        public GameController(Container mapContainer)
        {
            this._container = mapContainer;
        }

        [HttpGet]
        [Route("allgames")]
        [Route("allgames/{gerneFlag}")]
        public IEnumerable<Game> GetGames(int? gerneFlag)
        {
            var repository = _container.GetInstance<IDataRepository>();
            if(repository != null)
            {
                var gameList = repository.GetGames(gerneFlag);
                return gameList;
            }
            return null;
        }

        [HttpGet]
        [Route("{id}")]
        public Game GetGame(int? id)
        
        {
            var repository = _container.GetInstance<IDataRepository>();
            if(repository != null)
            {
                var game = repository.GetGameById(id.Value);
                return game;
            }

            return null;
        }

        [HttpPost]
        [Route("edit")]
        public void EditGame(Game game)
        {
            var repository = _container.GetInstance<IDataRepository>();
            if (repository != null)
            {
                repository.EditGame(game);
            }
        }

        [HttpPost]
        [Route("deletegame")]
        public void DeleteGame(Game game)
        {
            var repository = _container.GetInstance<IDataRepository>();
            if (repository != null)
            {
                repository.DeleteGame(game);
            }
        }
    }
}
