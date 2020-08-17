using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui_menu : MonoBehaviour
{
    public void changescene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
    public void quit()
    {
        Debug.Log("aww");
        Application.Quit();
    }

}
