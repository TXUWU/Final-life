using UnityEngine;

public class playerAbilities : MonoBehaviour
{
    public moveSet moves;

    void Start()
    {
        moves = GetComponent<moveSet>();
    }

    void Attack(string type)
    {
        if (type == "pounce")
        {
            moves.Move(type, Input.mousePosition);
        }
        else if (type == "heal")
        {
            moves.Move(type, default, 30);
        }
    }
}
