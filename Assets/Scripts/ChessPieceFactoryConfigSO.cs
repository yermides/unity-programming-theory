using UnityEngine;
using System.Collections.Generic;
using System;

namespace ChessGame {
    [CreateAssetMenu(fileName = "ChessPieceFactoryConfigSO", menuName = "ChessGame/ChessPieceFactoryConfigSO", order = 2)]
    public class ChessPieceFactoryConfigSO : ScriptableObject {
        // Due to lack of SerializedDictionary or Odin inspector, we have to do this manually 
        [SerializeField] private ChessPieceBase[] _chessPieces;
        private Dictionary<int, ChessPieceBase> _idToChessPiece;

        private void Awake() {
            _idToChessPiece = new Dictionary<int, ChessPieceBase>();

            foreach (var piece in _chessPieces) {
                _idToChessPiece.Add(piece.Id, piece);
            }
        }

        public ChessPieceBase GetPrefabById(int id) {
            if (!_idToChessPiece.TryGetValue(id, out var piece)) {
                throw new Exception($"ChessPiece with id {id} does not exit");
            }

            return piece;
        }
    }
}
