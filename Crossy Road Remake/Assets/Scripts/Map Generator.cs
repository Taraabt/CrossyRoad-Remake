using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapGenerator : MonoBehaviour{

    [SerializeField] GameObject[] ground;
    [SerializeField] GameObject[] obstacle;
    float maxPos =10f;
    float startingLine=5f;
    List<int> List = new List<int>();

    public void CreateLine(float i){
        int random = Random.Range(0, 4);
        Vector3 newLine = new Vector3(-0.5f, 0f, ground[random].transform.position.z + i);
        GameObject Instance=Instantiate(ground[random], newLine, Quaternion.identity);
        if (random == 0){
            CreateGroundObstacle(Instance.transform.position);
       }else if (random == 1){
            //CreateLog()
       }
    }

    public void CreateGroundObstacle(Vector3 position){
        for (int i = -4; i < 5; i++){
            List.Add(i);
        }
        List.Remove(0);
        for (int i = 0;i < Params.Instance.ObstacleNumber; i++){
            int rIndex = Random.Range(0, List.Count);
            int rNumber = List[rIndex];
            Debug.Log(rNumber);
            Vector3 pos = new Vector3(rNumber - 0.5f, 0f, position.z);
            List.Remove(rNumber);
            Instantiate(obstacle[Random.Range(0, 5)], pos, Quaternion.identity);
        }
        List.Clear();
    }

    void Start(){
        for (float i=startingLine ; i < maxPos; i++) {
            CreateLine(i);
        }
    }

    void Update(){
        GameObject player = GameObject.Find("Chicken");
        if(player.transform.position.z +startingLine >= maxPos){
            CreateLine(maxPos);
            maxPos++;
        }
    }

}
