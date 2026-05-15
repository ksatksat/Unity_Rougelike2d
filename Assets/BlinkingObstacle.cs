using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Obstacle that blinks on and off using SetActive(true/false).
/// When the Player touches it while active, the level restarts via GameManager.
///
/// Setup:
///   1. Create a PARENT empty GameObject — attach THIS script to it.
///   2. Create a CHILD GameObject inside it with:
///        - SpriteRenderer (any rectangle sprite, e.g. purple/red)
///        - BoxCollider2D (NOT trigger)
///        - Tag: "Enemy"
///   3. Assign the CHILD to the "Obstacle Visual" field in the Inspector.
///   4. Tune On Duration, Off Duration, and Phase Offset.
///
/// Why parent/child?
///   We disable the CHILD (visual + collider) while keeping the
///   parent (this script) always active so Update() keeps running.
/// </summary>
public sealed class BlinkingObstacle : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacleVisuals = new List<GameObject>();   // child with sprite + collider
    [SerializeField] private float      _onDuration  = 1f; // seconds obstacle is visible/solid
    [SerializeField] private float      _offDuration = 1f; // seconds obstacle is hidden/passable
    [SerializeField] private float      _phaseOffset = 0f; // stagger (seconds) among obstacles

    private float _timer;
    private bool  _isOn;

    private void Awake()
    {
        if (_obstacleVisuals.Count == 0)
        {
            Debug.LogError($"[BlinkingObstacle] '{name}': Obstacle Visual is not assigned!", this);
            enabled = false;
            return;
        }

        // Apply phase offset so obstacles don't all blink in sync
        _timer = _phaseOffset % (_onDuration + _offDuration);

        // Determine starting state based on phase offset
        _isOn = _timer < _onDuration;
        foreach (var go in _obstacleVisuals)
        {
            go.SetActive(_isOn);
        }
        
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_isOn && _timer >= _onDuration)
        {
            _isOn  = false;
            _timer -= _onDuration;
            foreach (var go in _obstacleVisuals)
            {
                go.SetActive(_isOn);
            }
        }
        else if (!_isOn && _timer >= _offDuration)
        {
            _isOn  = true;
            _timer -= _offDuration;
            foreach (var go in _obstacleVisuals)
            {
                go.SetActive(_isOn);
            }
        }
    }
}