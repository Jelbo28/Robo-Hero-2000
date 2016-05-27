using UnityEngine;
using System.Collections;


public class Pickup : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject monster;

    [SerializeField]
    float pointAddition;

    [SerializeField]
    int damageValue;


    #endregion

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            switch (gameObject.tag)
            {
                case ("Part"):
                    GM.instance.PartGet();
                    monster.GetComponent<DropInstantiation>().count--;
                    Destroy(gameObject);
                    break;
                case ("Health"):
                    GM.instance.HealthGet();
                    monster.GetComponent<DropInstantiation>().count--;
                    Destroy(gameObject);
                    break;
                case ("Damage"):
                    GM.instance.Damage(damageValue);
                    monster.GetComponent<DropInstantiation>().count--;
                    Destroy(gameObject, 0.1f);
                    break;
                case ("Point"):
                    GM.instance.PointGet(pointAddition);
                    monster.GetComponent<DropInstantiation>().count--;
                    Destroy(gameObject);
                    break;
                case ("Upgrade"):
                    GM.instance.Upgrade();
                    monster.GetComponent<DropInstantiation>().count--;
                    Destroy(gameObject);
                    break;
                case ("Downgrade"):
                    GM.instance.Downgrade();
                    monster.GetComponent<DropInstantiation>().count--;
                    Destroy(gameObject);
                    break;
                case ("Shield"):
                    GM.instance.Shield();
                    monster.GetComponent<DropInstantiation>().count--;
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}
