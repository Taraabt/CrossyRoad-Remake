using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogGenerator : MonoBehaviour{

    [SerializeField] GameObject[] log;
    float remainingTime = 0f;
    float randomTime;
    public float logspeed { get; set; }

    private void Start(){
        randomTime = Random.Range(Params.Instance.MinLogTimer, Params.Instance.MaxLogTimer);
        Debug.Log(randomTime);
    }
    void Update(){
        int logLength;
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0){
            Vector3 pos= new Vector3 (transform.position.x, transform.position.y , transform.position.z);
            logLength = Random.Range(0, log.Length);
            GameObject c;
            remainingTime = randomTime;
            c = Instantiate(log[logLength], pos, Quaternion.identity);
            c.transform.right = transform.right;
        }
    }

}
