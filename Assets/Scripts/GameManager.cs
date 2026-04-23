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