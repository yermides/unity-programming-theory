using UnityEngine;
using UnityEditor;

namespace ChessGame {
    public class ChessPieceFactory {
        private readonly ChessPieceFactoryConfigSO _configuration;

        public ChessPieceFactory(ChessPieceFactoryConfigSO configuration) {
            _configuration = Object.Instantiate(configuration);
        }

        public ChessPieceBase Create(int id) {
            var go = _configuration.GetPrefabById(id);
            return Object.Instantiate(go);
        }

        public ChessPieceBase Create(int id, Vector2Int position) {
            ChessPieceBase piecePrefab = _configuration.GetPrefabById(id);
            ChessPieceBase pieceInstance = Object.Instantiate(piecePrefab);
            pieceInstance.BoardPosition = position;
            return pieceInstance;
        }

        public ChessPieceBase Create(ChessUnitType type) {
            return Create(((int)type));
        }

    }
}
