using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Rigidbody rbGO;
    private bool sleeping;
    private bool caCuit = false;
    float timer = 0f;
    

    void Start()
    {
        rbGO = gameObject.GetComponent<Rigidbody>();
        sleeping = false;
    }

    void Update()
    {
        if (sleeping == false)
        {
            rbGO.WakeUp();
        }
        if (caCuit == false)
        {
            timer = 0f;
        }
        //print(timer);

        if (timer >= 10.0f)
        {
            caCuit = false;
            print("C'est cuit ! ");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (gameObject.name == ("Oeuf") || gameObject.name == ("Pain") || gameObject.name == ("Saucisse"))
        {
            if (collision.gameObject.name == ("Moteur"))
            {
                caCuit = true;
                timer += Time.deltaTime;
            }
            else
            {
                caCuit = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("Sol"))
        {
            Destroy(gameObject);
        }
    }
}
