using UnityEngine;
using System.Collections.Generic;

namespace ChessGame {
    public class CP_Pawn : ChessPieceBase {
        public override List<Vector2Int> CheckPossiblePlays() {
            List<Vector2Int> possiblePositions = new List<Vector2Int>();
            Vector2Int positionToCheck;

            positionToCheck = BoardPosition + Vector2Int.up;
            AddPositionIfPossible(possiblePositions, positionToCheck);

            if(!_hasMoved && boardState.IsPositionEmpty(positionToCheck)) {
                positionToCheck += Vector2Int.up;
                AddPositionIfPossible(possiblePositions, positionToCheck);
            }

            return possiblePositions;
        }
    }
}
