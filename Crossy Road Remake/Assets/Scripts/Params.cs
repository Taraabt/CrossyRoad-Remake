using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Params : MonoBehaviour{

    public static Params Instance;

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    [Header ("Player")]
    [SerializeField] float speed;
    public float Speed{get{ return speed;}}



}
