//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Copyright (c) 2007-2008
// Available under the terms of the
// Eclipse Public License with GPL exception
// See enclosed license file for more information
namespace PhysX.NET
{
	using System;
	using System.Runtime.InteropServices;
	using System.Collections.Generic;
	using System.Collections;
	using System.Reflection;
	
	
	public class DoxyBindArray<T> : IList<T>
		where T : DoxyBindObject
	{
		

        protected IList<IntPtr> baselist;

        public DoxyBindArray(IntPtr[] list)
        {
            baselist = list;
        }

        public DoxyBindArray(IList<T> list)
        {
            baselist = new IntPtr[list.Count];
            for (int i = 0; i < list.Count; ++i)
                baselist[i] = list[i].ClassPointer.Handle;
        }

        public DoxyBindArray(params T[] list)
            : this((IList<T>)list)
        { }

        public static implicit operator IntPtr[] (DoxyBindArray<T> dba)
        {
            if(dba == null)
                return null;

            return (IntPtr[])dba.baselist;
        }

        public static implicit operator DoxyBindArray<T> (IntPtr[] list)
        {
            return new DoxyBindArray<T>(list);
        }

        #region IList<T> Members

        public int IndexOf(T item)
        {
            return baselist.IndexOf(item.ClassPointer.Handle);
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public T this[int index]
        {
            get {
                return
                    (T)typeof(T).InvokeMember("GetClass", BindingFlags.Static | BindingFlags.Public, null, null,
                                            new object[] { baselist[index] });
            }
            set { baselist[index] = value.ClassPointer.Handle; }
        }

        #endregion

        #region ICollection<T> Members

        public void Add(T item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(T item)
        {
            return baselist.Contains(item.ClassPointer.Handle);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < baselist.Count; ++i)
                array[arrayIndex + i] = this[i];
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        public int Count
        {
            get { return baselist.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        #endregion

        #region IEnumerable<T> Members

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<T>) this).GetEnumerator();
        }

        #endregion

        public class Enumerator<T> : IEnumerator<T> where T:DoxyBindObject
        {
            protected IEnumerator<IntPtr> baseenumerator;

            public Enumerator(DoxyBindArray<T> array)
            {
                baseenumerator = array.baselist.GetEnumerator();
            }

            #region IEnumerator<T> Members

            T IEnumerator<T>.Current
            {
                get
                {
                    return (T)typeof(T).InvokeMember("GetClass", BindingFlags.Static | BindingFlags.Public, null, null,
                                          new object[] { baseenumerator.Current });
                }
            }

            #endregion

            #region IDisposable Members

            public void Dispose()
            {
                baseenumerator.Dispose();
            }

            #endregion

            #region IEnumerator Members

            public bool MoveNext()
            {
                return baseenumerator.MoveNext();
            }

            public void Reset()
            {
                baseenumerator.Reset();
            }

            public object Current
            {
                get
                {
                    return ((IEnumerator<T>) this).Current;
                }
            }

            #endregion
        }
    
	}
}
