using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _newPosition;
    private Vector3 _startPosition;
    private bool _isLeftMoving;
    private float _scaleAmount;
    private float _minScaleAmount;
    private float _maxScaleAmount;
    private bool _isGrowing;

    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotateAngle;
    [SerializeField] private float _growSpeed;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _startPosition = _transform.position;
        _newPosition = new Vector3(_startPosition.x - _distance, _startPosition.y, _startPosition.z);
        _isLeftMoving = false;
        _scaleAmount = 4f;
        _minScaleAmount = 4f;
        _maxScaleAmount = 6f;
        _isGrowing = true;
    }

    private void Update()
    {
        MoveCube();
    }

    private void MoveCube()
    {
        float step = _speed * Time.deltaTime;

        if (_transform.position == _newPosition)
            SetNewPosition();

        _transform.position = Vector3.MoveTowards(_transform.position, _newPosition, step);
        GrowCube();
        RotateCube();
    }

    private void RotateCube()
    {
        _transform.Rotate(0f, _rotateAngle * Time.deltaTime * _rotationSpeed, 0f);
    }

    private void SetNewPosition()
    {
        _newPosition = new Vector3(_isLeftMoving ? _startPosition.x + _distance : _startPosition.x - _distance, _startPosition.y, _startPosition.z);
        _isLeftMoving = !_isLeftMoving;
    }

    private void GrowCube()
    {
        if (_isGrowing)
        {
            if (_transform.localScale.x < _maxScaleAmount)
                _transform.localScale += new Vector3(_scaleAmount, _scaleAmount, _scaleAmount) * _growSpeed * Time.deltaTime;
            else
                _isGrowing = false;
        }
        else
        {
            if (_transform.localScale.x > _minScaleAmount)
                _transform.localScale -= new Vector3(_scaleAmount, _scaleAmount, _scaleAmount) * _growSpeed * Time.deltaTime;
            else
                _isGrowing = true;
        }
    }
}
