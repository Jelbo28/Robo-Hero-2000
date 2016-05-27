using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour
{
    #region Variables

    [SerializeField]
    GameObject monster;
    #endregion

    void Awake()
    {
        monster.GetComponent<DropInstantiation>().count--;
        Destroy(gameObject, 5f);
    }
}
