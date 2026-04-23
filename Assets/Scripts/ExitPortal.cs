using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Attach to the green box exit trigger.
/// When the Player enters it, loads the next scene in Build Settings.
/// 
/// Setup:
///   1. Create a GameObject, add a BoxCollider2D → check "Is Trigger".
///   2. Give it a green SpriteRenderer (or just a coloured box sprite).
///   3. Attach this script.
///   4. Make sure both scenes are added in File → Build Settings (in order).
/// </summary>
public sealed class ExitPortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        int next = SceneManager.GetActiveScene().buildIndex + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(next);
        else
            Debug.LogWarning("ExitPortal: no next scene found in Build Settings.");
    }
}