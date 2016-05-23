using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    #region Variables

    [SerializeField]
    Text parts;

    int partNumber = 0;

    [SerializeField]
    int totalParts = 15;

    public static GM instance = null;
    #endregion
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void PartGet()
    {
        partNumber++;
        parts.text = "Parts: " + partNumber + "/" + totalParts;
        CheckWin();
    }

    void CheckWin()
    {
        if (partNumber >= totalParts)
        {
            partNumber = 15;
            parts.text = "Parts: " + partNumber + "/" + totalParts;
            Debug.Log("Win");
        }
    }
}
