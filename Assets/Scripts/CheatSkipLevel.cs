using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class CheatSkipLevel : MonoBehaviour
{
    private void Update()
    {
        /* */
        if (Input.GetKeyDown(KeyCode.T) &&
        Input.GetKey(KeyCode.Y) &&
        Input.GetKey(KeyCode.U))
        {
            SkipToNextScene();
        }
    }

    private void SkipToNextScene()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log($"[CHEAT] Skipping to scene index {next}");
            SceneManager.LoadScene(next);
        }
        else
        {
            Debug.LogWarning("[CHEAT] No next scene — already on the last scene.");
        }
    }
}