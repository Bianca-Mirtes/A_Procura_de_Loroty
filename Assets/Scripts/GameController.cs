using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    public void DeadPlayer()
    {
       Invoke("GameOver", 2f);
    }

    private void GameOver()
    {
        string derrota = SceneUtility.GetScenePathByBuildIndex(1);
        SceneManager.LoadScene(derrota);
    }

    public void LevelEnd()
    {
        string vitoria = SceneUtility.GetScenePathByBuildIndex(3);
        SceneManager.LoadScene(vitoria);
    }
}
