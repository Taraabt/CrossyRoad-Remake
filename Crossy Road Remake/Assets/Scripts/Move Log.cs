using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLog : MonoBehaviour{

    void Update(){
        GameObject player = GameObject.Find("Chicken");
        transform.Translate(Vector3.right * Time.deltaTime * Params.Instance.LogSpeed, Space.Self);
        if (transform.position.x >= 10f || transform.position.x <= -10f){
            Destroy(gameObject);
        }
    }

}
