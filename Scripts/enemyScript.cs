using UnityEngine;
using System;
using System.Collections;

public class enemyScript : MonoBehaviour
{
    public float health = 100f;
    public float reload = 5f;
    public Transform player;
    public float detectionDistance = 5f;
    public float speed = 10f;
    
    private float CurrentReload = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Pounce()
    {
        Debug.Log("Pounce Start");
        Vector3 playerPlace = player.position;
        yield return new WaitForSeconds(0.5f);
        transform.position = playerPlace;
        Debug.Log("Pounce End");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Vector3 distance = player.position - transform.position;
        float distanceFinal = distance.sqrMagnitude;

        if (distanceFinal < detectionDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        CurrentReload -= Time.deltaTime;
        if (CurrentReload < 0 && distanceFinal < 60)
        {
            StartCoroutine(Pounce());
            CurrentReload = reload;
        }
    }
}
