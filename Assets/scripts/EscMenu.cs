using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
    public int X;
    public int Y;

    public POINT(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

}

public class EscMenu : MonoBehaviour
{
    bool isMenu = false;
    public GameObject pauseMenuUI;
    public TrailRenderer _trail;
    POINT lastCursorPos;
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out POINT lpPoint);
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenu == false)
            {
                POINT lpPoint;
                GetCursorPos(out lpPoint);
                lastCursorPos = lpPoint;
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                isMenu = true;
                Cursor.visible = true;
                _trail.GetComponent<TrailRenderer>().enabled = false;
                GameObject.FindObjectOfType<dot>().GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                SetCursorPos(lastCursorPos.X, lastCursorPos.Y);
                pauseMenuUI.SetActive(false);
                Cursor.visible = false;
                isMenu = false;
                _trail.GetComponent<TrailRenderer>().enabled = true;
                GameObject.FindObjectOfType<dot>().GetComponent<SpriteRenderer>().enabled = true;
                Time.timeScale = 1f;
            } 
        }
    }
    //below are button functions
    public void nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void levelOne()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Cursor.visible = true;
    }

    public void quit()
    {
        Debug.Log("I quit");
        Application.Quit();
    }
}


