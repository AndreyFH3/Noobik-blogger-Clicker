using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance { 
        get { 
            if (_instance == null)
            {
                var go = new GameObject("GameLogicHelper");
                _instance = go.AddComponent<GameLogic>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        } 
    }
    private static GameLogic _instance;

    private ulong _money;
    public ulong money => _money;

    private ulong _moneyPerSecond = 0;
    public ulong moneyPerSecond => _moneyPerSecond;


    private int _preimeumMoney;
    public int premiumMoney => _preimeumMoney;

    private int _oneClickCost = 1;
    public int oneClickCost => _oneClickCost;

    private int _bonus = 1;
    public int bonus => _bonus; 

    public void AddMoney(ulong value) => _money += value;

    public void RemoveMoney(ulong value) => _money -= value;
    
    public void SetMoeny(ulong value) => _money = value;
    
    public void SetPremiumMoney(int value) => _preimeumMoney = value;
    
    public void AddPremiumMoney(int value) => _preimeumMoney += value;
    
    public void RemovePremiumMoney(int value) => _preimeumMoney -= value; 
    
    public void OneClickCostAdd(int value) => _oneClickCost += value;
                
    public void OneClickCostSet(int value) => _oneClickCost = value;

    public void SetOneSecond(ulong value) => _moneyPerSecond = value;

    public void AddOneSecond(int value) => _moneyPerSecond += (ulong)value;

    public void SetBonus(int value) => _bonus = value;

    private float _timer = 0;

    public event Action oneSecondTimer;
    public event Action everyFrameEvent;
    public event Action translateUI;

    private void OnEnable()
    {
        oneSecondTimer += eventMoneyAdd;
    }


    private void OnDisable()
    {
        oneSecondTimer -= eventMoneyAdd;
        Destroy(gameObject);
    }

    private void Update()
    {
        
        float deltaTime = Time.deltaTime;
        _timer += deltaTime;
        if(_timer >= 1)
        {
            _timer -= 1;
            oneSecondTimer?.Invoke();
        }
        translateUI.Invoke();
        everyFrameEvent?.Invoke();
    }

    public void InvokeTranslate() => translateUI.Invoke();

    private void eventMoneyAdd() => AddMoney(_moneyPerSecond);
}
