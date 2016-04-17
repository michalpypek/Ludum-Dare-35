using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

	void Update ()
    {
        text.text = "Score: " + GameManager.Instance.GetScore();
	}
}
