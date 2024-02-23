using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyObject : MonoBehaviour{

    void Update(){
        GameObject player = GameObject.Find("Player");
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z-20);
        Vector3 boxDimension = new Vector3(11f,3f,1);
        Collider[] toDestroy = Physics.OverlapBox(playerPos, boxDimension);
        for (int i = 0; i < toDestroy.Length; i++){
            //Destroy(toDestroy[i]);
            Destroy(toDestroy[i].gameObject);
        }

    }
}
