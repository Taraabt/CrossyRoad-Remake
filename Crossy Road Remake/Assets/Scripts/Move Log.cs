using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLog : MonoBehaviour{

    bool hasPlayer=false;
    bool onlog = false;
    GameObject player;
    BoxCollider collider;

    private void Awake(){
        player = GameObject.Find("Chicken");
        collider = this.GetComponent<BoxCollider>();
    }
    void Update(){
        transform.Translate(Vector3.right * Time.deltaTime * Params.Instance.LogSpeed, Space.Self);
        if (transform.position.x >= 10f || transform.position.x <= -10f){
            Destroy(gameObject);
        }else if (hasPlayer){
            player.transform.SetParent(transform);
        }
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject==player){
            hasPlayer = true;
                Vector3 pos = new Vector3(transform.position.x, 0f, player.transform.position.z);
                if (collider.size.x == 1){
                    player.transform.position = pos;
                }else if (collider.size.x == 2){
                    if (player.transform.position.x - pos.x < -0.25f){
                        pos.x -= 0.5f;
                        player.transform.position = pos;
                    }else{
                        pos.x += 0.5f;
                        player.transform.position = pos;
                    }
                }else if (collider.size.x == 3){
                    if (player.transform.position.x - pos.x < -0.5){
                        pos.x -= 1f;
                        player.transform.position = pos;
                    }else if (player.transform.position.x - pos.x > 0.5f){
                        pos.x += 1f;
                        player.transform.position = pos;
                    }else{
                        player.transform.position = pos;
                    }
                }          
            }
    }

    private void OnCollisionExit(Collision collision){
        hasPlayer = false;
        player.transform.SetParent(null);
        Debug.Log("exit");

    }
}
