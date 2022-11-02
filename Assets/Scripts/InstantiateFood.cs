using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFood : MonoBehaviour
{
    public GameObject spawnEgg, spawnBreed, spawnSausage;

    public GameObject eggPrefab, breedPrefab, sausagePrefab;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Egg")
        {
            var cloneEgg = Instantiate(eggPrefab, spawnEgg.transform.position, Quaternion.identity);
            cloneEgg.name = "Egg";
        }

        if (collision.gameObject.name == "Sausage")
        {
            var cloneSausage = Instantiate(sausagePrefab, spawnSausage.transform.position, Quaternion.identity);
            cloneSausage.name = "Sausage";
        }

        if (collision.gameObject.name == "Breed")
        {
            var cloneBreed = Instantiate(breedPrefab, spawnBreed.transform.position, Quaternion.identity);
            cloneBreed.name = "Breed";
        }
    }
}
