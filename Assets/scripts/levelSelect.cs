using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class levelSelect : MonoBehaviour
{
    public Button[] lvlButtons;
    public Text scoretext;
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for(int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }
}
