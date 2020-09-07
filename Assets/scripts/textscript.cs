using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textscript : MonoBehaviour
{
    float score;
    public Text scoretext;
    void Start()
    {
        score = 0f;
        globals.isaliveglobal = true;
    }
    void Update()
    {
        if (globals.isaliveglobal == true)
        {
            score += (60 * Time.deltaTime);
            scoretext.text = score.ToString("0");
        }
    }
    void update()
    {
        if (scoretext.text == "400")
        {
            Debug.Log("1000 here");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
