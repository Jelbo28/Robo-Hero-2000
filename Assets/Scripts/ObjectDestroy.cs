using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour
{
	void Awake()
    {
        Destroy(gameObject, 5f);
    }
}
