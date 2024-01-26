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
    [SerializeField]private Action teammateaction;
    [SerializeField] private Action bossaction;
    public Action NewAction
    {
        set { action = value; }
    }

    void Start()
    {
        activeChar = 0;
        Debug.Log(string.Format("{0} turn", charNames[activeChar]));
    }
    void Update()
    {
    }

    public void ExecuteTurn()
    {
        Debug.Log(string.Format("{0} turn", charNames[activeChar]));
        if (activeChar != 0) 
        {
            npcAction();
        }
        debufftick();
        executeaction();
        checkChars();
        action = null;
        if (winCondition())
        {
            // do something
        }
        if (loseCondition())
        {
            //do something    
        }
        changeturn();
        if (activeChar != 0) { ExecuteTurn(); }
    }

    private void executeaction()
    {
        characters[activeChar].ChangeSprite(1);
        foreach (int target in action.Targets)
        {
            characters[target].ChangeHealth(action.Damage);
            characters[target].AddDebuff(action.Debuff);
        }
        //add suspicion
        //apply debuffs
        //consider elemental debuffs
    }

    private void debufftick()
    {
        //apply any effects (Damage over time) of debuffs
    }

    private void checkChars()
    {
        foreach (Entity character in characters) 
        {
            if (character.Alive == false)
            {
                Debug.Log(string.Format("CHARACTER IS DEAD PROBABLY, {0}",character.Alive));
                character.ChangeSprite(2); 
                //character is dead, do something
            }
        }
    }

    private void npcAction()
    {
        if (activeChar == 1 || activeChar == 2)
        { action = teammateaction; }
        if (activeChar == 3)
        { action = bossaction; }
    }

    //method to check if both archer and knight have died
    public bool winCondition()
    {
        //if other two party members have died 
        if (characters[1].Alive == false && characters[2].Alive == false) { return true; }
        return false;
    }

    //method to check if the boss health has reached 0 
    public bool loseCondition()
    {
        //if the wizard/boss health has reached 0 or the suspicion bar has reached a threshold
        if (characters[3].Alive == false || characters[0].Alive == false) { return true; }
        return false;
    }

    private void changeturn()
    {
        if (activeChar == 3) { activeChar = 0; }
        else { activeChar++; }
    }
}