using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int scene;
    public Animator transition;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LoadLevel(scene));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("New Trigger");
        //wait for animation
        yield return new WaitForSeconds(transitionTime);
        //load scene
        SceneManager.LoadScene(levelIndex);
    }

}
