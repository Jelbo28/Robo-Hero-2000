using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    #region Variables

    [SerializeField]
    GameObject shieldObject;

    [SerializeField]
    Animator damageAnim;

    [SerializeField]
    AudioSource damage;

    [SerializeField]
    AudioSource healthSound;

    [SerializeField]
    AudioSource win;

    [SerializeField]
    AudioSource dead;

    [SerializeField]
    AudioSource partGet;

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

    float randomPitch;
    bool shield = false;

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
        randomPitch = Random.Range(0.8f, 1.2f);
        partGet.pitch = randomPitch;
        partGet.Play();
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
        healthSound.Play();
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
        if (!shield)
        {
            damage.Play();
            healthNumber = healthNumber - damageValue;
            if (healthNumber >= 3)
            {
                healthNumber = 3;
            }
            if (healthNumber <= 0)
            {
                healthNumber = 0;
            }
            damageAnim.SetBool("Hit", true);
            HealthUpdate();
        }
        shieldObject.SetActive(false);
        shield = false;
    }

    public void Upgrade()
    {
        //paddle.GetComponent<Paddle>().Resize(2f);
        paddle.GetComponent<Paddle>().Grow();
        scoreNumber = scoreNumber + 10;
        score.text = "Score: " + scoreNumber;
        Debug.Log("Upgrade");
    }

    public void Shield()
    {
        shield = true;
        shieldObject.SetActive(true);
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
                //damage.pitch = 1.2f;
                GameOver();
                break;
            case (1):
                health.GetComponent<Image>().sprite = healthOne;
                //damage.pitch =  0.9f;
                break;
            case (2):
                health.GetComponent<Image>().sprite = healthTwo;
                //damage.pitch = 1.1f;
                break;
            case (3):
                health.GetComponent<Image>().sprite = healthFull;
                //damage.pitch = 1f;
                break;
        }       
    }

    void GameOver()
    {
        health.GetComponent<Image>().sprite = healthZed;
        dead.Play();
    }
}
