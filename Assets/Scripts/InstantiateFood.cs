using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFood : MonoBehaviour
{
    public GameObject spawnEgg, spawnBreed, spawnSausage, spawnSteak;

    public GameObject eggPrefab, breedPrefab, sausagePrefab, steakPrefab;

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
            cloneBreed.name = "TheBreed";
        }

        if (collision.gameObject.name == "Steak")
        {
            var cloneSteak = Instantiate(steakPrefab, spawnSteak.transform.position, Quaternion.identity);
            cloneSteak.name = "Steak";
        }
    }
}
