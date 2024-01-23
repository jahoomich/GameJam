using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    //for damage, heal and suspicion, gets added to message
    public int quantity; 
    Text text;
    
    [SerializeField] private Color dmgcolour = new Vector4(0.8f, 0.2f, 0.2f, 0.5f);
    [SerializeField] private Color healcolour = new Vector4(0.2f, 0.8f, 0.2f, 0.5f);
    [SerializeField] private Color debuffcolor = new Vector4(0.8f, 0.8f, 0.2f, 0.5f);
    [SerializeField] private Color suspicioncolor = new Vector4(1f, 0.1f, 0.1f, 0.7f);

    [SerializeField] private string dmgmessage = " health";
    [SerializeField] private string debuffmessage = "Debuff applied";
    [SerializeField] private string suspicionmessage = " suspicion";

    private string switchmessage;
    private Color switchcolor;

    // Start is called before the first frame update
    void Start()
    {

    }

    //faux constructor
    //msg types: 0 = dmg, 1 = heal, 2 = debuff, 3 = suspicion meter
    public void Setup(int msgtype, int quantity)
    {
        text = GetComponentInParent<Text>();
        text.color = new Vector4(0f, 0f, 0f, 0f);
        switch (msgtype)
        {
            default:
            case 0:
                switchcolor = dmgcolour;
                text.text = string.Format("{0} {1}",quantity,dmgmessage);
                break;
            case 1:
                switchcolor = healcolour;
                text.text = string.Format("+{0} {1}",quantity,dmgmessage);
                break;
            case 2:
                switchcolor = debuffcolor;
                text.text = debuffmessage;
                break;
            case 3:
                switchcolor = suspicioncolor;
                text.text = string.Format("+{0} {1}",quantity,suspicioncolor);
                break;
        }
    }

    public void SetActive()
    {
        text.color = switchcolor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
