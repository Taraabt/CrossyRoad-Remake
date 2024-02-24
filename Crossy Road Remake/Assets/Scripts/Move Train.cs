using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrain : MonoBehaviour{

    public delegate void Death();
    public static event Death TrainDeath;

    void Update(){
        transform.Translate(Vector3.right * Time.deltaTime * Params.Instance.TrainSpeed, Space.Self);
        if (transform.position.x >= 20f || transform.position.x <= -20f){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other){
        TrainDeath();
    }

    void OnEnable(){
        TrainDeath += KillPlayer;
    }

    void OnDisable(){
        TrainDeath -= KillPlayer;
    }

    void KillPlayer(){
        //deathanimation
        Debug.Log("Player death");
    }
}
