using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
