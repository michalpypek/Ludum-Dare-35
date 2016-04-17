using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour
{
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public bool IsGrounded;
    public Animator _Animator;
    public GameObject[] Characters = new GameObject[6];
    public GameObject poof;
    public GameObject BulletPrefab;
    public Sprite CurrentBullet;
    public float Range;
    public Vector2 Muzzle;

    int CurrentCharacter;

    Vector3 FlipLeft = new Vector3 (-1, 1 ,1);
    Vector3 FlipRight = new Vector3(1, 1, 1);

    List<GameObject> BulletList = new List<GameObject>();

    public static PlayerScript Instance = null;

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

        CreateBulletPool();
        ChangeToBasicCharacter();
    }

    void FixedUpdate ()
    {
        if(Input.GetKeyDown("space"))
        {
            _Animator.SetTrigger("Attack");
            GameObject Bullet = GetBullet();
            AudioScript.Instance.PlayAttack();
            Bullet.SetActive(true);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            gameObject.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * HorizontalSpeed, 0, 0));
            if (IsGrounded)
            {
               _Animator.SetBool("IsMoving", true);
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.localScale = FlipLeft;
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.localScale = FlipRight;
            }
        }

        else
        {
            _Animator.SetBool("IsMoving", false);
        }

        if (Input.GetAxis("Vertical") > 0 && IsGrounded)
        {
            _Animator.SetTrigger("Jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, VerticalSpeed), ForceMode2D.Impulse);
        }
    }

    IEnumerator  ChangeBack()
    {
        yield return new WaitForSeconds(10);
        ChangeToBasicCharacter();
    }

    IEnumerator Poof()
    {
        AudioScript.Instance.PlayPoof();
        poof.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        poof.SetActive(false);
    }

    void ChangeToBasicCharacter()
    {
        StartCoroutine(Poof());
        Characters[CurrentCharacter].SetActive(false);
        CurrentCharacter = 0;
        Characters[0].SetActive(true);       
    }

    void ChangeCharacter()
    {
        StopAllCoroutines();
        int rand = Random.Range(1, 6);
        StartCoroutine(Poof());
        Characters[CurrentCharacter].SetActive(false);
        CurrentCharacter = rand;
        Characters[rand].SetActive(true);
        StartCoroutine(ChangeBack());
        //play intro sound
        //play char music        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag.Equals("PowerUp"))
        {
            ChangeCharacter();
            col.gameObject.SetActive(false);
        }

        if(col.gameObject.tag.Equals("Enemy"))
        {
            Death();
        }
    }

    public void Death()
    {
        StartCoroutine(Poof());
        Characters[CurrentCharacter].SetActive(false);
        Debug.Log("Die");
        AudioScript.Instance.PlayDeath();
        GameManager.Instance.MenuScene();
    }

    public void CreateBulletPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = (GameObject)Instantiate(BulletPrefab, Vector2.zero, Quaternion.identity);
            obj.SetActive(false);
            BulletList.Add(obj);
        }
        InvokeRepeating("SpawnEnemy", 0, 1f);
    }

    public GameObject GetBullet()
    {
        foreach (GameObject obj in BulletList)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }
}
