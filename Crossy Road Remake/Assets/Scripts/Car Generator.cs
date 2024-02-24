using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour{

    [SerializeField] GameObject[] car;
    float remainingTime;
    float randomTime;
    int random;


    void Start(){
        randomTime = Random.Range(Params.Instance.MinCarTimer, Params.Instance.MaxCarTimer);
        remainingTime = randomTime;
        random = Random.Range(0, car.Length);
    }

    void Update(){
        remainingTime -= Time.deltaTime;
        if(remainingTime<=0){
            GameObject c;
            remainingTime = randomTime;
            c=Instantiate(car[random],transform.position,Quaternion.identity);
            c.transform.right = transform.right;
        }
    }

}
