using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    //������� �����
    public UnityEngine.UI.Button startButton;
    public UnityEngine.UI.Button exitButton;
    public GameObject menu;
    public UnityEngine.UI.Button restartButton;
    public UnityEngine.UI.Text scoreLabel;
    

    public static int score = 0; //static ��������� ��������� ����� � ������ ���

    public static bool isStarted = false; //���� �� ��������

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

        //Time.timeScale - �������� ����. ����� =0 � ��� ������������
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.Escape))  // ���� ������ ������� Esc (Escape)
        {
            Application.Quit();    // ������� ����������
        }
    }

}
