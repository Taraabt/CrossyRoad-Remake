using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{

    public PlayerMovement player;
    public delegate void Death();
    public static event Death CameraDeath;

    bool isDead=>player.isDead;

    private void Update(){
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
        CameraDeath += KillPlayer;
    }

    void OnDisable(){
        CameraDeath -= KillPlayer;
    }

    void KillPlayer(){
        //aquila
        //transform.Translate(Vector3.zero);
    }


}
