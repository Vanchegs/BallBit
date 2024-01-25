using System;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Codebase.BalloonLogic.BalloonCreateLogic
{
    public class BalloonPool<T> where T : MonoBehaviour
    {
        private T ballPrefab;
        private Transform ballPoolContainer;
        private bool autoExpand;

        private List<T> circlePool = new();

        public BalloonPool(T prefab, Transform container, int poolSize, bool autoExpand)
        {
            if (prefab == null)
                throw new NullReferenceException(nameof(prefab));

            ballPrefab = prefab;

            if (container == null)
                throw new NullReferenceException(nameof(container));

            ballPoolContainer = container;

            this.autoExpand = autoExpand;

            InitPool(poolSize);
        }

        private void InitPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
                CreateNewObject(false);
        }

        private T CreateNewObject(bool isActiveByDefault)
        {
            T newObject = GameObject.Instantiate(ballPrefab, ballPoolContainer);
            
            newObject.gameObject.SetActive(isActiveByDefault);
            
            circlePool.Add(newObject);

            return newObject;
        }
        
        public void ReturnToPool(T target)
        {
            if (target != null)
            {
                target.gameObject.SetActive(false);
                target.transform.position = ballPoolContainer.position;
            }
        }

        public bool TryGetFree(out T element)
        {
            for (int i = 0; i < circlePool.Count; i++)
            {
                if (!circlePool[i].gameObject.activeInHierarchy)
                {
                    element = circlePool[i];
                    return true;
                }
            }

            element = null;
            return false;
        }

        public void DisableAll()
        {
            foreach (var gameObject in circlePool)
                gameObject.gameObject.SetActive(false);
        }

        public T GetFree()
        {
            if (TryGetFree(out T element))
            {
                element.gameObject.SetActive(true);
                return element;
            }

            if (autoExpand)
                return CreateNewObject(true);

            throw new Exception("There is no free element in pool");
        }
    }
}
