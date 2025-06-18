public class Enemy : MovingEntity
{
    private EnemyTarget _enemyTarget;

    public void StartMoveToTarget(EnemyTarget target)
    {
        _enemyTarget = target;
        Move();
    }

    protected override void Move()
    {
        Mover.StartMove(_enemyTarget.transform, Speed);
    }
}