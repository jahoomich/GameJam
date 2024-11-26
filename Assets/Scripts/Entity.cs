using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Entity : MonoBehaviour
{
    [SerializeField] private int id; //may go unused, but ideally, could be used to target
    public GameObject damageEffects;
    public TMP_Text text;
    //[SerializeField] private Action action;
    [SerializeField] private Color32 dmgcolour = new Color32(255,0,0,255);
    [SerializeField] private Color32 healcolour = new Color32(0,255,0,255);
    [SerializeField] private Color32 poisoncolour = new Color32(64,6,144,255);
    [SerializeField] private Color32 firecolour = new Color32(255,165,0,255);
    [SerializeField] private Color32 staticcolour = new Color32(255,255,0,255);
    public bool changing = false;
    [SerializeField] private float damageAniTime;
    public float timex = 0;
    [SerializeField] private string changeVal = "";
    public int CharID
    {
        get { return id; }
    }
    [SerializeField] protected float maxhealth;
    private float health;
    public float Health
    {
        get
        {
            //Debug.Log(string.Format("Health getter called: {0}", health));
            return health;
        }
    }
    private List<Debuff> debufflist = new List<Debuff>();
    private Animator m_Animator;

    //Alive property checks health values, if it's above 0, target is considered alive
    //else, they're dead
    public bool Alive
    {
        get
        {
            if (health > 0)
            {
                //Debug.Log("character is alive lol");
                //Debug.Log(string.Format("Health, maxhealth, {0}, {1}", health, maxhealth));
                return true;
            }
            else { return false; }
        }
    }

    public bool Debuffed
    {
        get
        {
            if (debufflist.Count > 0) { return true; }
            else { return false; }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        //Debug.Log(string.Format("Health set to max, {0} = {1}", health, maxhealth));
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(changing == true){
            timex += Time.deltaTime;
            if(timex > damageAniTime){
                damageEffects.SetActive(false);
                timex = 0;
                changing = false;
            }
        }
    }

    //if change > 0, action is healing,
    //if change < 0, action is damaging
    public void ChangeHealth(float change)
    {
        //Debug.Log(string.Format("Changehealth called {0}", change));
        //here also for new debuff types
        foreach (Debuff debuff in debufflist)
        {
            switch(debuff.type){ //types of debuffs
                case 1: //fire
                    if(change < 0){
                        change *= 1.5f;
                        updateVal(change, firecolour);
                        damageEffects.SetActive(true);
                        changing = true;
                    }
                    break;
                case 2: //static
                    //update a bool here IsStatic
                    if(Static.Target == 1){
                        //Debug.Log("Archer static");
                        Static.IsStaticArcher = true;
                    }else if(Static.Target == 2){
                        //Debug.Log("Knight static");
                        Static.IsStaticKnight = true;
                    }
                    //Debug.Log("what is going "+Static.IsStatic);
                    updateVal(change, staticcolour);
                    break;
                case 3: //poison
                    if(change < 0){
                        change *= 1.5f;
                        updateVal(change, poisoncolour);
                        damageEffects.SetActive(true);
                        changing = true;
                    }
                    break;
            }
            // if (debuff.type == 3 && change < 0)
            // {
            //     change *= 1.5f;
            //     updateVal(change, poisoncolour);
            //     damageEffects.SetActive(true);
            //     changing = true;
            // }
            debuff.TickDown();
        }

        //branch if changehealth action is negative/damaging
        if (change < 0)
        {
            health += (change);
            updateVal(change, dmgcolour);
            damageEffects.SetActive(true);
            changing = true;
            //damageEffects.SetActive(false);
        }
        //occurs if changehealth action is positive/healing (or does nothin')
        else
        {
            health += change;
            updateVal(change, healcolour);
            damageEffects.SetActive(true);
            changing = true;
            if (health > maxhealth) { health = maxhealth; }
        }
        removedebuff();
    }

    public void AddDebuff(Debuff newdebuff)
    {
        debufflist.Add(newdebuff);
    }

    private void removedebuff()
    {
        List<Debuff> newlist = new List<Debuff>();
        foreach (Debuff debuff in debufflist)
        {
            if (debuff.timer != 0)
            { 
                newlist.Add(debuff); 
            }
            //Debug.Log(debuff);
        }
        //action.isStatic = false;
        debufflist = newlist;
        //Debug.Log(debufflist);
    }

    public void ChangeSprite(int spriteIndex)
    {
        switch (spriteIndex)
        {
            case 0:
                //set sprite neutral
                break;
            case 1:
                m_Animator.SetTrigger("Attack");
                break;
            case 2:
                Debug.Log("Death animation called");
                m_Animator.SetTrigger("Dead");
                break;
                //hello my friend
                //something silly
        }
    }
    void updateVal(float change, Color32 colour){
        changeVal = string.Format("{0:N0}", change);
        text.color = colour;
        text.text = string.Format("{0} {1}", changeVal, "");
    }
}