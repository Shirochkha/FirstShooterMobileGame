using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    //ѕќ–яƒќ  ¬ј∆≈Ќ
    public UnityEngine.UI.Button startButton;
    public UnityEngine.UI.Button exitButton;
    public GameObject menu;
    public UnityEngine.UI.Button restartButton;
    public UnityEngine.UI.Text scoreLabel;
    

    public static int score = 0; //static позвол€ет вписывать проще в другой код

    public static bool isStarted = false; //игра не запущена

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(delegate {
            menu.SetActive(false);
            score = 0;
            Time.timeScale = 1f;
            isStarted = true;
        });
        exitButton.onClick.AddListener(delegate {
            Application.Quit();
        });
        restartButton.onClick.AddListener(delegate {
            SceneManager.LoadScene(0);
            Time.timeScale = 0;
        });

        //Time.timeScale - скорость игры. можно =0 и она остановитьс€
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.Escape))  // если нажата клавиша Esc (Escape)
        {
            Application.Quit();    // закрыть приложение
        }
    }

}
