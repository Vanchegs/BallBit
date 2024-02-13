using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Internal.Codebase.Infrastructure;
using Internal.Codebase.Saves;
using YG;

namespace Internal.Codebase.UILogic.CounterLogic
{
    [RequireComponent(typeof(TMP_Text))]
    public class Counter : MonoBehaviour
    {
        private TMP_Text countText;

        private void Awake() => 
            GameEventBus.OnLoaded += Load;

        private void Start()
        {
            countText = GetComponent<TMP_Text>();
            countText.text = $"{YandexGame.savesData.dataForSave.Currency}";
        }

        private void OnEnable()
        {
            GameEventBus.OnSurpriseBalloonBit += CountRandomChange;
            GameEventBus.OnOrdinaryBalloonBit += CountIncrease;
            GameEventBus.OnWritingOffCount += WritingOffCount;
            GameEventBus.UpdateCountUI += UpdateUI;
        }

        private void OnDisable()
        {
            GameEventBus.OnSurpriseBalloonBit -= CountRandomChange;
            GameEventBus.OnOrdinaryBalloonBit -= CountIncrease;
            GameEventBus.OnWritingOffCount -= WritingOffCount;
            GameEventBus.UpdateCountUI -= UpdateUI;
        }

        private void OnDestroy() => 
            GameEventBus.OnLoaded -= Load;

        private void Load(DataForSave data) => 
            YandexGame.savesData.dataForSave.Currency = data.Currency;

        private void CountIncrease()
        {
            YandexGame.savesData.dataForSave.Currency++;
            
            UpdateUI();
            
            GameEventBus.OnWalletChange?.Invoke(YandexGame.savesData.dataForSave.Currency);

            if (YandexGame.savesData.dataForSave.Currency == 0)
                return;
            Saver.Self.SavesData.Currency = YandexGame.savesData.dataForSave.Currency;
            Saver.Self.Save();
        }

        private void CountRandomChange()
        {
            var changeNumber = Random.Range(-10, 10);
            
            YandexGame.savesData.dataForSave.Currency += changeNumber;
            
            if (YandexGame.savesData.dataForSave.Currency < 0) YandexGame.savesData.dataForSave.Currency = 0;
            UpdateUI();
            
            GameEventBus.OnWalletChange?.Invoke(YandexGame.savesData.dataForSave.Currency);
            
            Saver.Self.SavesData.Currency = YandexGame.savesData.dataForSave.Currency;
            Saver.Self.Save();
        }
        
        private void WritingOffCount(int productPrice)
        {
            YandexGame.savesData.dataForSave.Currency -= productPrice;
            UpdateUI();
        }

        private void UpdateUI() => 
            countText.text = $"{YandexGame.savesData.dataForSave.Currency}";
    }
}
    
