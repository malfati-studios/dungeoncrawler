using System.Collections;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    private Enemy _enemy;
    private bool playerTurn = true;
    
    public void Init(Enemy enemy)
    {
        _enemy = enemy;
        Debug.Log("Hey I'm in a battle!");
    }

    public void AttackButtonClicked()
    {
        if (!playerTurn) return;
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
       yield return new WaitForSeconds(1);
       Debug.Log("ATTACKED! "+ _enemy.name);
       _enemy.TakeDamage(PlayerStats.instance.GetAttack());
       if (_enemy.Died())
       {
           Destroy(_enemy.gameObject);
           GameManager.instance.EndBattle();
       }
    }
}