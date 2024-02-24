using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar2 : MonoBehaviour
{
    public delegate void Death();
    public static event Death MulettoDeath;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Params.Instance.MulettoSpeed, Space.Self);
        if (transform.position.x >= 10f || transform.position.x <= -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        MulettoDeath();
    }

    void OnEnable()
    {
        MulettoDeath += KillPlayer;
    }

    void OnDisable()
    {
        MulettoDeath -= KillPlayer;
    }

    void KillPlayer()
    {
        //deathanimation
        Debug.Log("Player death");
    }
}
