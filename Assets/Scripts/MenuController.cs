using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController instance = null;
    private Button btnPlay;
    private Button btnQuit;
    private Button btnReiniciar;
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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MenuPrincipal")
        {
            btnPlay = GameObject.Find("PlayBtn").GetComponent<Button>();
            btnPlay.onClick.AddListener(PlayGame);
            btnQuit = GameObject.Find("ExitBtn").GetComponent<Button>();
            btnQuit.onClick.AddListener(QuitGame);
        }
        if(scene.name == "GameOver")
        {
            btnReiniciar = GameObject.Find("ReiniciarBtn").GetComponent<Button>();
            btnReiniciar.onClick.AddListener(PlayGame);
            btnQuit = GameObject.Find("ExitBtn").GetComponent<Button>();
            btnQuit.onClick.AddListener(QuitGame);
        }
        if(scene.name == "Vitoria")
        {
            btnReiniciar = GameObject.Find("ReiniciarBtn").GetComponent<Button>();
            btnReiniciar.onClick.AddListener(Menu);
            btnQuit = GameObject.Find("ExitBtn").GetComponent<Button>();
            btnQuit.onClick.AddListener(QuitGame);
        }
    }

    private void PlayGame()
    {
        string iniciarJogo = SceneUtility.GetScenePathByBuildIndex(2);
        SceneManager.LoadScene(iniciarJogo);
    }

    private void Menu()
    {
        string menu = SceneUtility.GetScenePathByBuildIndex(0);
        SceneManager.LoadScene(menu);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
