using UnityEngine;

/// <summary>
/// Same as before — no changes required.
/// ExitPortal uses OnTriggerEnter2D on its own GameObject,
/// so PlayerController doesn't need to know about scene transitions.
/// RotatingObstacle is tagged "Enemy", so the existing collision
/// check here will call GameManager.PlayerDied() automatically.
/// </summary>
public sealed class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _rb;
    private Vector2 _input;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        _input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
    }

    private void FixedUpdate() => _rb.linearVelocity = _input * _speed;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
            GameManager.Instance.PlayerDied();
    }
}