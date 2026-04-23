using UnityEngine;

/// <summary>
/// Attach to a 2D rectangle that should spin around its own pivot.
/// When the Player touches it, the level restarts via GameManager.
///
/// Setup:
///   1. Create a GameObject with a BoxCollider2D (NOT trigger).
///   2. Add a SpriteRenderer (e.g. red or dark sprite so it reads as danger).
///   3. Attach this script.
///   4. Tag the GameObject as "Enemy" — PlayerController already listens for that tag.
///      (Or use the OnCollisionEnter2D override below instead.)
///
/// Pivot:
///   The rectangle rotates around its own Transform origin.
///   To offset the pivot, nest the sprite/collider inside a parent and
///   move the child; then attach this script to the parent.
/// </summary>
public sealed class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private float _degreesPerSecond = 90f;   // rotation speed
    [SerializeField] private bool  _clockwise         = true; // direction

    private void Update()
    {
        float direction = _clockwise ? -1f : 1f;
        transform.Rotate(0f, 0f, direction * _degreesPerSecond * Time.deltaTime);
    }

    // Optional: handle collision here instead of relying on the "Enemy" tag.
    // If you prefer this, remove the tag requirement from PlayerController.
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            GameManager.Instance.PlayerDied();
    }
}