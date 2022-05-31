using UnityEngine;
using System.Collections.Generic;

namespace ChessGame {
    public class CP_Pawn : ChessPieceBase {
        public override List<Vector2Int> CheckPossiblePlays() {
            List<Vector2Int> possiblePositions = new List<Vector2Int>();
            BoardStateSO board = BoardStateSO.instance;
            Vector2Int positionToCheck;

            positionToCheck = BoardPosition + Vector2Int.up;
            AddPositionIfPossible(possiblePositions, board, positionToCheck);

            if(!_hasMoved) {
                positionToCheck += Vector2Int.up;
                AddPositionIfPossible(possiblePositions, board, positionToCheck);
            }

            return possiblePositions;
        }
    }
}
