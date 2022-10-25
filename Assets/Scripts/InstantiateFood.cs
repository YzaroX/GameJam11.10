using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFood : MonoBehaviour
{
    public GameObject spawnEgg, spawnBreed, spawnSausage;

    public GameObject eggPrefab, breedPrefab, sausagePrefab;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Oeuf")
        {
            var cloneEgg = Instantiate(eggPrefab, spawnEgg.transform.position, Quaternion.identity);
            cloneEgg.name = "Oeuf";
        }

        if (collision.gameObject.name == "Saucisse")
        {
            var cloneSausage = Instantiate(sausagePrefab, spawnSausage.transform.position, Quaternion.identity);
            cloneSausage.name = "Saucisse";
        }

        if (collision.gameObject.name == "Pain")
        {
            var cloneBreed = Instantiate(breedPrefab, spawnBreed.transform.position, Quaternion.identity);
            cloneBreed.name = "Pain";
        }
    }
}
