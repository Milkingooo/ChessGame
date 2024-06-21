using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Castle : Move
    {
        public override MoveType Type { get; }
        public override Position FromPos { get; }
        public override Position ToPos {  get; }

        private readonly Direction kingMoveDir;
        private readonly Position rookFromPos;
        private readonly Position rookToPos;

        public Castle(MoveType type, Position kingPos)
        {
            Type = type;
            FromPos = kingPos;

            if ( type == MoveType.CastleKS)
            {
                kingMoveDir = Direction.East;
                ToPos = new Position(kingPos.Row, 6);
                rookFromPos = new Position(kingPos.Row, 7);
                rookToPos = new Position(kingPos.Row, 5);
            }
            else if ( type == MoveType.CastleQS) 
            {
                kingMoveDir = Direction.West;
                ToPos = new Position(kingPos.Row, 2);
                rookFromPos = new Position(kingPos.Row, 0);
                rookToPos = new Position(kingPos.Row, 3);
            }
        }

        public override void Execute(Board board)
        {
            new NormalMove(FromPos, ToPos).Execute(board);
            new NormalMove(rookFromPos, rookToPos).Execute(board);

        }

        public override bool IsLegal(Board board)
        {
            Player player = board[FromPos].Color;

            if (board.IsInChek(player))
            {
                return false;
            }

            Board copy = board.Copy();
            Position kingPosInCop = FromPos;

            for (int i = 0; i < 2; i++)
            {
                new NormalMove(kingPosInCop, kingPosInCop + kingMoveDir).Execute(copy);
                kingPosInCop += kingMoveDir;

                if(copy.IsInChek(player) )
                {
                    return false;
                }
            }

            return true;
        }
    }
}
