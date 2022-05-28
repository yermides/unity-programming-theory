using UnityEngine;
using System.Collections.Generic;

namespace ChessGame {
    public class CP_Pawn : ChessPieceBase {
        [SerializeField] private bool _hasMoved = false;
        [SerializeField] private bool _inputEnabled = false;

        public override List<Vector2Int> CheckPossiblePlays() {
            List<Vector2Int> possiblePositions = new List<Vector2Int>();
            BoardStateSO board = BoardStateSO.instance;
            Vector2Int checkedPosition;

            checkedPosition = BoardPosition + Vector2Int.up;

            if (board.IsPositionEmpty(checkedPosition)) {
                possiblePositions.Add(checkedPosition);
            }

            // up right corner to eat another piece
            checkedPosition = BoardPosition + Vector2Int.one;

            if (!board.IsPositionEmpty(checkedPosition)) {
                possiblePositions.Add(checkedPosition);
            }

            // up left corner to eat another piece

            checkedPosition = BoardPosition + (Vector2Int.up + Vector2Int.left) /*TODO*/;

            if (!board.IsPositionEmpty(checkedPosition)) {
                possiblePositions.Add(checkedPosition);
            }

            return possiblePositions;
        }

        private new void Update() {
            if(!_inputEnabled) return;

            base.Update();

            if(Input.GetKeyDown(KeyCode.W)) {
                BoardPosition += new Vector2Int(0, 1);
            } else if(Input.GetKeyDown(KeyCode.S)) {
                BoardPosition += new Vector2Int(0, -1);
            }

            // if(Input.GetKeyDown(KeyCode.Space)) {
            //     Debug.Log("derived");
            // }

            
        }

    }
}
