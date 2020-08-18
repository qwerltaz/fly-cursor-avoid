using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
