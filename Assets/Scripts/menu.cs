using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Reload current scene
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop game in editor
        #else
            Application.Quit();
        #endif
    }
}