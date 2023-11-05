using ChessPlayersWiki10916.Model;

namespace ChessPlayersWiki10916.Repo
{
    public interface IPlayerRepo
    {
        IEnumerable<Player> GetPlayers();
        Player GetPlayerById(int playerId);
        void InsertPlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(int playerId);
    }
}
