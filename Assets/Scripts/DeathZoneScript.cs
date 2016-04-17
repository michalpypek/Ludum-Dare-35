using UnityEngine;
using System.Collections;

public class DeathZoneScript : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            PlayerScript.Instance.Death();
        }        
    }

}
