using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.LookDev;

[ExecuteInEditMode]

public class TextAnimator : MonoBehaviour
{
    

    [SerializeField]
    private string _message;

    [SerializeField]
    float _stringAnimationDuration;

    [SerializeField]
    private TextMeshProUGUI _animatedText;

    [SerializeField]
    private AnimationCurve _sizeCurve;

    [SerializeField]
    private float _sizeScale;


    [SerializeField]
    [Range(0.0001f, 1)]
    private float _charAnimationDuration;


    [SerializeField]
    [Range(0, 1)]
    private float _editorTValue;


    private float _timeElapsed;

    private Coroutine runningCoroutine;

    private void Start()
    {
        Debug.Log("<3");
        runningCoroutine = StartCoroutine(routine: RunAnimation(waitForSeconds: 1));
    }

    private void Update()
    {
        

        /*if (runningCoroutine != null)
        {
            //----
        }

        else
        {
            Debug.Log("Run again!");
            runningCoroutine = StartCoroutine(routine: RunAnimation(waitForSeconds: 0));
        }*/

        EvaluateRichText(_editorTValue);
    }


    IEnumerator RunAnimation(float waitForSeconds)
    {
        yield return new WaitForSeconds(waitForSeconds);
        float t = 0;
        
        while (true)
        {
            EvaluateRichText(t);
            t = _timeElapsed / _stringAnimationDuration;
            _timeElapsed += Time.deltaTime;

            yield return null;
        }
        yield return StartCoroutine(routine: RunAnimation(waitForSeconds: 0)); 

        //HELP I HAVE NO CLUE HOW TO DO THIS


    }

    void EvaluateRichText(float t)
    {
        _animatedText.text = "";
        for (int i = 0; i < _message.Length; i++)
        {
            _animatedText.text += EvaluateCharRichText(_message[i], _message.Length, cPosition: i, t);
        }
    }

    private string EvaluateCharRichText(char c, int sLength, int cPosition, float t)
    {
        float startPoint = ((1 - _charAnimationDuration) / (sLength - 1)) * cPosition;

        float endPoint = startPoint + _charAnimationDuration;

        float subT = t.Map(fromLow: startPoint, fromHigh: endPoint, toLow: 0, toHigh: 1);

        string sizeStart = $"<size={_sizeCurve.Evaluate(subT) * _sizeScale}%>";
        string sizeEnd = "</size>";

        return sizeStart + c + sizeEnd;
    }
}


public static class Extensions
{
    public static float Map(this float value, float fromLow, float fromHigh, float toLow, float toHigh)
    {
        return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
    }
}


