using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessGame {
    public class WorldBounds : MonoBehaviour {
        private void OnMouseDown() {
            ChessPieceBase.selected = null;
            BoardSlot.DestroyAllInScene();
        }
    }
}
