using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    private bool w,a,s,d;
    private bool w1,a1,s1,d1;
    private bool hitsome,isDead,isGrounded;
    private void Start(){
        Rigidbody rb = GetComponent<Rigidbody>();
        isDead = false;
        isGrounded = true;
    }

    void Update(){
        if (isGrounded==false){
            isDead = true;
        }

        RaycastHit hit;
        w =Input.GetKeyUp(KeyCode.W);
        s = Input.GetKeyUp(KeyCode.S);
        d = Input.GetKeyUp(KeyCode.D);
        a = Input.GetKeyUp(KeyCode.A);
        w1 = Input.GetKeyDown(KeyCode.W);
        s1 = Input.GetKeyDown(KeyCode.S);
        d1 = Input.GetKeyDown(KeyCode.D);
        a1 = Input.GetKeyDown(KeyCode.A);

        if (w && isDead==false){
            transform.forward = Vector3.forward;
            hitsome = Physics.Raycast(transform.position, transform.forward, 1f,1<<6);
            if (hitsome == false){
                transform.Translate(Vector3.forward);
                isGrounded = Physics.Raycast(transform.position, transform.up * -0.3f, out hit, 1f, 1 << 7);
            }
        }
        if (s && isDead == false){
            transform.forward = Vector3.back;
            hitsome = Physics.Raycast(transform.position, transform.forward, 1f,1<<6);
            if (hitsome == false){
                transform.Translate(Vector3.forward);
                isGrounded = Physics.Raycast(transform.position, transform.up * -0.3f, out hit, 1f, 1 << 7);
            }
        }
        if (d && isDead == false){
            transform.forward = Vector3.right;
            hitsome = Physics.Raycast(transform.position, transform.forward, 1f,1<<6);
            if (hitsome==false){
                transform.Translate(Vector3.forward);
                isGrounded = Physics.Raycast(transform.position, transform.up * -0.3f, out hit, 1f, 1 << 7);
            }
        }
        if (a && isDead == false){
            transform.forward = Vector3.left;
            hitsome = Physics.Raycast(transform.position, transform.forward, 1f,1<<6);
            if (hitsome==false){
                transform.Translate(Vector3.forward);
                isGrounded = Physics.Raycast(transform.position, transform.up * -0.3f, out hit, 1f, 1 << 7);
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
