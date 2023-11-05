using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using ChessPlayersWiki10916.Repo;
using ChessPlayersWiki10916.Model;

namespace ChessPlayersWiki10916.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepo _playerRepo;
        public PlayerController(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }

        // GET: api/Player
        [HttpGet]
        public IActionResult Get()
        {
            var players = _playerRepo.GetPlayers();
            return new OkObjectResult(players);
        }

        // GET: api/Player/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var player = _playerRepo.GetPlayerById(id);
            return new OkObjectResult(player);
        }

        // POST: api/Player
        [HttpPost]
        public IActionResult Post([FromBody] Player player)
        {
            using (var scope = new TransactionScope())
            {
                _playerRepo.InsertPlayer(player);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = player.playerId }, player);
            }
        }

        // PUT: api/Player/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Player player)
        {
            if (player != null)
            {
                using (var scope = new TransactionScope())
                {
                    _playerRepo.UpdatePlayer(player);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _playerRepo.DeletePlayer(id);
            return new OkResult();
        }
    }
}
