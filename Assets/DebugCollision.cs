using UnityEngine;

/// <summary>
/// Attach this to EnemyChaser GameObject temporarily.
/// It will print EVERYTHING the enemy touches to the Console.
/// This tells us exactly what is (or isn't) being detected.
/// </summary>
public sealed class DebugCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log($"[DEBUG] OnCollisionEnter2D hit: '{col.gameObject.name}' | Tag: '{col.gameObject.tag}'");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log($"[DEBUG] OnTriggerEnter2D hit: '{col.gameObject.name}' | Tag: '{col.gameObject.tag}'");
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log($"[DEBUG] OnCollisionStay2D staying on: '{col.gameObject.name}' | Tag: '{col.gameObject.tag}'");
    }
}