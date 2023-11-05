using ChessPlayersWiki10916.Model;
using ChessPlayersWiki10916.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ChessPlayersWiki10916.Repo
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly PlayerContext _dbContext;
        public PlayerRepo(PlayerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Player> GetPlayers()
        {
            var players = _dbContext.Player.ToList();

            return players;
        }
        public Player GetPlayerById(int playerId)
        {
            var player = _dbContext.Player.Find(playerId);

            return player;
        }
        public void InsertPlayer(Player player)
        {
            _dbContext.Add(player);

            Save();
        }
        public void UpdatePlayer(Player player)
        {
            _dbContext.Entry(player).State = EntityState.Modified;

            Save();
        }
        public void DeletePlayer(int playerId)
        {
            var player = _dbContext.Player.Find(playerId);
            _dbContext.Player.Remove(player);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
