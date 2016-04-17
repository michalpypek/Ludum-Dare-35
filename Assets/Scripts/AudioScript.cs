using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour
{
    public AudioClip IntroClip;
    public AudioClip Music;
    public AudioClip AttackClip;
    public AudioClip PoofClip;
    public AudioClip DeathClip;
    public AudioSource MainAudio;
    public AudioSource PlayerAudio;
    public AudioSource EnemyAudio;


    [SerializeField]
    AudioClip OgreTime;
    [SerializeField]
    AudioClip OgreAttack;

    public static AudioScript Instance = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayPoof()
    {
        PlayerAudio.PlayOneShot(PoofClip);
    }

    public void PlayIntro()
    {
        PlayerAudio.PlayOneShot(IntroClip);
    }

    public void PlayDeath()
    {
        EnemyAudio.PlayOneShot(DeathClip);
    }

    public void PlayMusic()
    {
        MainAudio.Stop();
        MainAudio.clip = Music;
        MainAudio.Play();
    }

    public void PlayAttack()
    {
        PlayerAudio.PlayOneShot(AttackClip);
    }

    public void PlayOgreAttack()
    {
        EnemyAudio.PlayOneShot(OgreAttack);
    }

    public void PlayOgreTime()
    {
        EnemyAudio.PlayOneShot(OgreTime);
    }

}
