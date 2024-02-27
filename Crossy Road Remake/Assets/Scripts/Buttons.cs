using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour{


    [SerializeField]Canvas canvas;
    public PlayerMovement player;
    public void SceneReload(){
        SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        player.CanMove();
        canvas.gameObject.SetActive(false);
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
