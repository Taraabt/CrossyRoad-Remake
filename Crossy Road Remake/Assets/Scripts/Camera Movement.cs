using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{

    private void Update(){
        transform.Translate(Vector3.forward * Time.deltaTime,Space.World);
    }


}
