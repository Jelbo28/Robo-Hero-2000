using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PressSpace : MonoBehaviour
{
    #region Variables
    [SerializeField]
    Text space;

    [SerializeField]
    GameObject fade;

    int timesPressed = 0;
    #endregion
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timesPressed >= 1)
            {
                timesPressed++;
                fade.SetActive(true);
            }
            if (timesPressed < 1)
            {
                timesPressed++;
                space.text = "Press Space To Play";
            }
        }
    }
}
