using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour{
    [SerializeField] GameObject[] map;

    int minRange = 0;
    int maxRange = 4;
    float maxPos=10f;
    int maxUnit=5;

    public void CreateNewLine(float i){
        int r = Random.Range(minRange, maxRange);
        Vector3 newLine = new Vector3(0f, 0f, map[r].transform.position.z + i);
        Instantiate(map[r], newLine, Quaternion.identity);
    }
    void Start(){
        for (int i=maxUnit ; i < maxPos; i++) {
            CreateNewLine(i);
        }
    }
    void Update(){
        GameObject player = GameObject.Find("Chicken");
        if(player.transform.position.z +maxUnit >= maxPos){
            CreateNewLine(maxPos);
            maxPos++;
        }
    }
}
