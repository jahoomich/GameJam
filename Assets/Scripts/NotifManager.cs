using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotifManager : MonoBehaviour
{
    [SerializeField] private List<Image> icons = new List<Image>();

    public void SetActive(List<Image> icons)
    {
        foreach (Image icon in icons)
        {
            icon.enabled = true;
        }
    }

    public void SetActive(int iconid)
    {
        icons[iconid].enabled = true;
    }

    public void SetInactive(List<Image> icons)
    {
        foreach (Image icon in icons)
        {
            icon.enabled = false;
        }
    }

    public void SetInactive(int iconid)
    {
        icons[iconid].enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
