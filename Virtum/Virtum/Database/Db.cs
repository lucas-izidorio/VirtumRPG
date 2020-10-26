using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;
using Xamarin.Forms;

namespace Virtum.Database
{
    public sealed class Db
    {
        private static LiteDatabase _db;
        public static LiteDatabase Instance
        {
            get
            {
                if (_db == null)
                {
                    _db = new LiteDatabase(DependencyService.Get<IHelper>().GetFilePath("Banco.db"));
                }
                return _db;
            }
        }
    }
}
