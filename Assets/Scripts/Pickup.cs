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
                    break;
                case ("Health"):
                    GM.instance.HealthGet();
                    break;
                case ("Damage"):
                    GM.instance.Damage(damageValue);
                    break;
                case ("Point"):
                    GM.instance.PointGet(pointAddition);
                    break;
                case ("Upgrade"):
                    GM.instance.Upgrade();
                    break;
                case ("Downgrade"):
                    GM.instance.Downgrade();
                    break;
                default:
                    break;
            }
            Destroy(gameObject, 0f);
        }
    }
}
