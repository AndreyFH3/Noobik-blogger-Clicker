
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";

        public bool isFirstTry = true;
        // Ваши сохранения
        public ulong money;
        public ulong moneyPerSecond;
        public int premiumMoney;
        public int oneClickCost = 1;

        public int [] upgradeClick = new int[10];
        public int [] upgradeSeconds = new int[10];
        public string saveTime = "";

        public bool isSoundActive = true;
    }

}
