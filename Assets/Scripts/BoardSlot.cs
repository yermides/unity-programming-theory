using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ChessGame {
    public class BoardSlot : MonoBehaviour {
        public Vector2Int positionToMove;

        private void OnMouseDown() {
            if(ChessPieceBase.selected == null) return;

            ChessPieceBase.selected.BoardPosition = positionToMove;
            DestroyAllInScene();
        }

        public static void DestroyAllInScene() {
            BoardSlot[] slots = GameObject.FindObjectsOfType<BoardSlot>();

            foreach(var slot in slots) {
                Destroy(slot.gameObject);
            }
        }
    }
}