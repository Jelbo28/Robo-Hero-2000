using UnityEngine;
using System.Collections;

public class EnemyActions : MonoBehaviour {

    // Serialized variables

    [SerializeField] float m_Speed;

    // public variables

    public bool yes;

    // private variables

    GameObject parts;
    PartActions box;
    Rigidbody2D m_Rb;
    Vector2 forward;
    Vector2 backwards;

    // private methods

    void Awake()
    {
        m_Rb = GetComponent<Rigidbody2D>();
        forward = new Vector2(m_Speed, 0);
        backwards = new Vector2(-m_Speed, 0);
        yes = true;
    }

    void FixedUpdate()
    {
        parts = GameObject.FindGameObjectWithTag("Drop");
        box = parts.GetComponent<PartActions>();
        
        if (yes)
        {          
            m_Rb.velocity = forward;  
        }
        else if (!yes)
        {
            m_Rb.velocity = backwards;
        }
    }  

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            yes = !yes;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "Drop")
        {
            box.box.enabled = true;
        }
    }

}
