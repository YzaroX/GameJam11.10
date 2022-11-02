using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject clientPrefab;

    public GameObject spawnPoint;

    public TMP_Text commands;
    public static TMP_Text theCommands;

    float timer, tick;
    public float timerInterval = 5f;

    public static int compteur = 0;

    private void Awake()
    {
        theCommands = commands;
    }

    private void Start()
    {
        timer = (int)Time.time;
        tick = timerInterval;
        compteur++;
        var cloneClient = Instantiate(clientPrefab, spawnPoint.transform.position, Quaternion.identity);
        cloneClient.name = "Client n°" + compteur;
    }

    // Update is called once per frame
    void Update()
    {
        timer = (int)Time.time;

        if (timer == tick)
        {
            tick = timer + timerInterval;

            compteur++;
            var cloneClient = Instantiate(clientPrefab, spawnPoint.transform.position, Quaternion.identity);
            cloneClient.name = "Client n°" + compteur;
            print("check");

        }
    }
}
