using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Rigidbody rbGO;
    private bool sleeping;

    void Start()
    {
        rbGO = gameObject.AddComponent<Rigidbody>();
        sleeping = false;
    }

    void Update()
    {
        if (sleeping == false)
        {
            rbGO.WakeUp();
        }   
    }

    private void OnCollisionStay(Collision collision)
    {
        if (gameObject.name == ("Oeuf") || gameObject.name == ("Pain") || gameObject.name == ("Saucisse"))
        {
            if (collision.gameObject.name == ("Moteur"))
            {
                print("Ca cuit");
            }
        }
    }
}
