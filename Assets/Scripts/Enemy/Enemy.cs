using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private EnemyType _enemyType;

    public EnemyType EnemyType => _enemyType;
    public IHP hP    { get; private set; }
    public IEnemyMovement enemyMovement { get; private set; }
    public EnemyCombat enemyCombat { get; private set; }
    public EnemyView enemyView { get; private set; }



    private void Awake()
    {
        hP = GetComponent<EnemyHP>(); 
        enemyMovement = GetComponent<EnemyMovement>();
        enemyCombat = GetComponent<EnemyCombat>();
        enemyView = GetComponent<EnemyView>();
    }
    
}


public enum EnemyType
{
    Skeleton, Spider, Bat
}