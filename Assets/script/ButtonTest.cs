using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTest : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool buttonClick = false;
    public static bool overClick = false;
    string Scenename = "Scene1";
    public void Startbutton()
    {
        buttonClick = true;
    }
    
    public void Quitbutton()
    {
        overClick = true;
        Application.Quit();

    }
}
