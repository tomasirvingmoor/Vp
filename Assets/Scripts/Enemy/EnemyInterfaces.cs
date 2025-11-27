using UnityEngine;

public interface IHP
{
    int maxHP { get;}
    int currentHP { get;}
    void TakeDamage(int damage);
}

public interface IEnemyMovement
{
    float speed { get;}
    void MoveToTarget(Vector2 target);
}

public interface IEnemyState
{
    void EnterState(IEnemy thisEnemy);
    void ExecuteState(IEnemy thisEnemy);
    void ExitState(IEnemy thisEnemy);
}


public interface IEnemy
{
    IHP hP { get; }
    IEnemyMovement enemyMovement { get;}
}


