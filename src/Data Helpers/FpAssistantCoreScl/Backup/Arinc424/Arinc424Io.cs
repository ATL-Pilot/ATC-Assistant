// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Arinc424Io
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.Arinc424.Records;
using FpAssistantCore.Arinc424.Serialization;
using System;
using System.IO;

namespace FpAssistantCore.Arinc424
{
  public class Arinc424Io
  {
    private Arinc424Data _Arinc424Data = new Arinc424Data();

    public Arinc424Data Arinc424Data
    {
      get => this._Arinc424Data;
      set => this._Arinc424Data = value;
    }

    public bool Open(string filename)
    {
      try
      {
        using (StreamReader streamReader = new StreamReader(filename))
          return this.LoadStream(streamReader);
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public bool Open(Stream stream)
    {
      try
      {
        using (StreamReader streamReader = new StreamReader(stream))
          return this.LoadStream(streamReader);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private bool LoadStream(StreamReader streamReader)
    {
      try
      {
        this.Arinc424Data = new Arinc424AsciiDeserializer().Deserialize(streamReader, ref this._Arinc424Data);
        streamReader.Close();
        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public bool Clear()
    {
      try
      {
        this._Arinc424Data.Clear();
        this._Arinc424Data.AddRecord((BaseRecord) new Header1());
        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
