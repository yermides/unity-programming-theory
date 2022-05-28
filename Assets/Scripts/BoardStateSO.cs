using UnityEngine;
using System;
using UnityEditor;
using TMPro;
using System.Collections.Generic;

namespace ChessGame {
    [CreateAssetMenu(fileName = "BoardStateSO", menuName = "ChessGame/BoardStateSO", order = 0)]
    public class BoardStateSO : ScriptableSingleton<BoardStateSO> {
        public static readonly int kSIZE = 8;
        [SerializeField] internal ChessPieceBase[,] _pieceboard = new ChessPieceBase[kSIZE, kSIZE];
        [SerializeField] TMP_Text pieceboardDebug;
        // [SerializeField] private List<List<ChessPieceBase>> _pieceboard = new List<List<ChessPieceBase>>(kSIZE);

        public bool IsPositionEmpty(Vector2Int position) {
            // out of bounds check, for now hardcoded
            if(position.x < 0 || position.x >= kSIZE) return false;
            if(position.y < 0 || position.y >= kSIZE) return false;

            return _pieceboard[position.x, position.y] == null;
            // return _pieceboard[position.x][position.y] == null;
        }

        public void FillPosition(ChessPieceBase piece) {
            _pieceboard[piece.BoardPosition.x, piece.BoardPosition.y] = piece;
            // _pieceboard[piece.BoardPosition.x][piece.BoardPosition.y] = piece;
        }

        public void ClearPosition(ChessPieceBase piece) {
            _pieceboard[piece.PreviousBoardPosition.x, piece.PreviousBoardPosition.y] = null;
        }

        public void PrintState() {
            if(!pieceboardDebug) {
                pieceboardDebug = GameObject.FindGameObjectWithTag("MatrixDebugText").GetComponent<TMP_Text>();
            }

            string text = "";

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    text += Convert.ToInt32(!IsPositionEmpty(new Vector2Int(j,i))) + " ";
                }

                text += "\n";
            }

            pieceboardDebug.text = text;
        }

    }

    /*
    #if UNITY_EDITOR

    [CustomEditor(typeof(BoardStateSO))]
    public class BoardStateSOEditor : Editor {
        public override void OnInspectorGUI() {
            BoardStateSO board = target as BoardStateSO;

            for (int j = 0; j < BoardStateSO.kSIZE; j++) {
                EditorGUILayout.BeginHorizontal();

                for (int i = 0; i < BoardStateSO.kSIZE; i++) {
                    // board._pieceboard[i,j] = EditorGUILayout.ObjectField(board._pieceboard[i,j].gameObject);
                }

                EditorGUILayout.EndHorizontal();
            }
        }
    }

    #endif
    */
}
