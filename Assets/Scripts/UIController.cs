using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI counterTxt;


    private static UIController _instance;
    public static UIController Instance
    {
        get { return _instance; }
    }


    private void Awake()
    {
        //implements singleton (instance) to invoke  IncreaseScore -> 10pts -check
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;


    }

    public void IncreaseCountCollectible()
    {
        float score = float.Parse(counterTxt.text);
        score++;
        counterTxt.text = score.ToString();
    }

}
