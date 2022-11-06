using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Rigidbody rbGO;
    [SerializeField] private MeshFilter meshEgg;
    [SerializeField] private Mesh newMeshEgg;
    [SerializeField] private Renderer materialEgg, materialSausage, materialSteak;

    public Material cookedEgg, cookedSteak, cookedSausage;


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

        if (timer >= 5.0f)
        {
            caCuit = false;
            print("C'est cuit ! ");
            gameObject.tag = "Cuit";

            if (gameObject.name == "Egg")
            {
                meshEgg.mesh = newMeshEgg;
                materialEgg.material = cookedEgg;
            }

            if (gameObject.name == "Steak")
            {
                //Change Mesh to Steak for it to be cooked Egg
                materialSteak.material = cookedSteak;
            }

            if (gameObject.name == "Sausage")
            {
                //Change Mesh to Sausage for it to be cooked Egg
                materialSausage.material = cookedSausage;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (gameObject.name == "Egg" || gameObject.name == "Steak" || gameObject.name == "Sausage")
        {
            if (collision.gameObject.name == "Moteur")
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
        if (collision.gameObject.name == "Sol")
        {
            Destroy(gameObject);
        }

        if (gameObject.name == "Sausage" && gameObject.tag == "Cuit" && collision.gameObject.name == "TheBreed")
        {
            //Change Mesh of Sausage for it to be Hotdog, and destroy TheBreed
        }
    }
}
