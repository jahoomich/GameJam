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

    public GameObject mainSection;
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
    public GameObject spellsPoisonSection;
    public Button spellsFireButton;
    public GameObject spellsParalyzeSection;

    public Button poisonArcherButton;
    public Button poisonKnightButton;
    public Button poisonBackButton;

    public Button paralyzeArcherButton;
    public Button paralyzeKnightButton;
    public Button paralyzeBackButton;



    //----------------------------------------

    public void AttacksPopUp()
    {
        attacksSection.SetActive(true);
        mainSection.SetActive(false);
    }

    public void AttacksPopDown()
    {
        attacksSection.SetActive(false);
        mainSection.SetActive(true);
    }

    //----------------------------------------

    public void HealingPopUp()
    {
        healingSection.SetActive(true);
        mainSection.SetActive(false);
    }

    public void HealingPopDown()
    {
        healingSection.SetActive(false);
        mainSection.SetActive(true);
    }

    //----------------------------------------

    public void SpellsPopUp()
    {
        spellsSection.SetActive(true);
        mainSection.SetActive(false);
    }

    public void SpellsPopDown()
    {
        spellsSection.SetActive(false);
        mainSection.SetActive(true);
    }



    //----------------------------------------

    public void PoisonPopUp()
    {
        spellsPoisonSection.SetActive(true);
        spellsSection.SetActive(false);

    }

    public void PoisonPopDown()
    {
        spellsPoisonSection.SetActive(false);
        spellsSection.SetActive(true);

    }
    //------------------------------------------------

    public void ParalyzePopUp()
    {
        spellsParalyzeSection.SetActive(true);
        spellsSection.SetActive(false);

    }

    public void ParalyzePopDown()
    {
        spellsParalyzeSection.SetActive(false);
        spellsSection.SetActive(true);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
