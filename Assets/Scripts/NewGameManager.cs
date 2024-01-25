using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class newGameManager : MonoBehaviour
{
    //must be added in order
    [SerializeField] private Entity[] characters = new Entity[4];
    private int activeChar;
    private string[] charNames = { "Wizard", "Archer", "Knight", "Boss" };
    private Action action;
    public Action NewAction
    {
        set { action = value; }
    }

    void Start()
    {
        activeChar = 0;
    }
    void Update()
    {
        Debug.Log(string.Format("{0} turn", charNames[activeChar]));
    }

    public void ExecuteTurn()
    {
        debufftick();
        executeaction();

        action = null;
        if (winCondition())
        { 
            // do something
        }
        if (loseCondition())
        {
            //do something    
        }
        if (activeChar == 3) { activeChar = 0; }
        else { activeChar++; }
    }

    private void executeaction()
    {
        foreach (int target in action.Targets)
        {
            characters[target].ChangeHealth(action.Damage);
        }
        //add suspicion
        //apply debuffs
        //consider elemental debuffs
    }
    private void debufftick() 
    {
        //apply any effects (Damage over time) of debuffs
    }

    //method to check if both archer and knight have died
    public bool winCondition()
    {
        //if other two party members have died 
        if (characters[1].GetComponent<Entity>().Alive == false && characters[2].GetComponent<Entity>().Alive == false) { return true; }
        return false;
    }

    //method to check if the boss health has reached 0 
    public bool loseCondition() 
    {
        //if the boss health has reached 0 or the susbar has reached a threshold
        if (characters[3].GetComponent<Entity>().Alive == false || characters[0].GetComponent<Entity>().Alive == false) { return true; }
        return false;
    }
}



