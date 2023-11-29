using UnityEngine;

public class CubeRoatation : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(0f,10f * Time.deltaTime * _speed,0f);
    }
}
