using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour
{
    public AudioClip Intro;
    public AudioClip Music;
    public float AttackRange;
    public float JumpSpeed;
    public float WalkSpeed;
    public Sprite BulletSprite;
    public GameObject Muzzle;

    void OnEnable()
    {
        PlayerScript.Instance._Animator = gameObject.GetComponent<Animator>();
        PlayerScript.Instance.VerticalSpeed = JumpSpeed;
        PlayerScript.Instance.HorizontalSpeed = WalkSpeed;
        PlayerScript.Instance.CurrentBullet = BulletSprite;
        PlayerScript.Instance.Range = AttackRange;
        PlayerScript.Instance.Muzzle = Muzzle.transform.position;
        AudioScript.Instance.IntroClip = Intro;
        AudioScript.Instance.Music = Music;
        AudioScript.Instance.PlayIntro();
        AudioScript.Instance.PlayMusic();
    }

    void Update()
    {
        PlayerScript.Instance.Muzzle = Muzzle.transform.position;
    }
}
