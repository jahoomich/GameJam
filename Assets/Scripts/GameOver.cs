using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOverScreen : MonoBehaviour {

    public void RestartButton() {
        SceneManager.LoadScene("NEWSCENE");
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
