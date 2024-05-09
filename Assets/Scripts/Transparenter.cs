using UnityEngine;

public class Transparenter : MonoBehaviour
{
    [SerializeField] Material _material;

    private Color _currentColor;
    private Color _newColor;
    private float _zeroTransparencyValue = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _currentColor = _material.color;
            _newColor = _currentColor;
            _newColor.a = _zeroTransparencyValue;
            _material.color = _newColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _material.color = _currentColor;
    }
}
