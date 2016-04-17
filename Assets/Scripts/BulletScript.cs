using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    public float TimeRange;
    int dir;

    void Update()
    {
        this.transform.Translate(dir * 15 * Time.deltaTime, 0, 0);
    }

    void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = PlayerScript.Instance.CurrentBullet;
        transform.position = PlayerScript.Instance.Muzzle;
        dir = (int)PlayerScript.Instance.transform.localScale.x;
        TimeRange = PlayerScript.Instance.Range;
        Invoke("Destroy", TimeRange);
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
