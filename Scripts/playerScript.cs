using UnityEngine;
using System;

public class playerScript : MonoBehaviour
{
    public bool moveable = true;
    public float speed = 8f;
    public float health = 100f;
    [SerializeField] private int invincibilityFrames = 0;
    [SerializeField] private int incapacitationTime = 0;

    public float currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Something touched!");
        GameObject other = collision.gameObject;
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy touched!");
            if(other.TryGetComponent<enemyType>(out enemyType data))
            {
                currentHealth -= data.damage;
                Debug.Log("Damage taken!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Player dead!");
            Destroy(gameObject);
        }
        if (moveable)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            Vector3 moveDirection = new Vector3(moveX, moveY, 0f);
            if (moveX != 0 && moveY != 0)
            {
                moveDirection = moveDirection / Mathf.Sqrt(2);
            }
            transform.position += moveDirection * speed * Time.deltaTime;
        }
        else
        {
            incapacitationTime -= 1;
            if (incapacitationTime == 0)
            {
                moveable = true;
            }
        }
    }
}
