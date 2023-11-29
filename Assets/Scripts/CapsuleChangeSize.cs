using UnityEngine;

public class CapsuleChangeSize : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _scaleAmount;
    private float _minScaleAmount;
    private float _maxScaleAmount;
    private bool _isGrowing;

    private void Start()
    {
        _scaleAmount = 2f;
        _minScaleAmount = 4f;
        _maxScaleAmount = 6f;
        _isGrowing = true;
    }

    private void Update()
    {
        if (_isGrowing)
        {
            if (transform.localScale.x < _maxScaleAmount)
                transform.localScale += new Vector3(_scaleAmount, _scaleAmount, _scaleAmount) * _speed * Time.deltaTime;
            else
                _isGrowing = false;
        }
        else
        {
            if (transform.localScale.x > _minScaleAmount)
                transform.localScale -= new Vector3(_scaleAmount, _scaleAmount, _scaleAmount) * _speed * Time.deltaTime;
            else
                _isGrowing = true;
        }
    }
}