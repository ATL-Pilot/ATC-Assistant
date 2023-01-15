// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.GeoMapEngineElement
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;

namespace ArincReader.Geographical
{
    public class GeoMapEngineElement
    {
        private Guid _Guid = Guid.Empty;
        private object _EngineObject;

        public Guid UniqueId
        {
            get => this._Guid;
            set => this._Guid = value;
        }

        public object EngineObject
        {
            get => this._EngineObject;
            set => this._EngineObject = value;
        }
    }
}
