using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject levelButtons;
    private void Start()
    {
        startButton.SetActive(true);
        levelButtons.SetActive(false);
    }
    public void Start_Game()
    {
        startButton.SetActive(false);
        levelButtons.SetActive(true);
    }
    public void LoadLevel_1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel_2()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel_3()
    {
        SceneManager.LoadScene(3);
    }

}
