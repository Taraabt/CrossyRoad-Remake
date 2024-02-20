using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustAfterRiver : MonoBehaviour{

    private void OnCollisionEnter(Collision collision){
        Vector3 position=collision.gameObject.transform.position;   
        Vector3 pos=new Vector3(Mathf.RoundToInt(position.x),position.y,position.z);
        collision.gameObject.transform.position = pos;

    }


}
