using UnityEngine;

public class CapsuleChangeSize : MonoBehaviour
{
    private Transform _transform;
    private float _scaleAmount;
    private float _minScaleAmount;
    private float _maxScaleAmount;
    private bool _isGrowing;

    [SerializeField] private float _speed;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _scaleAmount = 2f;
        _minScaleAmount = 4f;
        _maxScaleAmount = 6f;
        _isGrowing = true;
    }

    private void Update()
    {
        if (_isGrowing)
        {
            if (_transform.localScale.x < _maxScaleAmount)
                _transform.localScale += new Vector3(_scaleAmount, _scaleAmount, _scaleAmount) * _speed * Time.deltaTime;
            else
                _isGrowing = false;
        }
        else
        {
            if (_transform.localScale.x > _minScaleAmount)
                _transform.localScale -= new Vector3(_scaleAmount, _scaleAmount, _scaleAmount) * _speed * Time.deltaTime;
            else
                _isGrowing = true;
        }
    }
}