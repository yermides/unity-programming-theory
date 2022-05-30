using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessGame {
    public class WorldBounds : MonoBehaviour {
        private void OnMouseDown() {
            Debug.LogWarning("deselected");
            
            ChessPieceBase.selected = null;
            BoardSlot.DestroyAllInScene();
        }
    }
}
