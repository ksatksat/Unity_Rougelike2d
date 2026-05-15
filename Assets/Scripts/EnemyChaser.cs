using UnityEngine;

/// <summary>
/// Enemy that follows the Player.
/// Handles ALL collision logic itself — Mine has no collision code at all.
///
/// Setup:
///   1. GameObject → SpriteRenderer (red) + BoxCollider2D + Rigidbody2D (Dynamic, Freeze Z).
///   2. Tag: "Enemy"
///   3. Attach this script.
///   4. Assign SpawnPoint in Inspector (or leave empty to use start position).
/// </summary>
public sealed class EnemyChaser : MonoBehaviour
{
    [SerializeField] private float     _speed = 3f;
    [SerializeField] private Transform _spawnPoint;

    private Rigidbody2D _rb;
    private Transform   _player;
    private Vector2     _spawnPosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        _rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        _spawnPosition = _spawnPoint != null
            ? (Vector2)_spawnPoint.position
            : (Vector2)transform.position;
    }

    private void Start()
    {
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null) _player = p.transform;
    }

    private void FixedUpdate()
    {
        if (_player == null) return;
        Vector2 dir = ((Vector2)_player.position - _rb.position).normalized;
        _rb.MovePosition(_rb.position + dir * _speed * Time.fixedDeltaTime);
    }

    public void ResetToSpawn()
    {
        _rb.linearVelocity = Vector2.zero;
        _rb.position       = _spawnPosition;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Mine"))
        {
            Destroy(col.gameObject);
            ResetToSpawn();
            return;
        }

        if (col.gameObject.CompareTag("Player"))
        {
            ResetToSpawn();
        }
    }
}