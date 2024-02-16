using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogGenerator : MonoBehaviour{

    [SerializeField] GameObject[] log;
    float remainingTime = 0f;

    void Update(){
        int random;
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0){
            Vector3 pos= new Vector3 (transform.position.x, transform.position.y , transform.position.z);
            random = Random.Range(0, log.Length);
            GameObject c;
            remainingTime = Params.Instance.LogTimer;
            c = Instantiate(log[random], pos, Quaternion.identity);
            c.transform.right = transform.right;
        }
    }

}
