using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogGenerator : MonoBehaviour{

    [SerializeField] GameObject[] log;
    float remainingTime = 0f;
    public float randomTime;
    public float logspeed;

    private void Start(){
        randomTime = Random.Range(Params.Instance.MinLogTimer, Params.Instance.MaxLogTimer);
        Debug.Log(randomTime);
    }
    private void Awake()
    {
        logspeed = Random.Range(Params.Instance.MinLogSpeed, Params.Instance.MaxLogSpeed);
    }
    void Update(){
        int logLength;
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0){
            Vector3 pos= new Vector3 (transform.position.x, transform.position.y , transform.position.z);
            logLength = Random.Range(0, log.Length);
            GameObject c;
            remainingTime = Random.Range(Params.Instance.MinLogTimer, Params.Instance.MaxLogTimer); ;
            c = Instantiate(log[logLength], pos, Quaternion.identity);
            c.transform.SetParent(transform);
            c.transform.right = transform.right;
        }
    }

}
