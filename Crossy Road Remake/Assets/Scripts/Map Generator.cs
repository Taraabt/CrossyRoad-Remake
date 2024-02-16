using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MapGenerator : MonoBehaviour{

    [SerializeField] GameObject[] ground;
    [SerializeField] GameObject[] obstacle;
    [SerializeField] GameObject[] objGenerator;
    [SerializeField] GameObject lilipad;
    float maxPos =10.5f;
    float startingLine=5.5f;
    List<int> List = new List<int>();

    private string filePath;
    private int mapIndex;
    int[] map =new int[400];


    public void ReadFile(){
        string fileContent="";
        filePath = Path.Combine(Application.dataPath, "map.txt");
        if (File.Exists(filePath)){
            fileContent = File.ReadAllText(filePath);
        }else{
            Debug.LogError("Il file non esiste: " + filePath);
        }
        string[] map=fileContent.Split('\r');
        for (int i = 0; i < this.map.Length; i++){
            this.map[i] = int.Parse(map[i]);
            Debug.Log(map.Length);
        }
    }

    public void CreateLine(float i){
        if (mapIndex == map.Length){
            mapIndex = 0;
        }
        Vector3 newLine = new Vector3(0f, ground[map[mapIndex]].transform.position.y , ground[map[mapIndex]].transform.position.z + i);
        GameObject Instance=Instantiate(ground[map[mapIndex]], newLine, Quaternion.identity);
        if (map[mapIndex] == 0){
            CreateGroundObstacle(Instance.transform.position);
       }else if (map[mapIndex] == 2){
            CreateCar(Instance.transform.position);
       }else if(map[mapIndex] == 1){
            CreateLog(Instance.transform.position);
       }else if (map[mapIndex] == 3){
            CreateTrain(Instance.transform.position);
       }else{
            CreateLilipad(Instance.transform.position);
       }
        mapIndex++;
    }

    void CreateLilipad(Vector3 position){
        int nObstacle = Random.Range(0, 2);
        for (int i = -4; i < 5; i++){
            List.Add(i);
        }
        List.Remove(0);
        for (int i = 0; i < nObstacle; i++){
            int rIndex = Random.Range(0, List.Count);
            int rNumber = List[rIndex];
            Vector3 pos = new Vector3(rNumber, -0.1f, position.z);
            List.Remove(rNumber);
            Instantiate(lilipad, pos, Quaternion.identity);
        }
        List.Clear();
    }

    void CreateTrain(Vector3 pos){
        int random = Random.Range(4, 6);
        if (random == 4){
            Vector3 spawner1 = new Vector3(pos.x - 5.5f, 0f, pos.z);
            Instantiate(objGenerator[random], spawner1, Quaternion.identity);
        }else{
            Vector3 spawner2 = new Vector3(pos.x + 5.5f, 0f, pos.z);
            Instantiate(objGenerator[random], spawner2, Quaternion.identity).transform.Rotate(0f, 180f, 0f);
        }
    }

    void CreateLog(Vector3 pos){
        int random = Random.Range(2, 4);
        if (random == 2){
            Vector3 spawner1 = new Vector3(pos.x - 5.5f, 0f, pos.z);
            Instantiate(objGenerator[random], spawner1, Quaternion.identity);
        }else{
            Vector3 spawner2 = new Vector3(pos.x + 5.5f, 0f, pos.z);
            Instantiate(objGenerator[random], spawner2, Quaternion.identity).transform.Rotate(0f, 180f, 0f);
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
        int nObstacle=Random.Range(0,4);
        for (int i = -4; i < 5; i++){
            List.Add(i);
        }
        List.Remove(0);
        for (int i = 0;i < nObstacle; i++){
            int rIndex = Random.Range(0, List.Count);
            int rNumber = List[rIndex];
            Vector3 pos = new Vector3(rNumber, 0f, position.z);
            List.Remove(rNumber);
            Instantiate(obstacle[Random.Range(0, obstacle.Length)], pos, Quaternion.identity);
        }
        List.Clear();
    }

    void Start(){
        ReadFile();
        mapIndex = Random.Range(0, map.Length);
        Debug.Log(mapIndex);
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
