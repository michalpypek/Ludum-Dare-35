using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    Animator animator;
    Vector3 FlipLeft = new Vector3(-1, 1, 1);
    Vector3 FlipRight = new Vector3(1, 1, 1);
    bool isAlive;

    void OnEnable()
    {
        isAlive = true;
        AudioScript.Instance.PlayOgreTime();
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Bullet"))
        {
            col.gameObject.SetActive(false);
            Death();
        }
    }

	void FixedUpdate ()
    {
        if (PlayerScript.Instance != null && isAlive)
        {
            float dist = Vector3.Distance(this.transform.position, PlayerScript.Instance.gameObject.transform.position);

            if (dist < 300)
            {
                animator.SetBool("IsMoving", true);
                this.transform.position = Vector3.MoveTowards(transform.position, PlayerScript.Instance.gameObject.transform.position, 8 * Time.deltaTime);
            }
            if(dist<2)
            {
                animator.SetTrigger("Attack");
                PlayerScript.Instance.Death();
                AudioScript.Instance.PlayOgreAttack();
            }

            if (PlayerScript.Instance.gameObject.transform.position.x < transform.position.x)
            {
                transform.localScale = FlipLeft;
            }

            if (PlayerScript.Instance.gameObject.transform.position.x > transform.position.x)
            {
                transform.localScale = FlipRight;
            }
        }

        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    public void Death()
    {
        isAlive = false;
        animator.SetTrigger("Death");
        Invoke("DisableObj", 0.5f);
        AudioScript.Instance.PlayDeath();
        GameManager.Instance.AddScore();
    }

    public void DisableObj()
    {
        gameObject.SetActive(false);
    }
}
