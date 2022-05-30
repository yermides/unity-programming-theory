using UnityEngine;

// Unused

namespace ChessGame {
    public class BoardSlotSpawner : MonoBehaviour {
        [SerializeField] private BoardSlot _slotPrefab;

        public BoardSlot Create() {
            return Object.Instantiate(_slotPrefab);
        }
    }
}