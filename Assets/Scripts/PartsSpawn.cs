using UnityEngine;
using System.Collections;

public class PartsSpawn : MonoBehaviour {

    // Serialized variables

    [SerializeField] GameObject[] parts;
    [SerializeField] float m_ForceX;

    // public variables

    public int count;

    // private variables

    GameObject monster;
    EnemyActions direction;
    ConstantForce2D toss;

    // private methods

    void Awake()
    {
        monster = GameObject.Find("Monster");
        direction = monster.GetComponent<EnemyActions>();
        InvokeRepeating("Spawn", 1.0f, 2.0f);
    }

    void FixedUpdate()
    {
        foreach (GameObject part in parts)
        {
            toss = part.GetComponent<ConstantForce2D>();
        }

        if (count > 3)
        {
            CancelInvoke();
        }

        if (direction.yes)
        {
            toss.relativeForce = new Vector2(- m_ForceX, 0);
        }
        else if (!direction.yes)
        {
            toss.relativeForce = new Vector2(m_ForceX, 0);
        }
    }

    void Spawn()
    {
        int i = Random.Range(0, parts.Length - 1);
        Debug.Log(i);

        GameObject part = parts[i];

        Instantiate(part, monster.transform.position, monster.transform.rotation);
        count++;
    }

}
