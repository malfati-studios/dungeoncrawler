using System.Collections;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    private Enemy _enemy;
    private bool _playerTurn = true;
    private bool _enemyAttacking;
    private bool _playerAttacking;

    public void Init(Enemy enemy)
    {
        _enemy = enemy;
        Debug.Log("Hey I'm in a battle!");
    }

    public void AttackButtonClicked()
    {
        if (!_playerTurn) return;
        if (_playerAttacking) return;
        _playerAttacking = true;
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);

        Debug.Log("ATTACKED! " + _enemy.name);
        _enemy.TakeDamage(PlayerStats.instance.GetAttack());
        if (_enemy.Died())
        {
            Destroy(_enemy.gameObject);
            GameManager.instance.EndBattle();
        }

        _playerTurn = false;
        _playerAttacking = false;
    }

    private void Update()
    {
        if (_playerTurn) return;
        if (_enemyAttacking) return;

        _enemyAttacking = true;
        StartCoroutine(EnemyAttack());
    }

    private IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1);
        PlayerStats.instance.TakeDamage(_enemy.Attack());
        _playerTurn = true;
        _enemyAttacking = false;
    }
}