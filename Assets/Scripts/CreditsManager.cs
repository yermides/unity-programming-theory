using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChessGame {
    public class CreditsManager : MonoBehaviour {
        public void ReturnToMainMenu() {
            SceneManager.LoadScene(SceneUtility.SceneMainMenuIndex);
        }
    }
}
