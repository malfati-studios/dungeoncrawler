using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int attackValue;

    public bool Died()
    {
        return hp < 0;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    public int Attack()
    {
        return attackValue;
    }
}