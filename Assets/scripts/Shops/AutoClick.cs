using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class AutoClick : BuysBase
{
    [Header("AutoCickBuy Script")]
    [SerializeField] private int id;
    [SerializeField] private int _addPeroneSecond;
    public override void Buy()
    {
        GameLogic.instance.AddOneSecond(_addPeroneSecond);
        GameLogic.instance.RemoveMoney(priceUsual);
        buysAmount++;
        updateText();
    }

    public override void SaveProgress()
    {
        if(YandexGame.SDKEnabled)
            YandexGame.savesData.upgradeSeconds[id] = buysAmount;
    }

    public override void LoadProgress()
    {
        buysAmount = YandexGame.savesData.upgradeSeconds[id];
    }

    public override void updateText()
    {
        if (YandexGame.savesData.language == "ru")
        {
            string str = isBuyUsualMoney ? $"{priceUsual} подписчиков" : $"{_premiumPrice} золота";
            priceText.text = str;
            AmountBuys.text = $"{buysAmount} куплено";
            bonusText.text = $"+{_addPeroneSecond} подписчиков в секунду";
        }
        else
        {
            string str = isBuyUsualMoney ? $"{priceUsual} subscribers" : $"{_premiumPrice} gold";
            priceText.text = str;
            AmountBuys.text = $"{buysAmount} bought";
            bonusText.text = $"+{_addPeroneSecond} subscribers per second";
        }
    }
}
