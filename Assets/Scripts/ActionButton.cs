using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : MonoBehaviour
{
    public AudioSource audioSource;

    //int dmg, int basesuspicion, List<int> targets, int element = 4, bool debuff = false, int debufftimer = 0
    //[SerializeField] private int damage;
    //[SerializeField] private int suspicion;
    //[SerializeField] private List<int> targets;
    //[SerializeField] private int element;
    //[SerializeField] private bool isDebuff;
    //[SerializeField] private int debufftimer;

    private Action action;
    private newGameManager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        action = GetComponent<Action>();
        gamemanager = this.GetComponentInParent<newGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CreateAction()
    {
        Debug.Log(string.Format("CREATING ACTION COPY: {0}", action));
        gamemanager.NewAction = this.action;
        gamemanager.ExecuteTurn();
        audioSource.Play();

    }
}