using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        public List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

        protected T GetItem() 
        {
            if (pooledItems.Count > 0) 
            {
                PooledItem<T> pooledItem = pooledItems.Find(item => !item.isUsed);
                if (pooledItem != null) 
                {
                    pooledItem.isUsed = true;
                    return pooledItem.item;
                }
            }
            return CreateNewPooledItem();
        }

        private T CreateNewPooledItem() 
        {
            PooledItem<T> pooledItem = new PooledItem<T>();
            pooledItem.item = CreateItem();
            pooledItem.isUsed = true;
            pooledItems.Add(pooledItem);

            return pooledItem.item;
        }

        protected virtual T CreateItem() 
        {
            throw new NotImplementedException(" CreateItem function not implemented in the base class");
        }
        public class PooledItem<T> 
        {
            public T item;
            public bool isUsed;
        }
    }
}
