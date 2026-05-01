using UnityEngine;

/// <summary>
/// Obstacle that scales up and down between a min and max size.
/// When the Player touches it, the level restarts via GameManager.
///
/// Setup:
///   1. Create a GameObject with a BoxCollider2D (NOT trigger).
///   2. Add a SpriteRenderer (any rectangle sprite, e.g. orange/red).
///   3. Tag it "Enemy".
///   4. Attach this script.
///   5. Tune Min Scale, Max Scale, and Speed in the Inspector.
///
/// Pivot:
///   Scales around the GameObject's own pivot (center by default).
///   To scale from an edge, nest the sprite as a child and offset it.
/// </summary>
public sealed class ScalingObstacle : MonoBehaviour
{
    [SerializeField] private Vector2 _minScale   = new(0.5f, 0.5f);  // smallest size
    [SerializeField] private Vector2 _maxScale   = new(2.5f, 2.5f);  // largest size
    [SerializeField] private float   _speed      = 1.5f;             // cycles per second
    [SerializeField] private float   _phaseOffset = 0f;              // stagger multiple obstacles (0–1)

    private void Update()
    {
        // Oscillates between 0 and 1 using a sine wave
        float t = (Mathf.Sin(2f * Mathf.PI * _speed * Time.time + _phaseOffset * 2f * Mathf.PI) + 1f) / 2f;

        float x = Mathf.Lerp(_minScale.x, _maxScale.x, t);
        float y = Mathf.Lerp(_minScale.y, _maxScale.y, t);

        transform.localScale = new Vector3(x, y, 1f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            GameManager.Instance.PlayerDied();
    }
}