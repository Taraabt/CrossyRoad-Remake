using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{

    public delegate void Death();
    public static event Death PlayerDeath;
    public Canvas PauseMenu;

    private void Update(){
        GameObject player = GameObject.Find("Chicken");
        //transform.Translate(Vector3.forward * Time.deltaTime * Params.Instance.CameraSpeed ,Space.World);
        if(transform.position.z-3>player.transform.position.z){
                PlayerDeath();
        }else{
            transform.Translate(Vector3.forward * Time.deltaTime * Params.Instance.CameraSpeed, Space.World);
        }
        /*quando player si muove la camera lo segue se e di x piu avanti 
         * se telecamera e piu avanti di x al player player muore
        */

    }

    void OnEnable(){
        CameraMovement.PlayerDeath += KillPlayer;
    }

    void OnDisable(){
        CameraMovement.PlayerDeath -= KillPlayer;
    }

    void KillPlayer(){
        PauseMenu.gameObject.SetActive(true);
    }


}
