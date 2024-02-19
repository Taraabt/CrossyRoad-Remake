using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour{

    private bool w,a,s,d;
    private bool w1,a1,s1,d1;
    private bool hitsome;
    public bool isGrounded,isDead;

    public Canvas PauseMenu;
    private void Start(){
        isDead = false;
        isGrounded = true;
    }

    void Update()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.up * -0.1f, out hit, 1f, 1 << 7);
        Debug.DrawRay(transform.position + Vector3.up * 0.5f, transform.up * -1f,Color.red);
        if (isGrounded == false)
        {
            //EditorApplication.isPaused = true;
        }



        
        w = Input.GetKeyUp(KeyCode.W);
        s = Input.GetKeyUp(KeyCode.S);
        d = Input.GetKeyUp(KeyCode.D);
        a = Input.GetKeyUp(KeyCode.A);
        w1 = Input.GetKeyDown(KeyCode.W);
        s1 = Input.GetKeyDown(KeyCode.S);
        d1 = Input.GetKeyDown(KeyCode.D);
        a1 = Input.GetKeyDown(KeyCode.A);

        Vector3 raycastPos=new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, transform.position.z);
        if (w && !isDead && isGrounded){
            transform.forward = Vector3.forward;
            hitsome = Physics.Raycast(raycastPos, transform.forward, 1f, 1 << 6);
            if (hitsome == false){
                transform.Translate(Vector3.forward);               
            }
        }
        if (s && !isDead && isGrounded)
        {
            transform.forward = Vector3.back;
            hitsome = Physics.Raycast(raycastPos, transform.forward, 1f, 1 << 6);
            if (hitsome == false)
            {
                transform.Translate(Vector3.forward);
            }
        }
            if (d && !isDead && isGrounded)
            {
                transform.forward = Vector3.right;
                hitsome = Physics.Raycast(raycastPos, transform.forward, 1f, 1 << 6);
                if (hitsome == false)
                {
                    transform.Translate(Vector3.forward);
                }
            }
            if (a && !isDead && isGrounded)
            {
                transform.forward = Vector3.left;
                hitsome = Physics.Raycast(raycastPos, transform.forward, 1f, 1 << 6);
                if (hitsome == false)
                {
                    transform.Translate(Vector3.forward);
                }
            }

            if (w1 && isDead == false)
            {
                transform.forward = Vector3.forward;
            }
            if (s1 && isDead == false)
            {
                transform.forward = Vector3.back;
            }
            if (d1 && isDead == false)
            {
                transform.forward = Vector3.right;
            }
            if (a && isDead == false)
            {
                transform.forward = Vector3.left;
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
        PauseMenu.gameObject.SetActive(true);
        isDead = true;
        GetComponent<Rigidbody>().isKinematic=true;
        GetComponent<Collider>().enabled= false;
        //this.gameObject.SetActive(false);
    }

    public void OnLogExit()
    {
        isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.up * -0.1f, 1f, 1 << 7);
        if (!isGrounded) {
            River.TriggerRiverDeath();
        }


    }


}
