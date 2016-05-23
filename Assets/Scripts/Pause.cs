using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject pause;

    bool pauseActive = false;
    #endregion
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive == true)
            {
                pause.SetActive(false);
                pauseActive = false;
            }
            else if (pauseActive == false)
            {
                pause.SetActive(true);
                pauseActive = true;
            }
        }
    }
}
