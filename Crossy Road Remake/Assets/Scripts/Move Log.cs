using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLog : MonoBehaviour{

    void Update(){
        transform.Translate(Vector3.right * Time.deltaTime * Params.Instance.CarSpeed, Space.Self);
        if (transform.position.x >= 10f || transform.position.x <= -10f){
            Destroy(gameObject);
        }
    }
}
