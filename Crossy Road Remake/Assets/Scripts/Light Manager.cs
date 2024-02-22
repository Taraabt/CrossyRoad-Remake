using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    private float timer;
    [SerializeField]Material[] material;
    // Start is called before the first frame update
    void Start()
    {
        timer = Params.Instance.TrainTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if(timer<=Params.Instance.TimeBeforeTrain) {
            this.GetComponentInChildren<Renderer>().material = material[1];
        }


    }
}
