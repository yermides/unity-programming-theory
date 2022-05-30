using UnityEngine;
using System.Collections.Generic;

namespace ChessGame {
    public class CP_Bishop : ChessPieceBase {
        public override List<Vector2Int> CheckPossiblePlays() {
            List<Vector2Int> possiblePositions = new List<Vector2Int>();

            Vector2Int[] directions = {
                    Vector2IntExtensions.upleft
                ,   Vector2IntExtensions.upright
                ,   Vector2IntExtensions.downleft
                ,   Vector2IntExtensions.downright
            };

            foreach(var direction in directions) {
                CheckDirection(possiblePositions, direction);
            }

            return possiblePositions;
        }
    }
}
