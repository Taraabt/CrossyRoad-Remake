using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLog : MonoBehaviour{

    bool hasPlayer=false;
    GameObject player;

    private void Awake(){
        player = GameObject.Find("Chicken");
    }
    void Update(){
        transform.Translate(Vector3.right * Time.deltaTime * Params.Instance.LogSpeed, Space.Self);
        if (transform.position.x >= 10f || transform.position.x <= -10f){
            Destroy(gameObject);
        }else if(hasPlayer){
            //Vector3 pos=new Vector3(Mathf.RoundToInt(player.transform.position.x) +0.5f, 0f,player.transform.position.z);
            //player.transform.position=pos;
            player.transform.Translate(this.transform.right * Time.deltaTime * Params.Instance.LogSpeed, Space.Self);
        }
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject==player){
            Debug.Log("onthelog");
            hasPlayer = true;        
            Debug.Log(transform.position.x - player.transform.position.x);
            Vector3 pos = new Vector3(transform.position.x, 0f, player.transform.position.z);
            player.transform.position = pos;
        }
    }
    private void OnCollisionExit(Collision collision){
        hasPlayer = false;

    }
}
