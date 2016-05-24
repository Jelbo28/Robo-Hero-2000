using UnityEngine;
using System.Collections;

public class RobotRenderer : MonoBehaviour
{
    #region Variables

    [SerializeField]
    Sprite left;

    [SerializeField]
    Sprite right;

    [SerializeField]
    Sprite idle;

    float pause;

    #endregion

    void Update ()
    {
        pause = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().sprite = left;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().sprite = right;
        }
        else if (Input.GetAxis("Horizontal") == pause)
        {
            GetComponent<SpriteRenderer>().sprite = idle;
        }
        Debug.Log(Input.GetAxis("Horizontal"));
    }
}
