using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace ChessGame {
    public abstract class ChessPieceBase : MonoBehaviour {
        public static ChessPieceBase selected = null;
        protected Vector2Int _prevposition;
        [SerializeField] protected Vector2Int _position;
        [SerializeField] protected ChessTeam _team;
        [SerializeField] protected ChessUnitType _typeIdentifier;
        [SerializeField] protected GameObject slotPrefab;
        [SerializeField] protected bool _overrideTransfromWithPosition = true;
        // [SerializeField] private UnityAction OnMouseDownAction;

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

        public int Id {
            get { return ((int)_typeIdentifier); }
        }

        public ChessTeam Team {
            get { return _team; }
        }

        #region Monobehaviour

        private void Awake() {
            GameObject piecesParent = GameObject.FindGameObjectWithTag("ChessPieces");

            if(piecesParent != null) {
                transform.SetParent(piecesParent.transform);
            }

            if(_overrideTransfromWithPosition) {
                ApplyBoardPositionToTransform();
            } else {
                SceneToBoardPosition();
            }
        }

        private void OnMouseDown() {
            Debug.Log("I clicked a piece");
            BoardSlot.DestroyAllInScene();
            selected = this;
            // OnMouseDownAction?.Invoke();
            var plays = CheckPossiblePlays();

            foreach(Vector2Int play in plays) {
                GameObject slotObject = GameObject.Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, transform.parent);

                if(slotObject.TryGetComponent<BoardSlot>(out BoardSlot slot)) {
                    slot.positionToMove = play;
                    slot.transform.localPosition = new Vector3(play.x, 0, play.y);
                }
            }
        }

        private void OnMouseUp() {
            Debug.Log("I stopped clicked a piece");
        }

        protected void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                List<Vector2Int> plays = CheckPossiblePlays();
                BoardStateSO board = BoardStateSO.instance;
                board.PrintState();

                // Debug.Log(plays.Count);
            }
        }

        #endregion

        #region ChessPieceBase

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

        protected void CheckDirection(List<Vector2Int> plays, Vector2Int direction) {
            BoardStateSO board = BoardStateSO.instance;
            Vector2Int positionToCheck = BoardPosition + direction;

            while(!board.IsPositionOutOfBounds(positionToCheck) && board.IsPositionEmpty(positionToCheck)) {
                plays.Add(positionToCheck);
                positionToCheck += direction;
            }
        }
        
        public abstract List<Vector2Int> CheckPossiblePlays();

        #endregion
    }
}
