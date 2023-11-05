using Microsoft.EntityFrameworkCore;
using ChessPlayersWiki10916.Model;

namespace ChessPlayersWiki10916.DbContexts
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options): base(options) { }
        public DbSet<Player> Player { get; set; }
    }
}
