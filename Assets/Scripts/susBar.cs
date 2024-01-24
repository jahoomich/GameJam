using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class susBar : MonoBehaviour {
    float susBarLevel = 0;
    [SerializeField] float maxSus = 100;
    [SerializeField] float susSize = 0;
    [SerializeField] float susBarSize = 2;

    //takes in sus change value and adds it to total sus level
    public void susChange(float susVal) {
        susBarLevel += susVal;
        if (susBarLevel < 0){
            susBarLevel = 0;
        }
        displayBar();
        susCheck();
    }

    //checks if max sus has been reached
    void susCheck() {
        if (susBarLevel >= maxSus) { 
            // change scene
            //SceneManager.LoadScene("GameOverScene")
        }
    }

    //updates the visual sus bar on the screen
    void displayBar() {
        susSize += ((susBarLevel / maxSus)*susBarSize);
        gameObject.transform.localScale = new Vector2(susSize, 0.1f);
      
    }
}
