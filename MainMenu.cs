using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string startLevel;

    public string testLevel;


    public void NewGame()

    {
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(startLevel);
#pragma warning restore CS0618 // Type or member is obsolete
    }

    public void TestLevel()
    {

#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(testLevel);
#pragma warning restore CS0618 // Type or member is obsolete
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
