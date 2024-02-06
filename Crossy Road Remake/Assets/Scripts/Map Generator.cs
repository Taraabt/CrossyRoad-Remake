using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapGenerator : MonoBehaviour{

    [SerializeField] GameObject[] ground;
    [SerializeField] GameObject[] obstacle;
    float maxPos =10f;
    float startingLine=5f;
    int maxObstacle = 3;
    List<int> List = new List<int>();

    public void CreateLine(float i){
        int r = Random.Range(0, 4);
        Vector3 newLine = new Vector3(-0.5f, 0f, ground[r].transform.position.z + i);
        GameObject Instance=Instantiate(ground[r], newLine, Quaternion.identity);
        if (r == 0){
            CreateGroundObstacle(Instance.transform.position);
        }
    }

    public void CreateGroundObstacle(Vector3 position){
        for (int i = -5; i < 5; i++){
            List.Add(i);
        }
        for (int i = 0;i < maxObstacle; i++){
            int r = Random.Range(0, List.Count);
            Vector3 pos = new Vector3(List[r], 0f, position.z);
            List.Remove(r-5);
            for (int j =0; j < List.Count; j++){
                Debug.Log(List[j]);
            }
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
