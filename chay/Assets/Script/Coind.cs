using UnityEngine;

public class Coind : MonoBehaviour
{
    public float Speed = 5f;
    public Animator animator;
    
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
        if (animator != null)
        {
            animator.SetBool("coin", true);
        }
            
    }
}
