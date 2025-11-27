using UnityEngine;

public class Skeleton : Enemy
{
    private void FixedUpdate()
    {
        enemyMovement?.MoveToTarget(enemyView.playerPosition);
    }
}
