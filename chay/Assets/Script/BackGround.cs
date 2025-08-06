using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float Speed = 20f;
    public float reset = -20;
    public float start = 20;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
        if (transform.position.x<= reset)
        {
            Vector3 newV = new Vector3(start , transform.position.y , transform.position.z);
            transform.position = newV;
        }
    }
}
