using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Rigidbody))]
public abstract class MovingEntity : MonoBehaviour
{
    [SerializeField] protected float Speed;

    protected Mover Mover;

    private void Awake()
    {
        Mover = GetComponent<Mover>();
    }

    protected abstract void Move();
}
