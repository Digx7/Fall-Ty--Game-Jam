using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nameOfMainScene;

    public void onClickPlay(){
       SceneManager.LoadScene(nameOfMainScene);
    }

    public void onClickQuit(){
      Debug.Log("Quiting the game");
      Application.Quit();
    }
}
