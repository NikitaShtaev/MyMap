using System;
using System.Collections;

namespace MyMap.Model
{
    public class MyDic<TKey, TValue>:IEnumerable
    {
        private int Size;
        private Item<TKey, TValue>[] Items;
        public MyDic(int size = 100) 
        {
            Size = size;
            Items = new Item<TKey, TValue>[size];
        }
        public void Add(Item<TKey, TValue> item)
        {
            var hash = GetHash(item.Key);
            if (Items[hash]==null)
            {
                Items[hash] = item;
            }
            else
            {
                var placed = false;
                for (int i = hash; i < Size; i++)
                {
                    if(Items[i].Key.Equals(item.Key))
                    {
                        return;
                    }
                    if(Items[i]==null)
                    {
                        Items[i] = item;
                        placed = true;
                        break;
                    }
                }
                if (!placed)
                {
                    for (int i = 0; i < hash; i++)
                    {
                        if(Items[i].Key.Equals(item.Key))
                        {
                            return;
                        }
                        if (Items[i] == null)
                        {
                            Items[i] = item;
                            placed = true;
                            break;
                        }
                    }
                }
                if (!placed)
                {
                    //throw new Exception("Dictionary Full");
                    var NewSize = Size*2;
                    var NewItems = new Item<TKey, TValue>[NewSize];
                    for (int i = 0; i < Size; i++)
                    {
                        NewItems[i] = Items[i];
                    }
                    Size = NewSize;
                    Items = NewItems;
                }
            }

            
        }

         public void Remove(TKey key)
        {
            var hash = GetHash(key);
            if (Items[hash].Key.Equals(key))
            {
                Items[hash] = null;
            }
            else
            {
                var placed = false;
                for (int i = hash; i < Size; i++)
                {
                    if (Items[i] == null)
                    {
                        return;
                    }
                    if (Items[i].Key.Equals(key))
                    {
                        Items[hash] = null;
                        return;
                    }
                }
                if (!placed)
                {
                    for (int i = 0; i < hash; i++)
                    {
                        if (Items[i] == null)
                        {
                            return;
                        }
                        if (Items[i].Key.Equals(key))
                        {
                            Items[hash] = null;
                            return;
                        }
                    }
                }
            }
        }
        public TValue Search(TKey key)
        {
            var hash = GetHash(key);
            if (Items[hash] == null)
            {
                return default(TValue);
            }
            if (Items[hash].Key.Equals(key))
            {
                return Items[hash].Value;
            }
            else
            {
                var placed = false;
                for (int i = hash; i < Size; i++)
                {
                    if (Items[i] == null)
                    {
                        return default(TValue);
                    }
                    if (Items[i].Key.Equals(key))
                    {
                        return Items[hash].Value;
                    }
                }
                if (!placed)
                {
                    for (int i = 0; i < hash; i++)
                    {
                        if (Items[i] == null)
                        {
                            return default(TValue);
                        }
                        if (Items[i].Key.Equals(key))
                        {
                            return Items[hash].Value;
                        }
                    }
                }
            }
            return default(TValue);
        }
        private int GetHash(TKey key)
        {
            return key.GetHashCode() % Size;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var item in Items)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }
    }
}
