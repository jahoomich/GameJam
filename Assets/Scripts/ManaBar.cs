using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;

    //public Gradient gradient;
    public Image fill;
    private bool hasMana = true;
    private bool hasEnoughMana = true;
    public float maxMana = 100;
    public static int check;

    public void SetMana(float manaVal) {
        if(manaVal !=0) {
            //adds mana value
            slider.value += manaVal;
            manaCheck();
        }
    }
    void manaCheck() {
        if (slider.value <= 0) {
            slider.value = 0;
            hasMana = false;
        }
    }
    public void canAttack(float manaAmount){
        float checkValue = slider.value;
        if(checkValue+manaAmount<=0){
            hasEnoughMana = false;
        }else{
            hasEnoughMana = true;
        }
        //Debug.Log(HasEnoughMana);
    }
    public bool HasMana{
        get{return hasMana;}
        set{hasMana=value;}
    }
    public bool HasEnoughMana{
        get{return hasEnoughMana;}
        set{hasEnoughMana = value;}
    }
    //keeps track of whos attacking
    public static void memberCheck(int member) {
        check = member;
    }
}
