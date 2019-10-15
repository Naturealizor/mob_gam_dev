using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;              // added scene management using statement

public class Main_Menu_Controller : MonoBehaviour
{
    public void SwitchScene(int index = 0) {
        SceneManager.LoadScene(index);          // load the scene that as been specified
    }

    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }

    // public void UpdateTurnDirection(int direction) {
    //     UpdateTurnDirection = direction;
    // }
}
