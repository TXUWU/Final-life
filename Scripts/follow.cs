using UnityEngine;

public class follow : MonoBehaviour
{
    public new Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -3);
    }
}
