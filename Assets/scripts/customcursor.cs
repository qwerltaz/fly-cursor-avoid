using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#pragma warning disable CS0618
public static class globals
{
    public static bool isaliveglobal = true;
}
public class customcursor : MonoBehaviour
{
    public Transform sparkle;
    TrailRenderer _trail;
    Vector2 targetpos;
    public CameraShake camerashake;
    public static bool isalive = true;
    public AudioSource deadsfx;
    public AudioClip[] audiocliparray;
    void Awake()
    {
        _trail = GetComponentInChildren<TrailRenderer>();
        deadsfx = GetComponent<AudioSource>();
        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
        _trail.GetComponentInChildren<TrailRenderer>().enabled = false;
        
    }

    void Start()
    {
        Cursor.visible = false;
        FindObjectOfType<TrailRenderer>().GetComponent<TrailRenderer>().Clear();
        _trail.GetComponentInChildren<TrailRenderer>().enabled = true;

    }
    void OnTriggerEnter2D()
    {
        if (isalive == true)
        {
            sparkle.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopsparkles());
            isalive = false;
            globals.isaliveglobal = false;
            StartCoroutine(camerashake.shake(.2f, .2f));
            deadsfx.clip = audiocliparray[UnityEngine.Random.Range(0, audiocliparray.Length)];
            deadsfx.PlayOneShot(deadsfx.clip);
            StartCoroutine(ToggleRenderer());
            StartCoroutine(respawn());
        }
    }
    void Update()
    {
        if (isalive == true)
        {
            targetpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            base.transform.position = targetpos;
        }
    }
    IEnumerator stopsparkles()
    {
        yield return new WaitForSeconds(.5f);
        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }
    IEnumerator ToggleRenderer()
    {
        yield return new WaitForSeconds(0f);
        GameObject.FindObjectOfType<dot>().GetComponent<SpriteRenderer>().enabled = false;
    }
    IEnumerator respawn()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isalive = true;


    }
}