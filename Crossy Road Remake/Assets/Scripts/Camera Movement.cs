using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour{

    public PlayerMovement player;
    [SerializeField] GameObject cat;
    public delegate void Death();
    public static event Death CameraDeath;

    bool isDead=>player.isDead;

    private void Update(){
        Vector3 pos = new Vector3(0, 0, player.transform.position.z);
        if (transform.position.z-Params.Instance.DstncB4Die>player.transform.position.z&&isDead==false){
            CameraDeath();
        }else if(player.transform.position.z>=transform.position.z+Params.Instance.DstncB4FllwPlayer &&isDead==false){
            transform.Translate(pos* Time.deltaTime * Params.Instance.FollowPlayerSpeed, Space.World);                       
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
        Vector3 pos =new Vector3(player.transform.position.x,player.transform.position.y+1,player.transform.position.z+14);
        Instantiate(cat,pos ,Quaternion.Euler(0f,180f,0f));
    }


}
