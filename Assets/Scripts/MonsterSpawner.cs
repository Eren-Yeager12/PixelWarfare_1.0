using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsters;
    public GameObject[] spawners;
    private int randommonster;
    private int randomspawner;
   
    private GameObject spawnedmonster;
    public float speed;
    public float distancediffer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());
    }

    // Update is called once per frame
    IEnumerator Spawning(){

        while(true) {
        yield return new WaitForSeconds(Random.Range(1,2));

        randommonster = Random.Range(0,monsters.Length);
        randomspawner = Random.Range(0,spawners.Length);

     spawnedmonster =    Instantiate(monsters[randommonster], spawners[randomspawner].transform);
        Debug.Log("monster spawned");
        }
    }

    
}
