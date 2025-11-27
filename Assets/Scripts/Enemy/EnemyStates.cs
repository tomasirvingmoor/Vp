using UnityEngine;
public class EnemyPersecutionState : IEnemyState
{
    public void EnterState(IEnemy thisEnemy)
    {
        // Code to execute when entering the persecution state
    }
    public void ExecuteState(IEnemy thisEnemy)
    {
        // Code to execute while in the persecution state
        ///thisEnemy._enemyMovement.MoveToTarget();
    }
    public void ExitState(IEnemy thisEnemy)
    {
        // Code to execute when exiting the persecution state
    }
}

public class EnemyIdleState : IEnemyState
{
    public void EnterState(IEnemy thisEnemy)
    {
        // Code to execute when entering the idle state
    }
    public void ExecuteState(IEnemy thisEnemy)
    {
        // Code to execute while in the idle state
        Debug.Log("Enemy is idling.");
    }
    public void ExitState(IEnemy thisEnemy)
    {
        // Code to execute when exiting the idle state
    }
}
