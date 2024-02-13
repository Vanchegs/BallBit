using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Internal.Codebase.Infrastructure;
using Internal.Codebase.UILogic.StoreLogic;
using UnityEngine;
using YG;

namespace Internal.Codebase.Saves
{
    public class Saver : MonoBehaviour
    {
        public static Saver Self;
        
        [HideInInspector] public DataForSave SavesData;

        [field: SerializeField] public List<Item> shopItems { get; private set; } = new();

        [SerializeField] private int cooldown = 6;

        private Coroutine coroutine;

        private void Awake()
        {
            if (Self == null)
                Self = this;
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled)
                Load();

            YandexGame.GetDataEvent += Load;
        }

        public void Save()
        {
            YandexGame.savesData.dataForSave = SavesData;
            YandexGame.SaveProgress();
        }

        private void Load()
        {
            if (YandexGame.savesData != null)
            {
                if (YandexGame.savesData.dataForSave == null)
                    FillDataForSave();
            }
            else
            {
                YandexGame.savesData = new SavesYG();
                FillDataForSave();
            }
            
            Debug.Log("EFSDFSEF");
            GameEventBus.OnLoaded?.Invoke(YandexGame.savesData.dataForSave);
            
            SavesData = YandexGame.savesData.dataForSave;

            if (coroutine == null)
                coroutine = StartCoroutine(AutoSaver());
        }

        private void FillDataForSave()
        {
            YandexGame.savesData.dataForSave = new DataForSave();
            YandexGame.savesData.dataForSave.ItemsForSave = shopItems;
            YandexGame.savesData.dataForSave.ItemsForSave.ForEach(x => { x.IsBuy = false; });
        }

        private IEnumerator AutoSaver()
        {
            while (true)
            {
                yield return new WaitForSeconds(cooldown);

                if (YandexGame.savesData.dataForSave != null)
                    Save();
                else
                {
                    Load();
                    Save();
                }
            }
        }
    }
}