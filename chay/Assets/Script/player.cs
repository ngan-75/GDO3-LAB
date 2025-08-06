using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float JumpSeep = 5f;
    public Rigidbody2D rb;
    public bool isGround = true;
    public Animator animator;
    public int Xu = 0;
    public int Tim = 3;
    public TMP_Text Diemxu;
    public TMP_Text Timtest;
    public GameObject canva;
    public GameObject canvaOver;
    public TMP_Text soXu;
    public AudioManger audiomanger;
    public BackGround background1;
    public BackGround background2;
    public vitriquai Speedquai;

    bool daTangToc = false;
    void Start()
    {
        capnhattim();
        rb = GetComponent<Rigidbody2D>();
        audiomanger = Object.FindFirstObjectByType<AudioManger>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.linearVelocity = Vector2.up * JumpSeep;
            isGround = false;
            if (animator != null)
            {
                animator.SetBool("Jump", true);
            }
            Debug.Log("da bam cach");
        }
        if (isGround)
        {
            animator.SetBool("run", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = true;
            if (animator != null)
            {
                animator.SetBool("Jump", false);
            }
        }
        else if (collision.gameObject.CompareTag("coin"))
        {
            Xu++;
            Diemxu.text = "" + Xu;
            if(Xu>=4&& !daTangToc)
            {
                background1.Speed += 5;
                background2.Speed += 5;
                Speedquai.Speed += 5;
                daTangToc = true;
                Debug.Log("tang toc do quai");
                Debug.Log("da tang toc do cuon");
            }
            soXu.text = "SỐ XU CỦA BẠN LÀ: " + Xu;
            audiomanger.coinAudio();
            Debug.Log("da cong xu");
            Debug.Log("da xoa dong xu");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("quai"))
        {
            audiomanger.satthuongAudio();
            Tim--;
            capnhattim();
            if (Tim == 0)
            {
                Time.timeScale = 0f;
                canva.SetActive(false);
                canvaOver.SetActive(true);
            }
            Debug.Log("da tru tim");
            Destroy(collision.gameObject);
        }

    }
    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    void capnhattim()
    {
        Timtest.text = "" + Tim;
        Debug.Log("da cap nhat diem");
    }
}
