using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClientMovement : MonoBehaviour
{
    string[] products;

    private GameObject startPoint, stayPoint, endPoint;
    private Vector3 v3startPoint, v3stayPoint, v3endPoint;

    private bool checkPoint = false, secondCheckPoint = false, stayCheck = false;

    private bool check = false, firstCheck = false, secondCheck = false;

    public float speed = 12f;

    public TMP_Text Commandes;

    private string choices, firstChoice, secondChoice;

    // Start is called before the first frame update
    void Start()
    {
        Commandes = GameManager.theCommands;
        products = new string[] { "Sausage", "Steak", "Egg" };

        firstChoice = products[Random.Range(0, products.Length)];
        secondChoice = products[Random.Range(0, products.Length)];

        choices = gameObject.name + " : " + firstChoice + " + " + secondChoice + "\n";


        Commandes.text += choices.ToString();

        startPoint = GameObject.Find("StartPoint");
        stayPoint = GameObject.Find("StayPoint");
        endPoint = GameObject.Find("EndPoint");

        v3startPoint = startPoint.transform.position;
        v3stayPoint = stayPoint.transform.position;
        v3endPoint = endPoint.transform.position;

        transform.position = v3startPoint;

        transform.Rotate(0, -120, 0);
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (checkPoint == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, v3stayPoint, step);
        }

        if (transform.position == stayPoint.transform.position)
        {
            if (stayCheck == false)
            {
                stayCheck = true;
                transform.Rotate(0, -60, 0);
            }
            //if (Input.GetKeyDown(KeyCode.P))
            //{
            //    checkPoint = true;
            //}
        }

        if (checkPoint == true)
        {
            if (secondCheckPoint == false)
            {
                secondCheckPoint = true;
                transform.Rotate(0, 120, 0);
            }
            transform.position = Vector3.MoveTowards(transform.position, v3endPoint, step);

            if (transform.position == endPoint.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == firstChoice && check == false && firstCheck == false && other.tag == "Cuit")//Premier bon produit donné
        {
            check = true;
            firstCheck = true;
            print("first check");
        }
        else if (other.name == secondChoice && firstCheck == true && other.tag == "Cuit") //Deuxieme bon produit donné
        {
            checkPoint = true;
            Destroy(other.gameObject);
            choices = gameObject.name + " received his order.\n";
            Commandes.text += choices.ToString();
        }


        else if (other.name == secondChoice && check == false && secondCheck == false && other.tag == "Cuit")//Premier bon produit donné
        {
            check = true;
            secondCheck = true;
            print("second check");
        }

        else if (other.name == firstChoice && secondCheck == true && other.tag == "Cuit")//Deuxieme bon produit donné
        {
            checkPoint = true;
            Destroy(other.gameObject);
            choices = gameObject.name + " received his order.\n";
            Commandes.text += choices.ToString();
        }
    }
}
