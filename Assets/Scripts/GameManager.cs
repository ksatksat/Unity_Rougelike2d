using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerDied()
    {
        Debug.Log("Player died — restarting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
/*
If you want it to trigger only once per press rather than spamming 
        every frame, swap one of the GetKey calls to GetKeyDown:
*/

/// <summary>
/// Cheat code: hold T + Y + U at the same time to jump to the next scene.
/// 
/// Setup:
///   Attach this script to any persistent GameObject in the scene
///   (e.g. the same GameObject that has GameManager, or the Player).
///   It works across all scenes automatically.
/// </summary>