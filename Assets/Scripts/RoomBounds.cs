using UnityEngine;

/// <summary>
/// Attach to an empty GameObject. Draws the room as a gizmo in the editor.
/// The actual walls are four separate BoxCollider2D wall GameObjects.
/// </summary>
public sealed class RoomBounds : MonoBehaviour
{
    [SerializeField] private Vector2 _size = new(18f, 10f);

    public Vector2 Size => _size;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, _size);
    }
}