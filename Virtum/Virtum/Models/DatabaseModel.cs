using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;
using Virtum.Database;

namespace Virtum.Models
{
    public abstract class DatabaseModel<T>
    {
        private static LiteCollection<T> _collection;
        public static LiteCollection<T> Collection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = Db.Instance.GetCollection<T>() as LiteCollection<T>;
                }
                return _collection;
            }
        }

        public static void Insert(T element)
        {
            Collection.Insert(element);
        }

        public static void Save(T element)
        {
            Collection.Update(element);
        }

        public static IEnumerable<T> Read()
        {
            return Collection.FindAll();
        }
    }
}
