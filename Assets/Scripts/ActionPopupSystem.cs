using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionPopupSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public Button attacksButton;
    public Button healingButton;
    public Button spellsButton;
    public Button energyButton;


    //---------------------------------------

    public GameObject attacksSection;
    public Button attacksBackButton;
    public Button attack1Button;
    public Button attack2Button;

    public GameObject healingSection;
    public Button healingBackButton;
    public Button healingArcherButton;
    public Button healingKnightButton;

    public GameObject spellsSection;
    public Button spellsBackButton;
    public Button spellsPoisonButton;
    public Button spellsFireButton;



    //----------------------------------------

    public void AttacksPopUp()
    {
        attacksSection.SetActive(true);
    }

    public void AttacksPopDown()
    {
        attacksSection.SetActive(false);
    }

    //----------------------------------------

    public void HealingPopUp()
    {
        healingSection.SetActive(true);
    }

    public void HealingPopDown()
    {
        healingSection.SetActive(false);
    }

    //----------------------------------------

    public void SpellsPopUp()
    {
        spellsSection.SetActive(true);
    }

    public void SpellsPopDown()
    {
        spellsSection.SetActive(false);
    }

    //----------------------------------------

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
