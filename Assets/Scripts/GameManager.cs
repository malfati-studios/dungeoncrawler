using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject _battleHandlerPrefab;
    private BattleHandler _currentBattleHandler;
    
    public void StartBattle(Enemy enemy)
    {
        _currentBattleHandler = Instantiate(_battleHandlerPrefab).GetComponent<BattleHandler>();
        _currentBattleHandler.Init(enemy);
        UIController.instance.StartBattle(_currentBattleHandler);
    }
    
    public void EndBattle()
    {
        Destroy(_currentBattleHandler.gameObject);
        _currentBattleHandler = null;
        UIController.instance.EndBattle();
        PlayerController.instance.ResumeMovement();
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
