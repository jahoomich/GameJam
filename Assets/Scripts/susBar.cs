
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SusBar : MonoBehaviour
{
    public Slider slider;

    //public Gradient gradient;
    public Image fill;
    float count = 0;
    public float maxSus = 100;
    public static int check;

    public void SetSus(float susVal) {
        if(susVal > 0) {
            //adds suspicion value with multiplyer
            count++;
            slider.value += susVal*count;
            susCheck();
        //makes sure the wizard is the one attacking
        }else if(susVal < 0 && check == 0) {
            count = 0;
            slider.value += susVal;
        }
    }
    void susCheck() {
        if (slider.value >= maxSus) {
            // change scene
            SceneManager.LoadScene("GameOverScene");
        }
    }
    //keeps track of whos attacking
    public static void memberCheck(int member) {
        check = member;
    }
}
