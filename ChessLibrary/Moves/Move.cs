namespace ChessLibrary
{
    public abstract class Move
    {
        public abstract MoveType Type { get; }
        public abstract Position FromPos { get; }
        public abstract Position ToPos { get; }

        public abstract bool Execute(Board board);  

        public virtual bool IsLegal(Board board)
        {
            Player player= board[FromPos].Color;
            Board boardcopy = board.Copy();
            Execute(boardcopy);
            return !boardcopy.IsInChek(player);
        }
    }
}
