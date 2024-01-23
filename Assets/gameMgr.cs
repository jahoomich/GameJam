using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameMgr : MonoBehaviour
{
    public static int memberIndex = 0;
    public static bool nextTurn = false;
    public static bool wizardAction = false;
    //string array to store the party members
    string[] partyMembers = { "wizard", "knight", "archer", "boss"};

    //two buttons to store 
    public GameObject[] wizardButtons = new GameObject[2];

    //public GameObject ntb;
    public GameObject actionBtn;

    private void Start()
    {
        memberIndex = 0;
    }
    private void Update()
    {

        Debug.Log("Active Member is: " + partyMembers[memberIndex]);

        //if the wizard is active
        if (memberIndex == 0)
        {
            actionBtn.SetActive(false);

            //display option to either attack or to perform traitor action
            for (int i = 0; i < 2; i++)
            {
                wizardButtons[i].SetActive(true);

            }
        }
        else {
            actionBtn.SetActive(true);
            for (int i = 0; i < 2; i++)
            {
                wizardButtons[i].SetActive(false);

            }
        }
    }

    public void dfdsfds() { }

    public static void checkTurn() { 
        //set the next turn variable to true
        nextTurn = true;
    }

    public static void checkWizardTurn() {
        if (memberIndex == 0) { 
            wizardAction = true;
        }
    }

    public static void changeTurn() {
        
        

        if (nextTurn == true || wizardAction == true)
        {

            //check if member index has not reached the bound threshold
            if (memberIndex == 3)
            {
                //reset back to 0
                memberIndex = 0;
            }
            else
            {
                //increment the value to go to the next member
                memberIndex++;
            }
            nextTurn = false;
            wizardAction = false;
        }
        
    }
    

}



