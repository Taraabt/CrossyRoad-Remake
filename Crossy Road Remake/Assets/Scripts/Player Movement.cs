using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    private float speed;
    private bool w,a,s,d;
    private bool w1,a1,s1,d1;
    private bool hitsome;

    void Update(){
        RaycastHit hit;
        
        w =Input.GetKeyUp(KeyCode.W);
        s = Input.GetKeyUp(KeyCode.S);
        d = Input.GetKeyUp(KeyCode.D);
        a = Input.GetKeyUp(KeyCode.A);
        w1 = Input.GetKeyDown(KeyCode.W);
        s1 = Input.GetKeyDown(KeyCode.S);
        d1 = Input.GetKeyDown(KeyCode.D);
        a1 = Input.GetKeyDown(KeyCode.A);

        if (w){
            transform.forward = Vector3.forward;
            hitsome = Physics.Raycast(transform.position, transform.forward, out hit, 1f);
            if (hitsome == false){
                transform.Translate(Vector3.forward);
            }
        }
        if (s){
            transform.forward = Vector3.back;
            hitsome = Physics.Raycast(transform.position, transform.forward, out hit, 1f);
            if (hitsome == false){
                transform.Translate(Vector3.forward);
            }
        }
        if (d){
            transform.forward = Vector3.right;
            hitsome = Physics.Raycast(transform.position, transform.forward, out hit, 1f);
            if (hitsome==false){
                transform.Translate(Vector3.forward);
            }
        }
        if (a){
            transform.forward = Vector3.left;
            hitsome = Physics.Raycast(transform.position, transform.forward, out hit, 1f);
            if (hitsome==false){
                transform.Translate(Vector3.forward);
            }
        }

        if (w1){
            transform.forward=Vector3.forward;
        }
        if (s1){
            transform.forward = Vector3.back;
        }
        if (d1){
            transform.forward= Vector3.right;
        }
        if (a1){
            transform.forward= Vector3.left;
        }
    }
    

}
