using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimationTransitions : MonoBehaviour
{
    [SerializeField]
    Animator exitAnimator;

    [SerializeField]
    GameObject thump;

    [SerializeField]
    AudioSource boop;

    [SerializeField]
    AudioSource quit;

    [SerializeField]
    AudioSource start;

    float length = 0f;

    public void Menu()
    {
        boop.Play();
        StartCoroutine(WaitForAudio(boop));
        Debug.Log("Back to menu.");
        // Use this to load whatever scene the title screen is on.
        SceneManager.LoadScene("Title Menu");
    }

    public void Credits()
    {
        boop.Play();
        StartCoroutine(WaitForAudio(boop));
        //Debug.Log(boop.clip.length);
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Debug.Log("Quits");
        quit.Play();
        StartCoroutine(WaitForAudio(quit));
        Application.Quit();
    }

    public void Play()
    {
        start.Play();
        StartCoroutine(WaitForAudio(start));
        Debug.Log("Play");
        //SceneManager.LoadScene("Level Name");
    }

    public void ButtonGlow()
    {
        exitAnimator.SetBool("ButtonGlow", true);
        
    }

	public void ThumpEffect()
	{
		thump.GetComponentInChildren<ParticleSystem>().Play(true);
	}

    IEnumerator WaitForAudio(AudioSource name)
    {
        yield return new WaitForSeconds(name.clip.length);
    }
}
