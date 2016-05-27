using UnityEngine;
using System.Collections;

public class DropInstantiation : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject[] parts;
    [SerializeField]
    GameObject[] points;
    [SerializeField]
    GameObject powerUp;
    [SerializeField]
    GameObject powerDown;
    [SerializeField]
    GameObject health;
    [SerializeField]
    GameObject[] damage;
    [SerializeField]
    GameObject shield;


    [SerializeField]
    Animator monsterAnim;
    [SerializeField]
    GameObject spawnPoint;

    
    public int count = 0;

    float randNum;
    int randPart;
    int randPoint;
    int randDamage;
    int chosenValue;




    #endregion


    void Awake()
    {
        InvokeRepeating("Spawn", 1.0f, 2.0f);
    }

    void FixedUpdate()
    {
        if (count > 5)
        {
            CancelInvoke();
        }
    }


    void Spawn()
    {
        count++;
        randNum = Random.Range(0f, 101f);
        if ((randNum >= 0) && (randNum <= 30))
        {
            randPart = Random.Range(0, 18);
            Instantiate(parts[randPart], spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else if ((randNum >= 31) && (randNum <= 40))
        {
            randPoint = Random.Range(0, 1);
            Instantiate(points[randPoint], spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else if ((randNum >= 41) && (randNum <= 50))
        {
            Instantiate(powerUp, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else if ((randNum >= 51) && (randNum <= 60))
        {
            Instantiate(powerDown, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else if ((randNum >= 61) && (randNum <= 70))
        {
            Instantiate(health, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else if ((randNum >= 71) && (randNum <= 95))
        {
            randDamage = Random.Range(0, 101);
            if (randDamage >= 95)
            {
                chosenValue = 0;
            }
            else if (randDamage <= 95)
            {
                chosenValue = 1;
            }
            Instantiate(damage[chosenValue], spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else if ((randNum >= 96) && (randNum <= 101))
        {
            Instantiate(shield, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        monsterAnim.SetTrigger("ThrowGo");
    }


    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Spawn();
    }
}
