using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOverScreen : MonoBehaviour
{
    /*public void Setup()
    {
        gameObject.SetActive(true);

    }*/

    public void RestartButton()
    {
        //reloads jumpman scene
        SceneManager.LoadScene("FullScene");
    }
}
