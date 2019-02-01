using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EJuiceMaker.Data
{
    internal class BindingListEx<TItem> : BindingList<TItem>
    {
        public BindingListEx(IList<TItem> list) : base(list) { } 

        public BindingListEx() : base() { }

        public void AddAll(IEnumerable<TItem> items)
        {
            RaiseListChangedEvents = false;
            foreach (var item in items) Add(item);
            RaiseListChangedEvents = true;
            ResetBindings();
        }

        protected override void SetItem(int index, TItem item)
        {
            var oldItem = this[index];
            ItemChanging?.Invoke(this, new ItemChangingEventArgs<TItem>(index, oldItem, item));
            base.SetItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            ItemDeleting?.Invoke(this, new ItemDeletingEventArgs<TItem>(index, item));
            base.RemoveItem(index);
        }

        public event EventHandler<ItemChangingEventArgs<TItem>> ItemChanging; 

        public event EventHandler<ItemDeletingEventArgs<TItem>> ItemDeleting;
    }

    internal class ItemChangingEventArgs<TItem> : EventArgs
    {
        public ItemChangingEventArgs(int index, TItem oldValue, TItem newValue)
        {
            Index = index;
            OldItem = oldValue;
            NewItem = newValue;
        }

        public int Index { get; }
        public TItem OldItem { get; }
        public TItem NewItem { get; }
    }

    internal class ItemDeletingEventArgs<TItem> : EventArgs
    {
        public ItemDeletingEventArgs(int index, TItem item)
        {
            Index = index;
            Item = item;
        }

        public int Index { get; }
        public TItem Item { get; }
    }
}
