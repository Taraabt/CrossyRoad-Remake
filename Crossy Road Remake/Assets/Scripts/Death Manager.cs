using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour{
    public delegate void Death();
    public static event Death PlayerDeath;

    private void Update(){
        if (PlayerDeath != null){
            PlayerDeath();
        }
    }

}
