using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace ChessGame {
    public class MainMenuManager : MonoBehaviour {
        public void StartGame() {
            SceneManager.LoadScene(SceneUtility.SceneGameplayIndex);
        }

        public void StartCredits() {
            SceneManager.LoadScene(SceneUtility.SceneCreditsIndex);
        }

        public void QuitGame() {
            #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
            #else
                Application.Quit();
            #endif
        }
    }
}
