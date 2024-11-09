using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;
    public Gradient gradient;
    public Image fill;

    [SerializeField] private GameObject target;
    [SerializeField] private string healthVal = "";
    private Entity entity;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        updateHealthVal(slider.value);
    }
    void Start()
    {
        entity = target.GetComponent<Entity>();
        SetMaxHealth(entity.Health);
        SetHealth(entity.Health);
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth(entity.Health);
        //set health to the health value of the game object provided via editor
        updateHealthVal(entity.Health);
    }
    void updateHealthVal(float health){
        if(health>0){
            healthVal = string.Format("{0:N0}", health);
            text.text = string.Format("{0} {1}", healthVal, "");
        }
    }
}
