using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace ChessGame {
    public abstract class ChessPieceBase : MonoBehaviour {
        public static ChessPieceBase selected;
        protected static BoardState boardState = new BoardState();
        // public static ChessPieceBase Selected {
        //     get { return selected; }
        //     set { 
        //         selected = value;
        //         OnMouseDownAction?.Invoke();
        //     }
        // }

        protected Vector2Int _prevposition;
        [SerializeField] protected Vector2Int _position;
        [SerializeField] protected ChessTeam _team;
        [SerializeField] protected ChessUnitType _typeIdentifier;
        [SerializeField] protected GameObject slotPrefab;
        [SerializeField] protected bool _overrideTransfromWithPosition = true;
        protected bool _hasMoved = false;
        // [SerializeField] private static UnityAction OnMouseDownAction;

        public Vector2Int BoardPosition {
            get { return _position; }
            set {
                _prevposition = _position;
                _position = value;
                _hasMoved = true;
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

        private void Start() {
            _hasMoved = false;
        }

        private void OnMouseDown() {
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

        #endregion

        #region ChessPieceBase

        public void SceneToBoardPosition() {
            SceneToBoardPosition(gameObject.transform.localPosition);
        }

        public void SceneToBoardPosition(Vector3 position) {
            _prevposition = _position;
            _position = Vector2Int.CeilToInt(new Vector2(position.x, position.z));
            ApplyBoardPositionToTransform();
        }

        [ContextMenu("Apply Board Position To Transform")]
        public void ApplyBoardPositionToTransform() {
            boardState.RemovePiece(PreviousBoardPosition);
            gameObject.transform.localPosition = new Vector3(_position.x, 0, _position.y);
            boardState.PlacePiece(this);
        }

        protected void CheckDirection(List<Vector2Int> plays, Vector2Int direction) {
            Vector2Int positionToCheck = BoardPosition + direction;

            while(!boardState.IsPositionOutOfBounds(positionToCheck) && boardState.IsPositionEmpty(positionToCheck)) {
                plays.Add(positionToCheck);
                positionToCheck += direction;
            }
        }

        protected void AddPositionIfPossible(List<Vector2Int> plays, Vector2Int positionToCheck) {
            if(!boardState.IsPositionOutOfBounds(positionToCheck) && boardState.IsPositionEmpty(positionToCheck)) {
                plays.Add(positionToCheck);
            }
        }

        public abstract List<Vector2Int> CheckPossiblePlays();

        #endregion
    }
}
/*
        protected void AddPositionIfPossible(List<Vector2Int> plays, BoardStateSO board, Vector2Int position) {
            Vector2Int positionToCheck = position;

            // if(!board.IsPositionOutOfBounds(positionToCheck) && (board.IsPositionEmpty(positionToCheck)) || board.GetPiece(positionToCheck).Team != Team) {
            if(!board.IsPositionOutOfBounds(positionToCheck) && board.IsPositionEmpty(positionToCheck)) {
                plays.Add(positionToCheck);
            }
        }
        */
/*
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

        protected void AddPositionIfPossible(List<Vector2Int> plays, BoardStateSO board, Vector2Int position) {
            Vector2Int positionToCheck = position;

            // if(!board.IsPositionOutOfBounds(positionToCheck) && (board.IsPositionEmpty(positionToCheck)) || board.GetPiece(positionToCheck).Team != Team) {
            if(!board.IsPositionOutOfBounds(positionToCheck) && board.IsPositionEmpty(positionToCheck)) {
                plays.Add(positionToCheck);
            }
        }

*/