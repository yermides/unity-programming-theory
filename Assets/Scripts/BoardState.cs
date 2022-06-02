using System;
using UnityEngine;

namespace ChessGame {
    public class BoardState {
        private const int kSIZE = 8;
        private ChessPieceBase[,] _pieceboard = new ChessPieceBase[kSIZE, kSIZE];

        public bool IsPositionOutOfBounds(Vector2Int position) {
            return position.x < 0 || position.x >= kSIZE || position.y < 0 || position.y >= kSIZE;
        }

        private void ThrowErrorIfOutOfBounds(Vector2Int position) {
            #if UNITY_EDITOR
                if(!IsPositionOutOfBounds(position)) return;
                throw new IndexOutOfRangeException($"The chess board only has numbers from [0,0] to [{kSIZE-1}, {kSIZE-1}], and you entered {position}");
            #else
                // Do nothing
            #endif
        }

        public bool IsPositionEmpty(Vector2Int position) {
            ThrowErrorIfOutOfBounds(position);

            return _pieceboard[position.x, position.y] == null;
        }

        public bool IsPositionFilled(Vector2Int position) {
            return !IsPositionEmpty(position);
        }

        public void PlacePiece(ChessPieceBase piece) {
            ThrowErrorIfOutOfBounds(piece.BoardPosition);

            _pieceboard[piece.BoardPosition.x, piece.BoardPosition.y] = piece;
        }

        public void PlacePiece(ChessPieceBase piece, Vector2Int position) {
            ThrowErrorIfOutOfBounds(position);

            _pieceboard[position.x, position.y] = piece;
            piece.BoardPosition = position;
        }

        public void RemovePiece(Vector2Int position) {
            ThrowErrorIfOutOfBounds(position);
            
            _pieceboard[position.x, position.y] = null;
        }
    }
}