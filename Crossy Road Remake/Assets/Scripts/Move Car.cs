using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour{

    public delegate void Death();
    public static event Death VeichleDeath;

    void Update(){
        transform.Translate(Vector3.right* Time.deltaTime * Params.Instance.AspiratoreSpeed, Space.Self);
        if (transform.position.x >= 10f || transform.position.x <= -10f){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other){
        VeichleDeath();
    }

    void OnEnable(){
        VeichleDeath += KillPlayer;
    }

    void OnDisable(){
        VeichleDeath -= KillPlayer;
    }

    void KillPlayer(){
        //deathanimation
        Debug.Log("Player death");
    }
}
