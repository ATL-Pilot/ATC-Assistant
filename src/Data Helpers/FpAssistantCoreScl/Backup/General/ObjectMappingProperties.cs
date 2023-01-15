// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.ObjectMappingProperties
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;
using System.Collections.Generic;

namespace FpAssistantCore.General
{
  public static class ObjectMappingProperties
  {
    private static Dictionary<string, MapObjectProperties> ObjectPropertiesTable;

    static ObjectMappingProperties() => ObjectMappingProperties.LoadData();

    private static void LoadData() => ObjectMappingProperties.ObjectPropertiesTable = new Dictionary<string, MapObjectProperties>()
    {
      {
        "BasicIlsSurfaces",
        new MapObjectProperties()
        {
          Name = "BasicIlsSurfaces",
          StrokeColour = new FpaColour(FpaColour.KnownColours.Cyan),
          StrokeThickness = 2,
          FillColour = new FpaColour((byte) 25, FpaColour.KnownColours.Cyan)
        }
      },
      {
        "AerodromeObstacleSurfaces",
        new MapObjectProperties()
        {
          Name = "AerodromeObstacleSurfaces",
          StrokeColour = new FpaColour(FpaColour.KnownColours.Green),
          StrokeThickness = 2,
          FillColour = new FpaColour((byte) 25, FpaColour.KnownColours.Green)
        }
      }
    };

    public static MapObjectProperties GetProperties(string name)
    {
      if (string.IsNullOrWhiteSpace(name))
        throw new FormatException(ConstantMessages.ForExceptions.IsNullOrWhiteSpace);
      return ObjectMappingProperties.ObjectPropertiesTable.ContainsKey(name) ? ObjectMappingProperties.ObjectPropertiesTable[name] : (MapObjectProperties) null;
    }
  }
}
