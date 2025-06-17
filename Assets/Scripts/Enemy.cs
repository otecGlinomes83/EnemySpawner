using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    public void Initialize(Vector3 route)
    {
        _mover.StartMove(route, _speed);
    }
}