using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] private GameObject _battlePanel;
    private BattleHandler _currentBattleHandler;


    public void StartBattle(BattleHandler battleHandler)
    {
        _currentBattleHandler = battleHandler;
        _battlePanel.SetActive(true);
    }

    public void EndBattle()
    {
        _currentBattleHandler = null;
        _battlePanel.SetActive(false);
    }

    public void AttackButtonClicked()
    {
        if (_currentBattleHandler != null)
        {
            _currentBattleHandler.AttackButtonClicked();
        }
    }

    private void Awake()
    {
        instance = this;
    }
}