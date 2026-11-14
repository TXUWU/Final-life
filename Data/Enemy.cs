using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/Enemy Data")]
public class Enemy : ScriptableObject
{
    public float health;
    public float damage;
    public float detectionDistance;
    public float speed;
}
