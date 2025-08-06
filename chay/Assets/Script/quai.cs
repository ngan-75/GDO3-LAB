using UnityEngine;

public class quai : MonoBehaviour
{
    public float Speed = 5f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}
