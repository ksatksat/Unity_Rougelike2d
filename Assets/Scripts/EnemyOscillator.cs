using UnityEngine; // rougelike/scripts => EnemyOscillator.cs
//oscillator это излучтель. В данном случае это враг, который колеблется вверх-вниз.
public sealed class EnemyOscillator : MonoBehaviour
{
    [SerializeField] private float _amplitude = 2f;   // units up/down
    [SerializeField] private float _frequency = 1f;  // cycles per second

    private Vector2 _origin;

    private void Awake() => _origin = transform.position;

    private void Update()
    {
        float y = _origin.y + _amplitude * Mathf.Sin(2f * Mathf.PI * _frequency * Time.time);
        transform.position = new Vector2(_origin.x, y);
    }
}