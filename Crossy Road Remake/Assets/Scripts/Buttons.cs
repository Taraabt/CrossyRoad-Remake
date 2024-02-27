using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour{


    [SerializeField]Button button1;
    [SerializeField] Button button2;
    public PlayerMovement player;
    public void SceneReload(){
        SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        player.CanMove();
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }

    public void BackToGame()
    {
        SceneManager.LoadScene(0);
    }
    public void SkinScene()
    {
        SceneManager.LoadScene(2);
    }

}
