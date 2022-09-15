using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class BuysBase : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] protected int _priceUsual;
    [SerializeField] protected int _premiumPrice;
    [SerializeField] protected bool isBuyUsualMoney;
    public ulong priceUsual => (ulong)(_priceUsual * Mathf.Pow(1.07f, buysAmount));
    protected int buysAmount;

    [Header("UI Elements")]
    [SerializeField] protected TextMeshProUGUI AmountBuys;
    [SerializeField] protected TextMeshProUGUI priceText;
    [SerializeField] protected TextMeshProUGUI bonusText;
    protected Button _BuyButton;
    protected Color textColor;


    private void Awake()
    {
        textColor = priceText.color;
        _BuyButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        GameLogic.instance.everyFrameEvent += CheckBuy;
        _BuyButton?.onClick.AddListener(Buy);
        LoadProgress();
        updateText();
    }


    private void OnDisable()
    {
        GameLogic.instance.everyFrameEvent -= CheckBuy;
        _BuyButton?.onClick.RemoveListener(Buy);
        SaveProgress();
    }

    protected void CheckBuy()
    {
        if (isBuyUsualMoney)
            usualCheck();
        else
            premiumCheck();
    }

    protected void premiumCheck()
    {
        if(_premiumPrice <= GameLogic.instance.premiumMoney)
        {
            _BuyButton.interactable = true;
            priceText.color = textColor;
        }
        else
        {
            _BuyButton.interactable = false;
            priceText.color = Color.red;
        }
    }

    public void usualCheck()
    {
        if (priceUsual <= GameLogic.instance.money)
        {
            _BuyButton.interactable = true;
            priceText.color = textColor;
        }
        else
        {
            _BuyButton.interactable = false;
            priceText.color = Color.red;
        }
    }

    public abstract void SaveProgress();

    public abstract void LoadProgress();

    public abstract void Buy();

    public abstract void updateText();
}
