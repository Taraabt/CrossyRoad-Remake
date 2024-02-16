using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    private bool w,a,s,d;
    private bool w1,a1,s1,d1;
    private bool hitsome,isDead;
    //[SerializeField]Material material;
    private void Start(){
        isDead = false;
    }

    void Update(){
        RaycastHit hit;



        //Color customColor = new Color(1f, 1f, 1f, 0f);
        //material.SetColor("_Color", customColor);

        w =Input.GetKeyUp(KeyCode.W);
        s = Input.GetKeyUp(KeyCode.S);
        d = Input.GetKeyUp(KeyCode.D);
        a = Input.GetKeyUp(KeyCode.A);
        w1 = Input.GetKeyDown(KeyCode.W);
        s1 = Input.GetKeyDown(KeyCode.S);
        d1 = Input.GetKeyDown(KeyCode.D);
        a1 = Input.GetKeyDown(KeyCode.A);

        Vector3 rayCastPos = new Vector3(transform.position.x, transform.position.y +0.5f, transform.position.z);

        if (w && isDead==false){
            transform.forward = Vector3.forward;
            hitsome = Physics.Raycast(rayCastPos, transform.forward, out hit, 1f,1<<6);
            if (hitsome == false){
                transform.Translate(Vector3.forward);
            }
        }
        if (s && isDead == false){
            transform.forward = Vector3.back;
            hitsome = Physics.Raycast(rayCastPos, transform.forward, out hit, 1f,1<<6);
            if (hitsome == false){
                transform.Translate(Vector3.forward);
            }
        }
        if (d && isDead == false){
            transform.forward = Vector3.right;
            hitsome = Physics.Raycast(rayCastPos, transform.forward, out hit, 1f,1<<6);
            if (hitsome==false){
                transform.Translate(Vector3.forward);
            }
        }
        if (a && isDead == false){
            transform.forward = Vector3.left;
            hitsome = Physics.Raycast(rayCastPos, transform.forward, out hit, 1f,1<<6);
            if (hitsome==false){
                transform.Translate(Vector3.forward);
            }
        }

        if (w1 && isDead == false){
            transform.forward=Vector3.forward;
        }
        if (s1 && isDead == false){
            transform.forward = Vector3.back;
        }
        if (d1 && isDead == false){
            transform.forward= Vector3.right;
        }
        if (a && isDead == false){
            transform.forward= Vector3.left;
        }
    }
    void OnEnable(){
        CameraMovement.CameraDeath += StopMovement;
        MoveCar.VeichleDeath += StopMovement;
        River.RiverDeath += StopMovement;
        MoveTrain.TrainDeath += StopMovement;
    }

    void OnDisable(){
        MoveTrain.TrainDeath -= StopMovement;
        River.RiverDeath -= StopMovement;
        CameraMovement.CameraDeath -= StopMovement;
        MoveCar.VeichleDeath -= StopMovement;
    }

    public void StopMovement(){
        isDead = true;
        //this.gameObject.SetActive(false);
    }

     
}
