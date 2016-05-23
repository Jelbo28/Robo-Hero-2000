using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    #region Variables
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
        //paddle.GetComponent<Paddle>().Resize(2f);
        paddle.GetComponent<Paddle>().Grow();
        scoreNumber = scoreNumber + 10;
        score.text = "Score: " + scoreNumber;
        Debug.Log("Upgrade");
    }

    public void Downgrade()
    {
        paddle.GetComponent<Paddle>().Shrink();
        scoreNumber = scoreNumber - 10;
        score.text = "Score: " + scoreNumber;
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
}
