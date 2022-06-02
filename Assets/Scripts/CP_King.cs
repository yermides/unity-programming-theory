using UnityEngine;
using System;
using System.Collections.Generic;

namespace ChessGame {
    public class CP_King : ChessPieceBase {
        public override List<Vector2Int> CheckPossiblePlays() {
            List<Vector2Int> plays = new List<Vector2Int>();

            Vector2Int[] playsOffset = {
                    Vector2Int.up
                ,   Vector2Int.down
                ,   Vector2Int.right
                ,   Vector2Int.left
                ,   Vector2IntExtensions.upleft
                ,   Vector2IntExtensions.upright
                ,   Vector2IntExtensions.downleft
                ,   Vector2IntExtensions.downright
            };

            Vector2Int positionToCheck;

            foreach(var offset in playsOffset) {
                positionToCheck = BoardPosition + offset;
                AddPositionIfPossible(plays, positionToCheck);
            }

            return plays;
        }
    }
}

/*
// Horizontal && Vertical

            positionToCheck = BoardPosition + Vector2Int.up;
            AddPositionIfPossible(plays, board, positionToCheck);

            positionToCheck = BoardPosition + Vector2Int.down;
            AddPositionIfPossible(plays, board, positionToCheck);

            positionToCheck = BoardPosition + Vector2Int.right;
            AddPositionIfPossible(plays, board, positionToCheck);

            positionToCheck = BoardPosition + Vector2Int.left;
            AddPositionIfPossible(plays, board, positionToCheck);

            // Diagonals

            positionToCheck = BoardPosition + Vector2IntExtensions.upleft;
            AddPositionIfPossible(plays, board, positionToCheck);

            positionToCheck = BoardPosition + Vector2IntExtensions.upright;
            AddPositionIfPossible(plays, board, positionToCheck);

            positionToCheck = BoardPosition + Vector2IntExtensions.downleft;
            AddPositionIfPossible(plays, board, positionToCheck);

            positionToCheck = BoardPosition + Vector2IntExtensions.downright;
            AddPositionIfPossible(plays, board, positionToCheck);
*/