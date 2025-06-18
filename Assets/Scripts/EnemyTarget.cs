using UnityEngine;

public class EnemyTarget : MovingEntity
{
    [SerializeField] private Transform[] _wayPoints;

    private int _currentWayPoint = 0;

    private void OnEnable()
    {
        Mover.DestinationReached += SetWayPoint;
    }

    private void Start()
    {
        Move();
    }

    private void OnDisable()
    {
        Mover.DestinationReached -= SetWayPoint;
    }

    private void SetWayPoint()
    {
        _currentWayPoint = (_currentWayPoint + 1) % _wayPoints.Length;

        Move();
    }

    protected override void Move()
    {
        if (_wayPoints.Length == 0)
            return;

        Mover.StartMove(_wayPoints[_currentWayPoint], Speed);
    }
}
