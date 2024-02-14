using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour{
    
    public delegate void Death();
    public static event Death RiverDeath;


    private void OnTriggerEnter(Collider other){
        RiverDeath();
    }
    void OnEnable(){
        CameraMovement.CameraDeath += KillPlayer;
        RiverDeath += KillPlayer;
    }

    void OnDisable(){
        RiverDeath -= KillPlayer;
        CameraMovement.CameraDeath -= KillPlayer;
    }

    void KillPlayer(){
        //animazione 
        Debug.Log("River Death");
    }
}
