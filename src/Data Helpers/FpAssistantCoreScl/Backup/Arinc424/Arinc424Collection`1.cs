// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Arinc424Collection`1
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.Arinc424.Records;
using FpAssistantCore.General;
using FpAssistantCore.Geographical;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FpAssistantCore.Arinc424
{
  public class Arinc424Collection<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
  {
    private readonly List<T> _InnerList;

    public Arinc424Collection() => this._InnerList = new List<T>();

    public T this[int index]
    {
      get => this._InnerList[index];
      set => this._InnerList[index] = value;
    }

    public int Count => this._InnerList.Count;

    public bool IsReadOnly => false;

    public void Add(T item) => this._InnerList.Add(item);

    public void Clear() => this._InnerList.Clear();

    public bool Contains(T item) => throw new NotImplementedException();

    public void CopyTo(T[] array, int arrayIndex) => throw new NotImplementedException();

    public IEnumerator<T> GetEnumerator() => (IEnumerator<T>) this._InnerList.GetEnumerator();

    public int IndexOf(T item) => throw new NotImplementedException();

    public void Insert(int index, T item) => throw new NotImplementedException();

    public bool Remove(T item) => throw new NotImplementedException();

    public void RemoveAt(int index) => this._InnerList.RemoveAt(index);

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._InnerList.GetEnumerator();

    public void Remove(GeoCoordinateBasic centrePoint, LinearDistance radius)
    {
      for (int index = this._InnerList.Count - 1; index >= 0; --index)
      {
        if (this._InnerList[index] is BaseRecord inner && !inner.GeoFenceWithin(centrePoint, radius))
          this._InnerList.RemoveAt(index);
      }
    }
  }
}
