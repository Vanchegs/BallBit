using System;
using UnityEngine;

namespace Internal.Codebase.Common
{
    [DisallowMultipleComponent]
    public class ImmortalGo : MonoBehaviour
    {
        [SerializeField] private bool setParentNull = true;
        [SerializeField] private IncludeImmortalGameObject includeImmortalGameObject = IncludeImmortalGameObject.Awake;

        private void Awake()
        {
            if (includeImmortalGameObject != IncludeImmortalGameObject.Awake)
                return;

            ApplyDontDestroyOnLoad();
        }

        private void Start()
        {
            if (includeImmortalGameObject != IncludeImmortalGameObject.Start)
                return;

            ApplyDontDestroyOnLoad();
        }

        private void ApplyDontDestroyOnLoad()
        {
            if (setParentNull)
                transform.SetParent(null);

            DontDestroyOnLoad(gameObject);
        }

        [Serializable]
        public enum IncludeImmortalGameObject : byte
        {
            Awake = 0,
            Start = 1,
        }
    }
}
