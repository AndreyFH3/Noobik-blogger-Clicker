using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using YG;
using System;

public class saveSystem : MonoBehaviour
{
    private int timer = 12;
    [SerializeField] private GameObject offlineEarnCanvas;
    [SerializeField] private TextMeshProUGUI offlineText;
    [SerializeField] private GameObject tutorialCanvas;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += loadData;
        YandexGame.GetDataEvent += onlineEarn;
        GameLogic.instance.oneSecondTimer += timerToSave;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= loadData;
        YandexGame.GetDataEvent -= onlineEarn;
        GameLogic.instance.oneSecondTimer -= timerToSave;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
            loadData();
    }

    private void timerToSave()
    {
        timer--;
        if(timer < 0)
        {
            timer = 10;
            SaveData();
        }
    }

    private void onlineEarn()
    {
        if (!YandexGame.savesData.isFirstTry) // если первая игра, то показывает канвас и адльше прерывает метод. Иначе выключает приветственный экран.
        {
            tutorialCanvas.SetActive(false);
        }
        else return;
        
        DateTime timeNow = DateTime.UtcNow;
        TimeSpan timePassed = new TimeSpan();
        string strTime = YandexGame.savesData.saveTime;
        if (strTime.Length <= 0) return;
        timePassed = timeNow.Subtract(DateTime.Parse(strTime));

        ulong earnedMoney = Bonus.TimeWarp((int)timePassed.TotalMinutes);
        if(earnedMoney <= 0) return ;
        offlineEarnCanvas.SetActive(true);//код офлайн заработка
        GameLogic.instance.AddMoney(earnedMoney);
        if (YandexGame.savesData.language == "ru")
            offlineText.text = $"Подписчиков добавилось, пока вы были офлайн {earnedMoney}";
        else 
            offlineText.text = $"Subscribers added while you were offline {earnedMoney}";
    }

    private static void SaveData()
    {
        YandexGame.savesData.isFirstTry = false;
        YandexGame.savesData.saveTime = DateTime.UtcNow.ToString();
        YandexGame.savesData.money = GameLogic.instance.money;
        YandexGame.savesData.moneyPerSecond = GameLogic.instance.moneyPerSecond;
        YandexGame.savesData.premiumMoney = GameLogic.instance.premiumMoney;
        YandexGame.savesData.oneClickCost = GameLogic.instance.oneClickCost;
        YandexGame.savesData.isSoundActive = AudioListener.volume == 1 ? true : false;
        YandexGame.SaveProgress();
    }

    private static void loadData()
    {
        GameLogic.instance.InvokeTranslate();
        GameLogic.instance.SetMoeny(YandexGame.savesData.money);
        GameLogic.instance.SetOneSecond(YandexGame.savesData.moneyPerSecond);
        GameLogic.instance.SetPremiumMoney(YandexGame.savesData.premiumMoney);
        GameLogic.instance.OneClickCostSet(YandexGame.savesData.oneClickCost);
        AudioListener.volume = YandexGame.savesData.isSoundActive ? 1 : 0;
    }
}
