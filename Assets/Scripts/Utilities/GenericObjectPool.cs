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
                    return pooledItem.Item;
                }
            }
            return CreateNewPooledItem();
        }

        private T CreateNewPooledItem() 
        {
            PooledItem<T> pooledItem = new PooledItem<T>();
            pooledItem.Item = CreateItem();
            pooledItem.isUsed = true;
            pooledItems.Add(pooledItem);

            return pooledItem.Item;
        }

        protected virtual T CreateItem() 
        {
            throw new NotImplementedException(" CreateItem function not implemented in the base class");
        }

        public void Returnitem(T _item) 
        {
            PooledItem<T> pooledItem = pooledItems.Find(item => item.Item.Equals(_item));        
            pooledItem.isUsed = false;
        }
        public class PooledItem<T> 
        {
            public T Item;
            public bool isUsed;
        }
    }
}
