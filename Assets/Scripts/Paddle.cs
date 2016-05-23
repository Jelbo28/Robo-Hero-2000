using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    #region Variables
    Vector3 paddleLength;

    bool shrink = false;
    bool grow = false;

    [SerializeField]
    float paddleSpeed;
    [SerializeField]
    float clampLength;
    private Vector3 playerPosition = new Vector3(0, -3f, 0);
    #endregion

    void Awake()
    {
        //clampLength = Camera.main.ViewportToWorldPoint(transform.position);
        paddleLength = transform.localScale;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float xPosition = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPosition = new Vector3(Mathf.Clamp(xPosition, -clampLength, clampLength), -3f, 0f);
        transform.position = playerPosition;
    }

    public void Grow()
    {
        if (shrink == true || grow == false)
        {
            clampLength = 8f;
            if (grow == false)
            {
                clampLength = 7f;
            }
            iTween.ScaleTo(gameObject, iTween.Hash("scale", gameObject.transform.localScale + new Vector3(0.25f, 0f, 0f), "easetype", iTween.EaseType.easeInOutBack, "time", 1f));
            grow = true;
            shrink = false;
            Debug.Log("finished");
        }
    }

    public void Shrink()
    {
        if (shrink == false || grow == true)
        {
            clampLength = 8f;
            if (grow == false)
            {
                clampLength = 9f;
            }
            iTween.ScaleTo(gameObject, iTween.Hash("scale", gameObject.transform.localScale - new Vector3(0.25f, 0f, 0f), "easetype", iTween.EaseType.easeInOutBack, "time", 1f));
            shrink = true;
            grow = false;
            Debug.Log("finished");
        }
    }
}