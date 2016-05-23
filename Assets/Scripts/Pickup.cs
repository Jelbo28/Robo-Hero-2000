using UnityEngine;
using System.Collections;


public class Pickup : MonoBehaviour
{
    #region Variables



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
                default:
                    break;
            }
            Destroy(gameObject, 0f);
        }
    }
}
