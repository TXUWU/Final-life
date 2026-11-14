using UnityEngine;
using System;
using System.Collections;

public class enemyScript : MonoBehaviour
{
    public Transform player;
    public Enemy enemyData;
    
    private float CurrentReload1 = 0f;
    private float CurrentReload2 = 0f;
    public float currentHealth;
    public MoveSet moveSet;
    public string move1;
    public float reload1 = 5f;
    public string move2;
    public float reload2 = 12f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = enemyData.health;
        moveSet = GetComponent<MoveSet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Vector3 distance = player.position - transform.position;
        float distanceFinal = distance.sqrMagnitude;

        if (distanceFinal < enemyData.detectionDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, enemyData.speed * Time.deltaTime);
        }
        CurrentReload1 -= Time.deltaTime;
        if (CurrentReload1 < 0 && distanceFinal < 60)
        {
            moveSet.Move("pounce", player.position);
            CurrentReload1 = reload1;
        }
    }
}
