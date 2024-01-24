using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameMgr : MonoBehaviour
{
    public int memberIndex = 0;
    public bool nextTurn = false;
    public static bool wizardAction = false;

    bool canPerform = false;
    //string array to store the party members
    string[] partyMembers = { "wizard", "knight", "archer", "boss"};

    //integer member for the action type
    public int actionType;
    
    //two buttons to store 
    public GameObject[] wizardButtons = new GameObject[2];

    //public GameObject ntb;
    public GameObject actionBtn;

    //member for the cancel button game object
    public GameObject cancelBtn;

    ///public GameObject x;
    //public GameObject y;

    private void Start()
    {
        memberIndex = 0;
        actionType = 0;
    }
    private void Update()
    {
        //Debug.Log("Boss health is: " + x.GetComponent<Entity>().health);
        //Debug.Log("Knight health is: " + y.GetComponent<Entity>().health);
        //Debug.Log("Index is: " + memberIndex);
        //Debug.Log("Active Member is: " + partyMembers[memberIndex]);
        //Debug.Log("Action type is: " + actionType);
        //Debug.Log("Next turn value: " + nextTurn);

        switch (actionType) 
        {
            case 0:
                canPerform = false; break;
            case 1:
                canPerform = true; break;
            case 2:
                canPerform = true; break;
        }

        //responses to nextTurn values
        switch (nextTurn) 
        {
            //if it is set to true -> I want to remove the cancel button
            case true:
                cancelBtn.SetActive(false);
                setWizBtns(false);
                break;
            case false:
                if (memberIndex == 0 && canPerform == false)
                {
                    cancelBtn.SetActive(false);
                }
                else {
                    cancelBtn.SetActive(true);
                    setWizBtns(true);
                }
                
                break;
        }

        if (canPerform == true)
        {
            actionBtn.SetActive(true);
            
        }
        else {
            actionBtn.SetActive(false);
            
        }

        //if the wizard is active
        if (memberIndex == 0 && nextTurn == false)
        {
            setWizBtns(true);

            /*
            //display option to either attack or to perform traitor action
            for (int i = 0; i < 2; i++)
            {
                wizardButtons[i].SetActive(true);

            }
            */
        }
        else
        {
            cancelBtn.SetActive(false);
            actionType = 1;
            //actionBtn.SetActive(true);
            setWizBtns(false);
        }
    }

    public void setAction(int x) 
    {
        actionType = x;
    }

    public void checkTurn() { 
        //set the next turn variable to true
        nextTurn = true;
    }

    public void checkWizardTurn() {
        if (memberIndex == 0) { 
            wizardAction = true;
        }
    }

    public void changeTurn() {
        
        

        if (nextTurn == true || wizardAction == true)
        {

            //check if member index has not reached the bound threshold
            if (memberIndex == 3)
            {
                //reset back to 0
                memberIndex = 0;
                actionType = 0;
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

    void setWizBtns(bool x) {
        for (int i = 0; i < 2; i++)
        {
            wizardButtons[i].SetActive(x);

        }
    }
    

}



