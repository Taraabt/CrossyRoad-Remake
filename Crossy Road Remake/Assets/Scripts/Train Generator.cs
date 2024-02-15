using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGenerator : MonoBehaviour{

    [SerializeField] GameObject train;
    float remainingTime = 0f;// Random.range;

    void Update(){
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            GameObject c;
            remainingTime = 10f;
            c = Instantiate(train, transform.position, Quaternion.identity);
            c.transform.right = transform.right;
        }
    }
}
