using UnityEngine;
using YG;

public class ClickBuy : BuysBase
{
    [Header("CickBuy Script")]
    [SerializeField] private int id;
    [SerializeField] private int _addClick;

    public override void SaveProgress()
    {
        if(YandexGame.SDKEnabled)
            YandexGame.savesData.upgradeClick[id] = buysAmount; 
    }

    public override void LoadProgress()
    {
        buysAmount = YandexGame.savesData.upgradeClick[id];
    }

    public override void Buy()
    {
        GameLogic.instance.OneClickCostAdd(_addClick);
        GameLogic.instance.RemoveMoney(priceUsual);
        buysAmount++;
        updateText();
    }

    public override void updateText()
    {
        if (YandexGame.savesData.language == "ru")
        {
            string str = isBuyUsualMoney ? $"{priceUsual} подписчиков" : $"{_premiumPrice} золота";
            priceText.text = str;
            AmountBuys.text = $"{buysAmount} куплено";
            bonusText.text = $"+{_addClick} подписчиков за клик";
        }
        else
        {
            string str = isBuyUsualMoney ? $"{priceUsual} subscribers" : $"{_premiumPrice} gold";
            priceText.text = str;
            AmountBuys.text = $"{buysAmount} bought";
            bonusText.text = $"+{_addClick} subscribers for click";
        }
    }
}
