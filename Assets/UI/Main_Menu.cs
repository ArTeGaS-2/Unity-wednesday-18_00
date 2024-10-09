using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void Start_Game()
    {
        //Scene inGame = SceneManager.GetSceneAt(1);
        SceneManager.LoadScene(1);
    }
}
