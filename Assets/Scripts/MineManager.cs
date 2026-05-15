using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages mine placement — ONLY active on allowed scene build indexes.
/// Level 5 = index 4 (0-based: Level1=0, Level2=1, Level3=2, Level4=3, Level5=4).
///
/// Setup:
///   1. Attach to any GameObject in the scene (or a persistent Manager GO).
///   2. Assign the Mine Prefab in the Inspector.
///   3. Allowed Scene Indexes is pre-set to {4} for Level 5.
///   4. Player presses [Space] to drop a mine at their current position.
/// </summary>
public sealed class MineManager : MonoBehaviour
{
    [Header("Mine Settings")]
    [SerializeField] private GameObject _minePrefab;

    [Header("Level Gate")]
    [Tooltip("Scene build indexes where mines are allowed. 4 = 5th scene (0-based).")]
    [SerializeField] private int[] _allowedSceneIndexes = { 4 };

    [Header("Input")]
    [SerializeField] private KeyCode _placeKey = KeyCode.Space;

    private bool      _minesAllowed;
    private Transform _playerTransform;

    private void Awake()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        _minesAllowed = System.Array.IndexOf(_allowedSceneIndexes, current) >= 0;

        if (!_minesAllowed)
            Debug.Log($"[MineManager] Mines disabled on scene index {current}.");
    }

    private void Start()
    {
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null) _playerTransform = p.transform;
    }

    private void Update()
    {
        if (!_minesAllowed)        return;
        if (_minePrefab == null)   return;
        if (_playerTransform == null) return;

        if (Input.GetKeyDown(_placeKey))
            PlaceMine();
    }

    private void PlaceMine()
    {
        Instantiate(_minePrefab, _playerTransform.position, Quaternion.identity);
        Debug.Log("[MineManager] Mine placed at " + _playerTransform.position);
    }
}