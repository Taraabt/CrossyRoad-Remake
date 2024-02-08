using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Params : MonoBehaviour{

    public static Params Instance;

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    [Header ("Map")]
    [SerializeField] int obstacleNumber;
    public int ObstacleNumber { get { return obstacleNumber; } }

    [Header ("Camera")]
    [SerializeField] float cameraSpeed;
    public float CameraSpeed { get { return cameraSpeed; } }


}
