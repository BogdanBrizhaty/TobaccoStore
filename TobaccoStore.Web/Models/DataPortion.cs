using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TobaccoStore.Web.Models
{
    public class DataPortion<T> where T:class
    {
        private int _count = 0;
        private IEnumerable<T> _items;
        public DataPortion(IEnumerable<T> items, int count)
        {
            this._count = count;
            this._items = items;
        }
        public IEnumerable<T> Items
        {
            get { return _items; }
        }
        public int Count
        {
            get { return _count; }
        }
    }
}