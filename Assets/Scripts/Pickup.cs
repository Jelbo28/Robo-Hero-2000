using UnityEngine;
using System.Collections;


public class Pickup : MonoBehaviour
{
    #region Variables

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
                    Destroy(gameObject);
                    break;
                case ("Health"):
                    GM.instance.HealthGet();
                    Destroy(gameObject);
                    break;
                case ("Damage"):
                    GM.instance.Damage(damageValue);
                    Destroy(gameObject, 0.1f);
                    break;
                case ("Point"):
                    GM.instance.PointGet(pointAddition);
                    Destroy(gameObject);
                    break;
                case ("Upgrade"):
                    GM.instance.Upgrade();
                    Destroy(gameObject);
                    break;
                case ("Downgrade"):
                    GM.instance.Downgrade();
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}
