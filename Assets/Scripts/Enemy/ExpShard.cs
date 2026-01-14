using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ExpShard : Drop
{
    [SerializeField] private float _expCount = 10;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerLevel>(out var playerLvl))
        {
            GiveExp(playerLvl);
        }
    }

    private void GiveExp(PlayerLevel playerLvl)
    {
        playerLvl.AddExperience(_expCount);
        gameObject.SetActive(false);
    }
}


