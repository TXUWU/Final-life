using UnityEngine;
using System;

public class controls : MonoBehaviour
{
    public bool moveable = true;
    public float speed = 8f;
    public float health = 100f;
    [SerializeField] private int invincibilityFrames = 0;
    [SerializeField] private int incapacitationTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
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
