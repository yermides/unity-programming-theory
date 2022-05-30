using UnityEngine;
using System;
using System.Collections.Generic;

// TODO:: Implement

namespace ChessGame {
    public class CP_King : ChessPieceBase {
        public override List<Vector2Int> CheckPossiblePlays() {
            void AddPositionIfPossible(List<Vector2Int> plays, BoardStateSO board, Vector2Int position) {
                Vector2Int positionToCheck = position;

                // if(!board.IsPositionOutOfBounds(positionToCheck) && (board.IsPositionEmpty(positionToCheck)) || board.GetPiece(positionToCheck).Team != Team) {
                if(!board.IsPositionOutOfBounds(positionToCheck) && board.IsPositionEmpty(positionToCheck)) {
                    plays.Add(positionToCheck);
                }
            }

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

            BoardStateSO board = BoardStateSO.instance;
            Vector2Int positionToCheck;

            foreach(var offset in playsOffset) {
                positionToCheck = BoardPosition + offset;
                AddPositionIfPossible(plays, board, positionToCheck);
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