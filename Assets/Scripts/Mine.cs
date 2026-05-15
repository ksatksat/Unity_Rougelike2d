using UnityEngine;

/// <summary>
/// Blue mine — NO collision logic here at all.
/// EnemyChaser detects the "Mine" tag and destroys this object itself.
///
/// Setup:
///   1. GameObject → SpriteRenderer (blue) + BoxCollider2D (NOT trigger).
///   2. Tag: "Mine"  ← critical
///   3. NO Rigidbody2D needed.
///   4. Attach this script (it's just a tag carrier now).
///   5. Save as Prefab, assign to MineManager.
/// </summary>
public sealed class Mine : MonoBehaviour { }