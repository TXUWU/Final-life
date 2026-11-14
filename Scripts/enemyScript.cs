using UnityEngine;
using System;

public class enemyScript : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] private float reload = 5f;
    public Transform player;
    public float detectionDistance = 5f;
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Vector3 distance = player.position - transform.position;
        float distanceFinal = distance.sqrMagnitude;

        if (distanceFinal < detectionDistance)
        {
            Vector3 moveDirection = distance/Mathf.Sqrt(distanceFinal > 0.01f ? distanceFinal : 1);
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
}
