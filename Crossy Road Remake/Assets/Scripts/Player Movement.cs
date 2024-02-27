using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour{

    private bool w,a,s,d;
    private bool w1,a1,s1,d1;
    private bool hitsome;
    public bool isGrounded, isDead;
    public TMP_Text text;
    int currentScen=1;
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public Canvas PauseMenu;
    private void Start(){
        int y = SceneManager.GetActiveScene().buildIndex;
        if(y ==1){
            isDead = false;
        }
        else
        {
            isDead = true;
        }

        isGrounded = true;
    }


    public void CanMove()
    {
        isDead = false;
    }
    void Update()
    {

        


        if (isDead==false){
            string score;
            float score2 =(int) transform.position.z+ 0.5f;     
            score = ((int) score2).ToString();
            text.text = "Score: " + score;
        }

        isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.up * -0.1f, 1f, 1 << 7);
        Debug.DrawRay(transform.position + Vector3.up * 0.5f, transform.up * -1f,Color.red);
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
            hitsome = Physics.Raycast(raycastPos, transform.forward+Vector3.up *0.5f, 1f, 1 << 6);
            Debug.DrawRay(raycastPos, transform.forward,  Color.red);
            if (hitsome == false){
                StartCoroutine(DeSquish());
                //animator.SetTrigger("Moving");
                //StartCoroutine(MoveOverSeconds(transform.gameObject, Vector3.forward, 0.917f));
                transform.Translate(Vector3.forward);
            }
        }
        if (s && !isDead && isGrounded)
        {
            transform.forward = Vector3.back;
            hitsome = Physics.Raycast(raycastPos, transform.forward, 1f, 1 << 6);
            if (hitsome == false)
            {
                StartCoroutine(DeSquish());
                //animator.SetTrigger("Moving");
                transform.Translate(Vector3.forward);
            }
        }
            if (d && !isDead && isGrounded)
            {
                transform.forward = Vector3.right;
                hitsome = Physics.Raycast(raycastPos, transform.forward, 1f, 1 << 6);
                if (hitsome == false)
                {
                StartCoroutine(DeSquish());
                //animator.SetTrigger("Moving");
                transform.Translate(Vector3.forward);
            }
            }
            if (a && !isDead && isGrounded)
            {
                transform.forward = Vector3.left;
                hitsome = Physics.Raycast(raycastPos, transform.forward, 1f, 1 << 6);
                if (hitsome == false)
                {
                StartCoroutine(DeSquish());
                //animator.SetTrigger("Moving");
                transform.Translate(Vector3.forward);
                }
            }

            if (w1 && isDead == false)
            {
                StartCoroutine(Squish());
                transform.forward = Vector3.forward;
            }
            if (s1 && isDead == false)
            {
            StartCoroutine(Squish());
            transform.forward = Vector3.back;
            }
            if (d1 && isDead == false)
            {
            StartCoroutine(Squish());
            transform.forward = Vector3.right;
            }
            if (a && isDead == false)
            {
            StartCoroutine(Squish());
            transform.forward = Vector3.left;
            }
        }
    void OnEnable(){
        CameraMovement.CameraDeath += StopMovement;
        MoveCar.VeichleDeath += StopMovement;
        MoveCar2.MulettoDeath += StopMovement;
        River.RiverDeath += StopMovement;
        MoveTrain.TrainDeath += StopMovement;
    }

    void OnDisable(){
        MoveTrain.TrainDeath -= StopMovement;
        River.RiverDeath -= StopMovement;
        MoveCar2.MulettoDeath -= StopMovement;
        CameraMovement.CameraDeath -= StopMovement;
        MoveCar.VeichleDeath -= StopMovement;
    }

    public void StopMovement(){
        PauseMenu.gameObject.SetActive(true);
        isDead = true;
        GetComponent<Rigidbody>().useGravity = false;
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

    public IEnumerator Squish()
    {
        Vector3 targetScale = Vector3.one*0.8f;
        while (transform.localScale.x>=targetScale.x) {
            transform.localScale -= Vector3.one * 0.01f;
            yield return null;
        }

    }

    public IEnumerator DeSquish()
    {
        Vector3 targetScale = Vector3.one ;
        while (transform.localScale.x < targetScale.x)
        {
            transform.localScale += Vector3.one * 0.01f;
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="World Limit")
        {
            StopMovement();
        }

    }


}
