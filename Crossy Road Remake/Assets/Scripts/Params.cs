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

    [Header ("Camera")]
    [SerializeField] float cameraSpeed;
    public float CameraSpeed { get { return cameraSpeed; } }
    [SerializeField] float followPlayerSpeed;
    public float FollowPlayerSpeed { get { return followPlayerSpeed; } }
    [SerializeField] float dstncB4Die;
    public float DstncB4Die { get { return dstncB4Die; } }
    [SerializeField] float dstncB4FllwPlayer;
    public float DstncB4FllwPlayer { get { return dstncB4FllwPlayer; } }

    [Header("Car")]
    [SerializeField] float carSpeed;
    public float CarSpeed { get { return carSpeed; } }
    [SerializeField] float carTimer;
    public float CarTimer { get { return carTimer; } }

    [Header("Train")]
    [SerializeField] float trainSpeed;
    public float TrainSpeed { get { return trainSpeed; } }
    [SerializeField] float trainTimer;
    public float TrainTimer { get { return trainTimer; } }

    [Header("River")]
    [SerializeField] float logSpeed;
    public float LogSpeed { get { return logSpeed; } }
    [SerializeField] float logTimer;
    public float LogTimer { get { return logTimer; } }


}
