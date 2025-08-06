using UnityEngine;
using UnityEngine.Rendering;

public class Coin : MonoBehaviour
{
    public float Speed = 5f;
    public GameObject CoinPrefab;
    public Transform vitri;
    void Start()
    {
        InvokeRepeating("spawnCoin", 0f, 10f);
    }
    void Update()
    {

        
    }
    void spawnCoin()
    {
        GameObject newObject = Instantiate(CoinPrefab, vitri.position, Quaternion.identity);
        Destroy(newObject, 15f);
        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.right * 10f;
        }

    }
}
