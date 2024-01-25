using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameMgr : MonoBehaviour
{
    //bigfatbum

    private int memberIndex = 0;
    public bool nextTurnValid;
    

    public bool canPerform = false;
    //string array to store the party members
    string[] partyMembers = {"wizard", "archer", "knight", "boss"};

    //integer member for the action type
    public int actionType;
    
    //two buttons to store 
    public GameObject[] wizardButtons = new GameObject[2];

    //public GameObject ntb;
    public GameObject actionBtn;

    //member for the cancel button game object
    public GameObject betrayBtn;
    public GameObject HealKnight;
    public GameObject HealArcher;


    public GameObject[] characters;
    public GameObject[] debuffCharacters;
    ///public GameObject x;
    //public GameObject y;
    //To call another class for sus bar
    //public SusBar SusBar;

    private void Start()
    {
        //memberIndex = 0;
        actionType = 0;
        
    }
    private void Update()
    {
        //Debug.Log("Boss health is: " + x.GetComponent<Entity>().health);
        //Debug.Log("Knight health is: " + y.GetComponent<Entity>().health);
        Debug.Log("Index is: " + memberIndex);
        SusBar.memberCheck(memberIndex);
        //Debug.Log("Active Member is: " + partyMembers[memberIndex]);
        //Debug.Log("Action type is: " + actionType);
        //Debug.Log("Next turn value: " + nextTurnValid);

        if (memberIndex == 0)
        {
            betrayBtn.SetActive(true);
            HealArcher.SetActive(true);
            HealKnight.SetActive(true);

        }
        else 
        {
            betrayBtn.SetActive(false);
            HealArcher.SetActive(false);
            HealKnight.SetActive(false);
        }
      
    }
    
    public void setAction(int x) 
    {
        actionType = x;
    }

    public void healArcher()
    {
        characters[1].GetComponent<entityScript>().ChangeHealth(10);
        changeTurn();
    }

    public void healKnight()
    {
        characters[2].GetComponent<entityScript>().ChangeHealth(10);
        changeTurn();
    }

    public void debuff()
    {
        characters[memberIndex].GetComponent<entityScript>().changeDebuff();
        changeTurn();
    }

    public void attack() {
        
        characters[memberIndex].GetComponent<entityScript>().attackTarget();
        changeTurn();
        
    }

    public void increaseIndex() { 
        //set the next turn variable to true
        memberIndex ++;
        

    }

    

    

    public void changeTurn() {
        if (memberIndex == 3)
        {
            memberIndex = 0;
                
        }
        else
        {
            memberIndex++;
        }
        
        
    }

    void setWizBtns(bool x) {
        for (int i = 0; i < 2; i++)
        {
            wizardButtons[i].SetActive(x);

        }
    }
    

}


