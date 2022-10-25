using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject clientPrefab;

    public GameObject spawnPoint;

    float timer, tick;
    public float timerInterval = 5f;

    private void Start()
    {
        timer = (int)Time.time;
        tick = timerInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer = (int)Time.time;

        if (timer == tick)
        {
            tick = timer + timerInterval;
            var cloneClient = Instantiate(clientPrefab, spawnPoint.transform.position, Quaternion.identity);
            cloneClient.name = "Client";
            print("check");

        }

        //timer += Time.time;

        //if (timer > 10.0f)
        //{
        //    check = true;
        //}

        //if (check == true)
        //{
        //    check = false;
        //    var cloneClient = Instantiate(clientPrefab, spawnPoint.transform.position, Quaternion.identity);
        //    cloneClient.name = "Client";
        //    timer = 0.0f;
        //}
    }
}
