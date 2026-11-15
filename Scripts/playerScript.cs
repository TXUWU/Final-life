using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class playerScript : MonoBehaviour
{
    public List<string> moves;
    public bool moveable = true;
    public float speed = 8f;
    public float health = 100f;
    [SerializeField] private int incapacitationTime = 0;

    public float currentHealth;
    private bounceBack bounceBack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bounceBack = GetComponent<bounceBack>();
        currentHealth = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Enemy"))
        {
            if(other.TryGetComponent<enemyScript>(out enemyScript data))
            {
                currentHealth -= data.enemyData.damage;
            }
        }
    }

    // Update is called once per frame
    async void Update()
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
        if (Input.GetKeyDown(KeyCode.F))  //BOUNCE BACK
        {
            if (currentHealth/health < 1.1f) //TESTING PURPOSES ONLY
            {
                moves.Add(await bounceBack.Activate());
                currentHealth += health * 0.4f;
            }
        }
    }
}
