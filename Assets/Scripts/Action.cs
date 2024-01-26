using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public AudioSource audioSource;
    public override string ToString() { return "YOU CREATED AN ACTION IDIOT"; }
    [SerializeField] private int dmg; //damage should be negative by default to inflict damage, positive for healing
    public int Damage
    {
        get { return dmg; }
    }

    [SerializeField] private int suspicion; //cost in suspicion, this only comes up when the wizard takes action
    public int Suspicion
    {
        get { return suspicion; }
    }

    [SerializeField] private List<int> target; //who is the action targeting?
    public List<int> Targets
    {
        get { return target; }
    }

    //0-2 = fire, electric, poison, 3 = neutral (for heals/party attacks)
    [SerializeField] private int eltype;
    public int ElementalType
    {
        get { return eltype; }
    }

    [SerializeField] private bool isdebuff;
    public bool IsDebuff
    {
        get { return isdebuff; }
    }

    //for custom debuff amounts?
    //debuff type, debuff timer
    [SerializeField] private int debuffTimer;
    private Debuff debuff;
    public Debuff Debuff
    {
        get { return debuff; }
    }

    // Start is called before the first frame update
    void Start()
    {
        debuff.type = eltype;
        debuff.timer = debuffTimer;
    }

    // Update is called once per frame
    void Update()
    {

    }
}