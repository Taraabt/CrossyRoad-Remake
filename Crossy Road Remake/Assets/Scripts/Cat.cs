using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        transform.Translate(Vector3.back *Time.deltaTime * Params.Instance.CatSpeed,Space.World);
    }

    // Update is called once per frame
    void Update(){
        if(transform.position.z>=-10){
            transform.Translate(Vector3.back * Time.deltaTime * Params.Instance.CatSpeed, Space.World);
            if (transform.position.z <= player.transform.position.z)
            {
                player.transform.SetParent(transform);
            }
        }
    }
}
