using UnityEngine;
using System.Collections;

public class GroundCheckScript : MonoBehaviour
{

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            PlayerScript.Instance.IsGrounded = false;
        }

    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            PlayerScript.Instance.IsGrounded = true;
        }

    }
}
