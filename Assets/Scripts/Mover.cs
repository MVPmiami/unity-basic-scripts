using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotateAngle;

    private Vector3 _newPosition;
    private Vector3 _startPosition;
    private float _distanceTraveled;
    private bool _isLeftMoving;
    private float _rotationAmount;

    private void Start()
    {
        _startPosition = transform.position;
        _newPosition = new Vector3(_startPosition.x - _distance, _startPosition.y, _startPosition.z);
        _isLeftMoving = true;
        _distanceTraveled = 0f;
    }

    private void Update()
    {
        MoveSphere();
    }

    private void MoveSphere()
    {
        float step = _speed * Time.deltaTime;

        if (transform.position == _newPosition)
            SetNewPosition();

        transform.position = Vector3.MoveTowards(transform.position, _newPosition, step);
        _distanceTraveled += step;
        RotateSphere();
    }

    private void RotateSphere()
    {
        _rotationAmount = (_distanceTraveled / _distance) * (_isLeftMoving ? _rotateAngle : -_rotateAngle);
        transform.Rotate(Vector3.forward, _rotationAmount * Time.deltaTime * _rotationSpeed);
    }

    private void SetNewPosition()
    {
        _newPosition = new Vector3(_isLeftMoving ? _startPosition.x + _distance : _startPosition.x - _distance, _startPosition.y, _startPosition.z);
        _isLeftMoving = !_isLeftMoving;
        _distanceTraveled = 0f;
    }
}