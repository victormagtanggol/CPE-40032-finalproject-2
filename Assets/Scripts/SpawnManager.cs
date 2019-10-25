using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShotPowerUpPrefab;
    [SerializeField]
    private GameObject _tripleShotContainer;
    [SerializeField]
    private GameObject _speedPowerUpPrefab;
    [SerializeField]
    private GameObject _speedContainer;
    [SerializeField]
    private GameObject _shieldPowerUpPrefab;
    [SerializeField]
    private GameObject _shieldContainer;

    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnTripleShotPowerUpRoutine());
        StartCoroutine(SpawnSpeedPowerUpRoutine());
        StartCoroutine(SpawnShieldPowerUpRoutine());
    }


    void Update()
    {
       
    }
    IEnumerator SpawnTripleShotPowerUpRoutine () 
    {
        while (_stopSpawning == false) 
        {
        Vector3 posToSpawn = new Vector3(Random.Range(-3f, 3f), 10f, 0); 
        GameObject newEnemy = Instantiate(_tripleShotPowerUpPrefab, posToSpawn, Quaternion.identity);
        newEnemy.transform.parent = _tripleShotContainer.transform;
        yield return new WaitForSeconds(8.0f); }
    }


    IEnumerator SpawnRoutine()
    {
        while(_stopSpawning == false)
        {
             Vector3 posToSpawn = new Vector3(Random.Range(-3f,3f),3.74f,0);
             GameObject newEnemy = Instantiate(_enemyPrefab,posToSpawn,Quaternion.identity);
             newEnemy.transform.parent = _enemyContainer.transform;
             yield return new WaitForSeconds(4.0f);
        }
    }
    IEnumerator SpawnSpeedPowerUpRoutine() {
        while(_stopSpawning == false)
        {
             Vector3 posToSpawn = new Vector3(Random.Range(-3f,3f),20f,0);
             GameObject newEnemy = Instantiate(_speedPowerUpPrefab,posToSpawn,Quaternion.identity);
             newEnemy.transform.parent = _speedContainer.transform;
             yield return new WaitForSeconds(15.0f);
        }
    }
        IEnumerator SpawnShieldPowerUpRoutine() {
        while(_stopSpawning == false)
        {
             Vector3 posToSpawn = new Vector3(Random.Range(-3f,3f),28f,0);
             GameObject newEnemy = Instantiate(_shieldPowerUpPrefab,posToSpawn,Quaternion.identity);
            newEnemy.transform.parent = _shieldContainer.transform;
             yield return new WaitForSeconds(12.0f);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning=true;
    }
}
