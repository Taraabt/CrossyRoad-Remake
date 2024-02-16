using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{

    public delegate void Death();
    public static event Death CameraDeath;
    public Canvas PauseMenu;
    bool isDead=false;

    private void Update(){
        GameObject player = GameObject.Find("Chicken");
        if(transform.position.z-Params.Instance.DstncB4Die>player.transform.position.z){
            CameraDeath();
        }else if(player.transform.position.z>=transform.position.z+Params.Instance.DstncB4FllwPlayer &&isDead==false){
            transform.Translate(player.transform.position * Time.deltaTime * Params.Instance.FollowPlayerSpeed, Space.World);                       
        }
        else if(isDead == false){
            transform.Translate(Vector3.forward * Time.deltaTime * Params.Instance.CameraSpeed, Space.World);
        }

    }

    void OnEnable(){
        MoveTrain.TrainDeath += KillPlayer;
        CameraDeath += KillPlayer;
        River.RiverDeath += KillPlayer;
        MoveCar.VeichleDeath += KillPlayer;
    }

    void OnDisable(){
        MoveTrain.TrainDeath -= KillPlayer;
        CameraDeath -= KillPlayer;
        River.RiverDeath -= KillPlayer;
        MoveCar.VeichleDeath -= KillPlayer;
    }

    void KillPlayer(){
        isDead = true;
        transform.Translate(Vector3.zero);
        PauseMenu.gameObject.SetActive(true);
    }


}
