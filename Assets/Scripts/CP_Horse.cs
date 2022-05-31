using UnityEngine;
using System;
using System.Collections.Generic;

namespace ChessGame {
    public class CP_Horse : ChessPieceBase {
        public override List<Vector2Int> CheckPossiblePlays() {
            List<Vector2Int> possiblePositions = new List<Vector2Int>();
            BoardStateSO board = BoardStateSO.instance;
            const int Steps = 3;
            
            Vector2Int[] directions = {
                    Vector2Int.up
                ,   Vector2Int.down
            };

            // Horse's move has 2 parts, so check the moves if we were to move first 1 slot and then 2 in the first horse move
            for (int movesInFirstPart = 1; movesInFirstPart <= 2; movesInFirstPart++) {
                foreach (var direction in directions) {
                    Vector2Int positionToCheck = BoardPosition + (direction * (Steps - movesInFirstPart));
                    Vector2Int leftCheck = positionToCheck + (Vector2Int.left * movesInFirstPart);
                    Vector2Int rightCheck = positionToCheck + (Vector2Int.right * movesInFirstPart);
                    AddPositionIfPossible(possiblePositions, board, leftCheck);
                    AddPositionIfPossible(possiblePositions, board, rightCheck);
                }
            }

            return possiblePositions;
        }
    }
}
