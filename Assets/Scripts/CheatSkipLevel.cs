using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Cheat code: hold T + Y + U at the same time to jump to the next scene.
/// 
/// Setup:
///   Attach this script to any persistent GameObject in the scene
///   (e.g. the same GameObject that has GameManager, or the Player).
///   It works across all scenes automatically.
/// </summary>
public sealed class CheatSkipLevel : MonoBehaviour
{
    private void Update()
    {
        /* If you want it to trigger only once per press rather than spamming 
        every frame, swap one of the GetKey calls to GetKeyDown:*/
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