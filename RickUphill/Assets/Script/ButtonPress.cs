using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {

    // Script used for UI buttons

	public void PlayGame () {
        GameSceneManager.LoadLevel(3);
	}

    public void ShowCredits()
    {
        GameSceneManager.LoadLevel(2);
    }

    public void BacktoMenu()
    {
        GameSceneManager.LoadLevel(1);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
