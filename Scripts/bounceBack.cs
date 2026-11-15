using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class bounceBack : MonoBehaviour
{
    public List<string> movesToSteal;
    public UIManager uiManager;

    async public Task<string> Activate()
    {
        string move = await uiManager.ChosenThing();
        return move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Enemy"))
        {
            if(other.TryGetComponent<enemyScript>(out enemyScript data))
            {
                movesToSteal.Clear();
                movesToSteal.Add(data.move1);
                movesToSteal.Add(data.move2);
            }
        }
    }
}
