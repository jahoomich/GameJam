using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public GameObject target;
    private entityScript entityScript;

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
    }
    void Start()
    {
        entityScript = target.GetComponent<entityScript>();
    }

    // Update is called once per frame
    void Update()
    {
        /*SetHealth(t.health);*/
        //set health to the health value of the game object provided via editor
        SetHealth(entityScript.health);
    }
}
