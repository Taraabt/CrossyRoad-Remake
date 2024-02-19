using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour{
    
    public delegate void Death();
    public static event Death RiverDeath;

    public static void TriggerRiverDeath() { RiverDeath(); }

    private void OnTriggerEnter(Collider other){
        RiverDeath();
    }
    void OnEnable(){
        RiverDeath += KillPlayer;
    }

    void OnDisable(){
        RiverDeath -= KillPlayer;
    }

    void KillPlayer(){
        //animazione 
        Debug.Log("River Death");
    }
}
