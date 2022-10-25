using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMovement : MonoBehaviour
{
    private GameObject startPoint, stayPoint, endPoint;
    private Vector3 v3startPoint, v3stayPoint, v3endPoint;

    private bool checkPoint = false, secondCheckPoint = false, stayCheck = false;

    public float speed = 12f;

    // Start is called before the first frame update
    void Start()
    {
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
            if (Input.GetKeyDown(KeyCode.P))
            {
                checkPoint = true;
            }
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
}
