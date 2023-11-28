using UnityEngine;

public class CubeRoatation : MonoBehaviour
{
    private Transform _transform;

    [SerializeField] private float _speed;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Rotate(0f,10f * Time.deltaTime * _speed,0f);
    }
}
