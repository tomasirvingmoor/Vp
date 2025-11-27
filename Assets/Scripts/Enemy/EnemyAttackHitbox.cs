using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    public PlayerHP PlayerHP { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHP hp))
            PlayerHP = hp;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHP hp) && hp == PlayerHP)
            PlayerHP = null;
    }
}
