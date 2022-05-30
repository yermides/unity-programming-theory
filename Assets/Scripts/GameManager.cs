using UnityEngine;

namespace ChessGame {
    public class GameManager : MonoBehaviour {
        [SerializeField] private ChessPieceFactoryConfigSO pieceFactoryConfiguration;
        private ChessPieceFactory _factory;

        private void Awake() {
            _factory = new ChessPieceFactory(Instantiate(pieceFactoryConfiguration));
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                ChessPieceBase piece = _factory.Create(ChessUnitType.Pawn);
                piece.BoardPosition = new Vector2Int(4,4);
            }
        }
    }
}
