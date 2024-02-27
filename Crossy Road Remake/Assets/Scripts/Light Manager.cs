using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    private float timer;
    [SerializeField] Light light;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponentInParent<TrainGenerator>().remainingTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=Params.Instance.TimeBeforeTrain) {
            light.intensity = 1;
        }
        if (timer<=-0.5f){
            light.intensity = 0;
            timer=Params.Instance.TrainTimer;
        }


    }
}
