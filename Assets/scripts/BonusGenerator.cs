using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BonusGenerator : MonoBehaviour
{
    [SerializeField] private Button[] btns;
    [SerializeField] private GameObject podlojka;
    private bool isBonusActive = false;
    private int secondsBeforeShow;
    private int index = 0;
    

    [SerializeField] private int defaultTimerValue;

    private void Start()
    {
        
    }

    private void timer()
    {
        secondsBeforeShow--;
        if (secondsBeforeShow < 0)
        {
            if (podlojka.activeSelf)
            {
                DisableButtons();
                podlojka.SetActive(false);
            }
            else
            {
                podlojka.SetActive(true);
                EnableButton();
            }
        }
    }

    private void EnableButton()
    {
        btns[index].gameObject.SetActive(true);

        if (++index >= btns.Length) index = 0;

        secondsBeforeShow = defaultTimerValue;
    }

    private void DisableButtons() 
    {
        foreach (Button go in btns)
            go.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GameLogic.instance.oneSecondTimer += timer;
    }

    private void OnDisable()
    {
        GameLogic.instance.oneSecondTimer -= timer;
    }

}
