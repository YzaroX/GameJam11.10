using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Rigidbody rbGO;
    private bool sleeping;
    private bool caCuit = false;
    private float time = 0f;

    void Start()
    {
        rbGO = gameObject.GetComponent<Rigidbody>();
        sleeping = false;
    }

    void Update()
    {
        print(Time.time);
        if (sleeping == false)
        {
            rbGO.WakeUp();
        }
        if (caCuit == false)
        {
            time = 0f;
        } 
    }

    private void OnCollisionStay(Collision collision)
    {
        if (gameObject.name == ("Oeuf") || gameObject.name == ("Pain") || gameObject.name == ("Saucisse"))
        {
            if (collision.gameObject.name == ("Moteur"))
            {
                caCuit = true;
                time = Time.time;
                print("Ca cuit");

                if (time <= 2f)
                {
                    caCuit = false;
                    print("C'est cuit !");
                }
            }
            else
            {
                caCuit = false;
                print("Ca cuit plu");
            }
        }
    }
}
