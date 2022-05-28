using UnityEngine;
using System.Collections.Generic;

namespace ChessGame {
    public abstract class ChessPieceBase : MonoBehaviour {
        [SerializeField] private Vector2Int _position;
        [SerializeField] private Vector2Int _prevposition;

        public Vector2Int BoardPosition {
            get { return _position; }
            set {
                _prevposition = _position;
                _position = value;
                ApplyBoardPositionToTransform();
            }
        }

        public Vector2Int PreviousBoardPosition { 
            get { return _prevposition; }
        }

        [SerializeField] private bool _overrideTransfromWithPosition;

        private void Awake() {
            if(_overrideTransfromWithPosition) {
                ApplyBoardPositionToTransform();
            } else {
                SceneToBoardPosition();
            }
        }

        public void SceneToBoardPosition() {
            SceneToBoardPosition(gameObject.transform.localPosition);
        }

        public void SceneToBoardPosition(Vector3 position) {
            // _position = new Vector2Int((int)position.x, (int)position.z);
            _prevposition = _position;
            _position = Vector2Int.CeilToInt(new Vector2(position.x, position.z));
            ApplyBoardPositionToTransform();
        }

        [ContextMenu("Apply Board Position To Transform")]
        public void ApplyBoardPositionToTransform() {
            BoardStateSO board = BoardStateSO.instance;
            board.ClearPosition(this);

            gameObject.transform.localPosition = new Vector3(_position.x, 0, _position.y);

            // notify the board of the movement;
            board.FillPosition(this);
        }
        
        public abstract List<Vector2Int> CheckPossiblePlays();

        protected void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                List<Vector2Int> plays = CheckPossiblePlays();
                BoardStateSO board = BoardStateSO.instance;
                board.PrintState();

                // Debug.Log(plays.Count);

                
            }
        }
    }
}
