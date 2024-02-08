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

    [SerializeField] float followPlayerSpeed;
    public float FollowPlayerSpeed { get { return followPlayerSpeed; } }

    [SerializeField] float dstncB4Die;
    public float DstncB4Die { get { return dstncB4Die; } }

    [SerializeField] float dstncB4FllwPlayer;
    public float DstncB4FllwPlayer { get { return dstncB4FllwPlayer; } }


}
