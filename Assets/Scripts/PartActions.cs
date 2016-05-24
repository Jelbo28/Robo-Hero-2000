using UnityEngine;
using System.Collections;

public class PartActions : MonoBehaviour {

    // public variables

    public Collider2D box;

    // private variables

    PartsSpawn manager;

    // private methods

    void Awake()
    {
        manager = GameObject.Find("PartsManager").GetComponent<PartsSpawn>();
        box = gameObject.GetComponent<Collider2D>();
        box.enabled = false;
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            manager.count--;
            Destroy(gameObject, 1.0f);
        }
    }

}
