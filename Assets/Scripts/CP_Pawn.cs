using UnityEngine;
using System.Collections.Generic;

namespace ChessGame {
    public class CP_Pawn : ChessPieceBase {
        [SerializeField] private bool _hasMoved = false;
        [SerializeField] private bool _inputEnabled = false;

        public override List<Vector2Int> CheckPossiblePlays() {
            List<Vector2Int> possiblePositions = new List<Vector2Int>();
            BoardStateSO board = BoardStateSO.instance;
            Vector2Int positionToCheck;

            positionToCheck = BoardPosition + Vector2Int.up;

            if (board.IsPositionEmpty(positionToCheck)) {
                possiblePositions.Add(positionToCheck);
            }

            if(!_hasMoved) {
                positionToCheck = BoardPosition + (Vector2Int.up * 2);

                if (board.IsPositionEmpty(positionToCheck)) {
                    possiblePositions.Add(positionToCheck);
                }
            }

            // up right corner to eat another piece
            positionToCheck = BoardPosition + (Vector2Int.up + Vector2Int.right);

            if (!board.IsPositionEmpty(positionToCheck)) {
                possiblePositions.Add(positionToCheck);
            }

            // up left corner to eat another piece

            positionToCheck = BoardPosition + (Vector2Int.up + Vector2Int.left) /*TODO*/;

            if (!board.IsPositionEmpty(positionToCheck)) {
                possiblePositions.Add(positionToCheck);
            }

            return possiblePositions;
        }

        /*
        private new void Update() {
            if(!_inputEnabled) return;

            base.Update();

            if(Input.GetKeyDown(KeyCode.W)) {
                BoardPosition += new Vector2Int(0, 1);
            } else if(Input.GetKeyDown(KeyCode.S)) {
                BoardPosition += new Vector2Int(0, -1);
            } else if(Input.GetKeyDown(KeyCode.A)) {
                BoardPosition += new Vector2Int(-1, 0);
            } else if(Input.GetKeyDown(KeyCode.D)) {
                BoardPosition += new Vector2Int(1, 0);
            }
        }
        */
    }
}
