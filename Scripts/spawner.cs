using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour
{
    public Transform player;
    public GameObject[] enemy; 
    public int spawnRange = 200;
    public int maxRange = 1000;
    public int maxEnemies = 30; 
    public float timeDelay = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject enemyToClone = enemy[0]; //FOR NOW, THERE IS ONLY ONE, SHOULD CHOOSE RANDOMLY
            Vector3 spawnPlace = new Vector3(player.position.x + Random.Range(-spawnRange, spawnRange), player.position.y + Random.Range(-spawnRange, spawnRange), 1);
            GameObject enemyInstance = Instantiate(enemyToClone, spawnPlace, Quaternion.identity);
            enemyScript target = enemyInstance.GetComponent<enemyScript>();
            target.player = player;
            
            yield return new WaitForSeconds(timeDelay);
        }
    }
    
    void Start()
    {
        StartCoroutine(Spawn());
    }
}