using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{

    public delegate void Death();
    public static event Death PlayerDeath;
    public Canvas PauseMenu;

    private void Update(){
        GameObject player = GameObject.Find("Chicken");
        if(transform.position.z-Params.Instance.DstncB4Die>player.transform.position.z){
                PlayerDeath();
        }else if(player.transform.position.z>=transform.position.z+Params.Instance.DstncB4FllwPlayer){
            transform.Translate(player.transform.position * Time.deltaTime * Params.Instance.FollowPlayerSpeed, Space.World);
        }
        else{
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
