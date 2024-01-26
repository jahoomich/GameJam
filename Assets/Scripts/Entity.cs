using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private int id; //may go unused, but ideally, could be used to target
    public int CharID
    {
        get { return id; }
    }
    [SerializeField] protected float maxhealth;
    private float health;
    public float Health
    {
        get { return health; }
    }
    private List<Debuff> debufflist = new List<Debuff>();
    private Animator m_Animator;

    //Alive property checks health values, if it's above 0, target is considered alive
    //else, they're dead
    public bool Alive
    {
        get
        {
            if (health > 0) { return true; }
            else { return false; }
        }
    }

    public bool ID
    {
        get { return ID; }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //if change > 0, action is healing,
    //if change < 0, action is damaging
    public void ChangeHealth(int change)
    {
        //Debug.Log("calling changehealth");
        //branch if changehealth action is negative/damaging
        if (change < 0)
        {
            health += (change);
        }
        //occurs if changehealth action is positive/healing (or does nothin')
        else
        {
            health += change;
            if (health > maxhealth) { health = maxhealth; }
        }
    }

    public void AddDebuff(Debuff newdebuff)
    {
        debufflist.Add(newdebuff);
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
                m_Animator.SetTrigger("Dead");
                break;
        }
    }
}