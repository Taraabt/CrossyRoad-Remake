using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour{

    [SerializeField] GameObject[] car;
    float remainingTime=Time.deltaTime;
    int random;

    void Start(){
        random = Random.Range(0, car.Length);
    }

    void Update(){
        remainingTime -= Time.deltaTime;
        if (remainingTime<=0){
            GameObject c;
            remainingTime = 4f;
            c=Instantiate(car[random],transform.position,Quaternion.identity);
            c.transform.right = transform.right;
        }
    }

}
