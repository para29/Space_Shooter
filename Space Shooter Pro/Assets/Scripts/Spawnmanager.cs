using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using UnityEngine;

public class Spawnmanager : MonoBehaviour
{


    [SerializeField]
    private GameObject _enemyPrefab;

    

    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] powerups;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
      
    }


    IEnumerator SpawnEnemyRoutine()
    {


        while (_stopSpawning == false)
        {
            UnityEngine.Vector3 spawnPos = new UnityEngine.Vector3(Random.Range(-8f, 8f), 7.3f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPos, UnityEngine.Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5);
        }

    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopSpawning == false)
        {
            UnityEngine.Vector3 spawnPos = new UnityEngine.Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUp], spawnPos, UnityEngine.Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }


    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}



















/* //private IEnumerator coroutine;
 [SerializeField]
 private GameObject _enemy;
 [SerializeField]
 private GameObject _enemyContainer;
 [SerializeField]
 private GameObject _tripleShotPowerupPrefab;


 private bool _stopSpawning = false;
 // Start is called before the first frame update
 void Start()
 {
     //coroutine = SpawnRoutine(5.0f);
     StartCoroutine(SpawnEnemyRoutine());
     StartCoroutine(SpawnPowerupRoutine());
 }

 // Update is called once per frame
 void Update()
 {

 }

 IEnumerator SpawnEnemyRoutine()
 {


     while (_stopSpawning == false)
     {



             UnityEngine.Vector3 posToSpawn = new UnityEngine.Vector3(Random.Range(-8f, 8f), 7, 0);

             GameObject newEnemy = Instantiate(_enemy, posToSpawn, UnityEngine.Quaternion.identity);

             newEnemy.transform.parent = _enemyContainer.transform;
             yield return new WaitForSeconds(5.0f);


      }
     }
 IEnumerator SpawnPowerupRoutine()
 {
     while(_stopSpawning == false)
     {
         UnityEngine.Vector3 posTospawn = new UnityEngine.Vector3(Random.Range(-8f, 8f), 7, 0);
         Instantiate(_tripleShotPowerupPrefab, posTospawn, UnityEngine.Quaternion.identity);
         yield return new WaitForSeconds(Random.Range(3, 8));


     }

 }


 public void OnPlayerDeath()
 {
     _stopSpawning = true;
 }

 }*/


