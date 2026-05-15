using UnityEngine;

/// <summary>
/// Visual marker for enemy spawn positions in the editor.
/// Attach to an empty GameObject, then drag that GameObject's
/// Transform into EnemyChaser._spawnPoint in the Inspector.
/// </summary>
public sealed class SpawnPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
        Gizmos.DrawLine(transform.position + Vector3.left  * 0.3f,
                        transform.position + Vector3.right * 0.3f);
        Gizmos.DrawLine(transform.position + Vector3.up    * 0.3f,
                        transform.position + Vector3.down  * 0.3f);
    }
}