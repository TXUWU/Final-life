using UnityEngine;
using System.Collections;

public class moveSet : MonoBehaviour
{
    public void Pounce(Vector3 position)
    {
        IEnumerator executePounce()
        {
            Vector3 playerPlace = position;
            yield return new WaitForSeconds(0.5f);
            transform.position = playerPlace;
        }
        StartCoroutine(executePounce());
    }
    
    public void Heal(float amount) 
    {
        if (gameObject.CompareTag("Enemy"))
        {
            if(gameObject.TryGetComponent<enemyScript>(out enemyScript script))
            {
                float amountCheck = script.currentHealth;
                amountCheck += amount;
                if (amountCheck > script.enemyData.health) {
                    script.currentHealth = script.enemyData.health;
                }
                else {
                    script.currentHealth = amountCheck;
                }
            }
        }        
        else if (gameObject.CompareTag("Player"))
        {
            if(gameObject.TryGetComponent<playerScript>(out playerScript script))
            {
                float amountCheck = script.currentHealth;
                amountCheck += amount;
                if (amountCheck > script.health) {
                    script.currentHealth = script.health;
                }
                else {
                    script.currentHealth = amountCheck;
                }
            }
        }
    }

    public void Move(string move, Vector3 place = default, float amount = default) 
    {
        if (move == "pounce")
        {
            Pounce(place);
        }
        else if (move == "heal")
        {
            Heal(amount);
        }
    }
}
