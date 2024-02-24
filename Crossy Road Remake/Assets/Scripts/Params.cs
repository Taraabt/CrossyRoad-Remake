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
    [SerializeField] float numberOfSection;
    public float NumberOfSection { get { return numberOfSection; } }


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
    [SerializeField] float mulettoSpeed;
    public float MulettoSpeed { get { return mulettoSpeed; } }
    [SerializeField] float aspiratoreSpeed;
    public float AspiratoreSpeed { get { return aspiratoreSpeed; } }
    [SerializeField] float minCarTimer;
    public float MinCarTimer { get { return minCarTimer; } }
    [SerializeField] float maxCarTimer;
    public float MaxCarTimer { get { return maxCarTimer; } }

    [Header("Train")]
    [SerializeField] float trainSpeed;
    public float TrainSpeed { get { return trainSpeed; } }
    [SerializeField] float trainTimer;
    public float TrainTimer { get { return trainTimer; } }
    [SerializeField] float timeBeforeTrain;
    public float TimeBeforeTrain { get { return timeBeforeTrain; } }

    [Header("River")]
    [SerializeField] float maxLogSpeed;
    public float MaxLogSpeed{ get { return maxLogSpeed; } }
    [SerializeField] float minLogSpeed;
    public float MinLogSpeed { get { return minLogSpeed; } }

    [SerializeField] float maxLogTimer;
    public float MaxLogTimer { get { return maxLogTimer; } }
    [SerializeField] float minLogTimer;
    public float MinLogTimer { get { return minLogTimer; } }
    [Header("Cat")]
    [SerializeField] float catSpeed;
    public float CatSpeed { get { return catSpeed; } }


}
