using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace ChessGame {
    public class GameManager : MonoBehaviour {
        [SerializeField] private ChessPieceFactoryConfigSO pieceFactoryConfiguration;
        private ChessPieceFactory _factory;

        private void Awake() {
            _factory = new ChessPieceFactory(Instantiate(pieceFactoryConfiguration));
        }

        public void ReturnToMainMenu() {
            SceneManager.LoadScene(SceneUtility.SceneMainMenuIndex);
        }

        #if UNITY_EDITOR

            [ContextMenu("Spawn Pawn Unit")]
            public ChessPieceBase SpawnPawn() {
                ChessPieceBase piece = _factory.Create(ChessUnitType.Pawn);
                return piece;
            }

            [ContextMenu("Spawn Bishop Unit")]
            public ChessPieceBase SpawnBishop() {
                ChessPieceBase piece = _factory.Create(ChessUnitType.Bishop);
                return piece;
            }

            [ContextMenu("Spawn Horse Unit")]
            public ChessPieceBase SpawnHorse() {
                ChessPieceBase piece = _factory.Create(ChessUnitType.Horse);
                return piece;
            }

            [ContextMenu("Spawn King Unit")]
            public ChessPieceBase SpawnKing() {
                ChessPieceBase piece = _factory.Create(ChessUnitType.King);
                return piece;
            }

            [ContextMenu("Spawn Queen Unit")]
            public ChessPieceBase SpawnQueen() {
                ChessPieceBase piece = _factory.Create(ChessUnitType.Queen);
                return piece;
            }

            [ContextMenu("Spawn Tower Unit")]
            public ChessPieceBase SpawnTower() {
                ChessPieceBase piece = _factory.Create(ChessUnitType.Tower);
                return piece;
            }

        #endif
    }
}
