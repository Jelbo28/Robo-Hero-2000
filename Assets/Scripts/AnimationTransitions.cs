using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimationTransitions : MonoBehaviour
{
    [SerializeField]
    Animator exitAnimator;

    public void Menu()
    {
        Debug.Log("Back to menu.");
        // Use this to load whatever scene the title screen is on.
        //SceneManager.LoadScene("Title Menu");
    }

    public void ButtonGlow()
    {
        exitAnimator.SetBool("ButtonGlow", true);
    }
}
