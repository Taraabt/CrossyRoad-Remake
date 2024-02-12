using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour{

    [SerializeField] GameObject[] ground;
    [SerializeField] GameObject[] obstacle;
    [SerializeField] GameObject[] objGenerator;
    float maxPos =10.5f;
    float startingLine=5.5f;
    List<int> List = new List<int>();

    public void CreateLine(float i){
        int random = Random.Range(0, ground.Length);
        Vector3 newLine = new Vector3(0f, 0f, ground[random].transform.position.z + i);
        GameObject Instance=Instantiate(ground[random], newLine, Quaternion.identity);
        if (random == 0){
            CreateGroundObstacle(Instance.transform.position);
       }else if (random == 2){
            CreateCar(Instance.transform.position);
       }
    }
    
    void CreateCar(Vector3 position){
        int random=Random.Range(0, 2);
        if (random == 0){
            Vector3 spawner1 = new Vector3(position.x - 5.5f, 0f, position.z);
            Instantiate(objGenerator[random], spawner1,Quaternion.identity);        
        }else{
            Vector3 spawner2 = new Vector3(position.x + 5.5f, 0f, position.z);
            Instantiate(objGenerator[random], spawner2, Quaternion.identity).transform.Rotate(0f,180f,0f);
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
            Vector3 pos = new Vector3(rNumber, 0f, position.z);
            List.Remove(rNumber);
            Instantiate(obstacle[Random.Range(0, obstacle.Length)], pos, Quaternion.identity);
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
