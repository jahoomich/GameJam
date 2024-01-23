using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class susBar : MonoBehaviour {
    float susBarLevel = 0;
    [SerializeField] float maxSus = 100;
    [SerializeField] float susSize = 0;
    [SerializeField] float susBarSize = 2;
    void Start() {
        displayBar();
    }

    // Update is called once per frame
    /*void Update() {
        displayBar();
    }*/

    void susChange(float susVal) {
        if(susVal < 0) {
            susBarLevel += susVal;
            susCheck();
        }else {
            susBarLevel -= susVal;
            if(susBarLevel < 0) { 
                susBarLevel = 0;
            }
        }
    }

    void susCheck() {
        if (susBarLevel >= maxSus) { 
            // change scene
            //SceneManager.LoadScene("endscene")
        }
    }

    void displayBar() {
        susSize += ((susBarLevel / maxSus)*susBarSize);
        gameObject.transform.localScale = new Vector2(susSize, 0.1f);
      
    }
}
