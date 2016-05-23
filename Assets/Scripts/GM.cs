using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    #region Variables

    Vector3 Paddle;

    [SerializeField]
    GameObject paddle;

    [SerializeField]
    Text parts;

    [SerializeField]
    Image health;

    [SerializeField]
    Sprite healthFull;

    [SerializeField]
    Sprite healthTwo;

    [SerializeField]
    Sprite healthOne;

    [SerializeField]
    Sprite healthZed;

    [SerializeField]
    int healthNumber = 3;

    [SerializeField]
    Text score;

    [SerializeField]
    float scoreNumber = 0;

    int partNumber = 0;

    [SerializeField]
    int totalParts = 15;

    public static GM instance = null;
    #endregion
    void Awake()
    {
        Paddle = paddle.GetComponent<Transform>().localScale;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void PartGet()
    {
        partNumber++;
        parts.text = "Parts: " + partNumber + "/" + totalParts;
        CheckWin();
    }

    public void PointGet(float pointAddition)
    {
        scoreNumber = scoreNumber + pointAddition;
        score.text = "Score: " + scoreNumber;
    }

    public void HealthGet()
    {
        healthNumber++;
        if (healthNumber >= 3)
        {
            healthNumber = 3;
        }
        if (healthNumber <= 0)
        {
            healthNumber = 0;
        }
        HealthUpdate();
    }

    public void Damage(int damageValue)
    {
        healthNumber = healthNumber - damageValue;
        if (healthNumber >= 3)
        {
            healthNumber = 3;
        }
        if (healthNumber <= 0)
        {
            healthNumber = 0;
        }
        HealthUpdate();
    }

    public void Upgrade()
    {
        Debug.Log("Upgrade");
    }

    public void Downgrade()
    {
        Debug.Log("Downgrade");
    }


    void CheckWin()
    {
        if (partNumber >= totalParts)
        {
            partNumber = 15;
            parts.text = "Parts: " + partNumber + "/" + totalParts;
            Debug.Log("Win");
        }
    }

    void HealthUpdate()
    {
        switch (healthNumber)
        {
            case (0):
                health.GetComponent<Image>().sprite = healthZed;
                break;
            case (1):
                health.GetComponent<Image>().sprite = healthOne;
                break;
            case (2):
                health.GetComponent<Image>().sprite = healthTwo;
                break;
            case (3):
                health.GetComponent<Image>().sprite = healthFull;
                break;
        }       
    }

    IEnumerator Wait(float waitTime)
    {
        while (waitTime > 0)
        {
            waitTime -= 0.01f;
            Paddle = Vector3.Lerp(/*new Vector3(25f, 2f, 5f)*/Paddle, new Vector3(100f, 2f, 5f), Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(waitTime);
    }
}
