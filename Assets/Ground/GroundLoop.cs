using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _maxWidth = 6f;

    private SpriteRenderer _spriteRenderer;

    private Vector2 _startSize = Vector2.zero;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startSize = _spriteRenderer.size;
    }

    private void Update()
    {
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + _speed * Time.deltaTime, _spriteRenderer.size.y);

        if(_spriteRenderer.size.x > _maxWidth)
        {
            _spriteRenderer.size = _startSize;
        }
    }
}
