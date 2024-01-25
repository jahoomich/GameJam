
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            count++;
            slider.value += susVal*count;
            susCheck();
        }else if(susVal < 0 && check == 0) {
            count = 0;
            slider.value += susVal;
        }
    }
    void susCheck() {
        if (slider.value >= maxSus) {
            // change scene
            //SceneManager.LoadScene("GameOverScene")
        }
    }
    public static void memberCheck(int member) {
        check = member;
    }
}
