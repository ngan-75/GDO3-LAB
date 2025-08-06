using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public AudioSource BackGroundAudioSource;
    public AudioClip BackGroundClink;
    public AudioSource hieuung;
    public AudioClip Coin;
    public AudioClip satthuong;
    void Start()
    {
        BackGroundAudio();
    }

    void Update()
    {
        
    }
    void BackGroundAudio()
    {
        BackGroundAudioSource.clip = BackGroundClink;
        BackGroundAudioSource.Play();

    }
    public void coinAudio()
    {
        hieuung.PlayOneShot(Coin);
    }
    public void satthuongAudio ()
    {
        hieuung.PlayOneShot(satthuong);
    }
}
