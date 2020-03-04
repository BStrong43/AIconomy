using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAccessory : MonoBehaviour
{

    public bool inDebug;
    public Material[] clothes;
    //public GameObject[] clothes;
    public GameObject[] facialAcc;
    public Transform headSpawn;

    void Start()
    {
        initCharacter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inDebug)
        {
            initCharacter();
        }
    }

    void initCharacter()
    {
        int bodyChoice = Random.Range(0, clothes.Length),
            faceChoice = Random.Range(0, facialAcc.Length);

        createClothes(bodyChoice);
        createAccesories(faceChoice);

    }

    void createClothes(int choice)
    {
        //Bound to change if clothes become implemented, for now its just a color
        GetComponent<MeshRenderer>().material = clothes[choice];
    }

    void createAccesories(int choice)
    {
       
        GameObject acc = Instantiate(facialAcc[choice], headSpawn);
        acc.GetComponent<MeshRenderer>().material = clothes[choice];
        Vector3 adjustedSpawn = acc.GetComponent<AccessoryScript>().spawnPoint;
        acc.transform.Translate(adjustedSpawn);
    }
}
