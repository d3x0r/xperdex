using System.Data;

namespace BingoGameCore4
{
    public class BingoGameGroupPrizeLevel
    {
        public BingoGameGroup game_group;
        public BingoPrize prize;
        public object ID;
        public BingoGameGroupPrizeLevel(DataRow row)
        {
        }
    }
}
