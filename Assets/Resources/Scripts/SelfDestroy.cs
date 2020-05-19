using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public bool changeAlpha;
    public float fadeTime;

    float timePassed;
    float fadeValue;
    bool changing;
    void Start()
    {
        changing = false;
        timePassed = 0;
        StartChanging();
    }

    // Update is called once per frame
    void Update()
    {
        if (changing)
        {
            timePassed += Time.deltaTime;
            fadeValue = Mathf.Clamp((1 - (fadeTime - timePassed) / fadeTime), 0, 1);
            GetComponent<Renderer>().material.SetFloat("_Transparency", fadeValue);
            Debug.Log(fadeValue);
        }

        if(fadeValue > 0.99f)
        {
            Destroy(gameObject);
        }
    }

    public void StartChanging()
    {
        changing = true;
    }
}
