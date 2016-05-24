using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    #region Variables
    [SerializeField]
    AudioSource damage;

    [SerializeField]
    AudioSource win;

    [SerializeField]
    AudioSource dead;

    [SerializeField]
    AudioSource retry;

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
            partNumber = totalParts;
            parts.text = "Parts: " + partNumber + "/" + totalParts;
            win.Play();
            Debug.Log("Win");
        }
    }

    void HealthUpdate()
    {
        switch (healthNumber)
        {
            case (0):
                damage.Play();
                damage.pitch = 1.2f;
                GameOver();
                break;
            case (1):
                health.GetComponent<Image>().sprite = healthOne;
                damage.pitch =  0.9f;
                damage.Play();
                break;
            case (2):
                health.GetComponent<Image>().sprite = healthTwo;
                damage.pitch = 1.1f;
                damage.Play();
                break;
            case (3):
                health.GetComponent<Image>().sprite = healthFull;
                damage.pitch = 1f;
                damage.Play();
                break;
        }       
    }

    void GameOver()
    {
        health.GetComponent<Image>().sprite = healthZed;
        dead.Play();
    }
}
