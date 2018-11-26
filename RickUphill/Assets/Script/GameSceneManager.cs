using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameSceneManager : MonoBehaviour {

    // Script used to manage scenes in the game

    public string splash;
    public string menu;
    public string credits;
    public string game;
    public string game_over;

    public static GameSceneManager Instance { get; set; }

    public static string[] Levels = { "splash", "menu", "credits", "game", "gameover" };

    private static int _level;
    public static int Level
    {
        get { return _level; }
        set
        {
            SceneManager.LoadScene(Levels[value], LoadSceneMode.Single);
            _level = value;
        }
    }

    private void Awake()
    {
        Screen.SetResolution(1000, 1920, true);
    }

    IEnumerator Start()
    {
        //caso um outro script do GameManager for adicionado a um objeto acidentalmente,
        //essas linhas irão previnir que ele exista em duplicidade
        if (Instance != null)
            Destroy(this);
        Instance = this;

        //do not destroy the object upon loading other scenes
        DontDestroyOnLoad(gameObject);
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(splash, LoadSceneMode.Single);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(menu, LoadSceneMode.Single);
    }

    public static void LoadLevel(int level)
    {
        Level = level;
    }
}
