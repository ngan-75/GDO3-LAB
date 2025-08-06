using UnityEngine;

public class vitriquai : MonoBehaviour
{
    public GameObject quaiPrefab;
    public Transform vitri;
    public float Speed = 10f;

    void Start()
    {
        InvokeRepeating("spawnquai", 0f, 3f);
    }

    void Update()
    {
        
    }
    void spawnquai()
    {
        GameObject newObject = Instantiate(quaiPrefab, vitri.position, Quaternion.identity);
        Destroy(newObject, 8f);
        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.left * Speed;
        }
    }
}
