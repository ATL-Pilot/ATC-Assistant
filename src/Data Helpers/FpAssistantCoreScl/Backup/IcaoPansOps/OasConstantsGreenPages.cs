// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.IcaoPansOps.OasConstantsGreenPages
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.GeneralAviation;
using System;
using System.Collections.Generic;

namespace FpAssistantCore.IcaoPansOps
{
  public class OasConstantsGreenPages : BaseObjectPansOps
  {
    private OasConstantsGreenPagesGlidePathAngles _GlidePathAngle;
    private OasConstantsGreenPagesThreasholdDistances _ThreasholdDistance;
    private OasConstantsAircraftCategories _OasConstants_AircraftCategories;
    private OasConstantsMissedApproachSlopes _OasConstantsMissedApproachSlope;
    private double _WSurfaceA;
    private double _WSurfaceC;
    private double _XSurfaceA;
    private double _XSurfaceB;
    private double _XSurfaceC;
    private double _YSurfaceA;
    private double _YSurfaceB;
    private double _YSurfaceC;
    private double _ZSurfaceA;
    private double _ZSurfaceB;
    private double _ZSurfaceC;
    private readonly Dictionary<string, List<double>> OASConstantsGreenPagesTable;

    public OasConstantsGreenPages(CriteriaUnits pansOpsUnit)
    {
      // ISSUE: The method is too long to display (54919 instructions)
    }

    public OasConstantsGreenPagesGlidePathAngles GlidePathAngle
    {
      get => this._GlidePathAngle;
      set
      {
        this._GlidePathAngle = value;
        this.ObtainConstants();
      }
    }

    public OasConstantsGreenPagesThreasholdDistances ThreasholdDistance
    {
      get => this._ThreasholdDistance;
      set
      {
        this._ThreasholdDistance = value;
        this.ObtainConstants();
      }
    }

    public OasConstantsAircraftCategories AircraftCategory
    {
      get => this._OasConstants_AircraftCategories;
      set
      {
        this._OasConstants_AircraftCategories = value;
        this.ObtainConstants();
      }
    }

    public OasConstantsMissedApproachSlopes MissedApproachSlopePercentage
    {
      get => this._OasConstantsMissedApproachSlope;
      set
      {
        this._OasConstantsMissedApproachSlope = value;
        this.ObtainConstants();
      }
    }

    public double WSurfaceA => this._WSurfaceA;

    public double WSurfaceC => this._WSurfaceC;

    public double XSurfaceA => this._XSurfaceA;

    public double XSurfaceB => this._XSurfaceB;

    public double XSurfaceC => this._XSurfaceC;

    public double YSurfaceA => this._YSurfaceA;

    public double YSurfaceB => this._YSurfaceB;

    public double YSurfaceC => this._YSurfaceC;

    public double ZSurfaceA => this._ZSurfaceA;

    public double ZSurfaceB => this._ZSurfaceB;

    public double ZSurfaceC => this._ZSurfaceC;

    private void ObtainConstants()
    {
      int index = 0;
      int num = 2;
      int yRowIndex = -1;
      string key = this.GetGPAKey() + "_" + this.GetThrDistanceKey();
      if (!this.OASConstantsGreenPagesTable.ContainsKey(key))
        return;
      List<double> doubleList = this.OASConstantsGreenPagesTable[key];
      switch (this._OasConstants_AircraftCategories)
      {
        case OasConstantsAircraftCategories.CATI:
          index = 0;
          break;
        case OasConstantsAircraftCategories.CATII:
          index = 3;
          break;
        case OasConstantsAircraftCategories.CATIIAutopilot:
          index = 6;
          break;
      }
      AssignConstantsByMASlopePercentage();
      this._WSurfaceA = doubleList[index];
      this._WSurfaceC = doubleList[index + 2];
      this._XSurfaceA = doubleList[index + num * 9];
      this._XSurfaceB = doubleList[index + 1 + num * 9];
      this._XSurfaceC = doubleList[index + 2 + num * 9];
      this._YSurfaceA = doubleList[index + yRowIndex * 9];
      this._YSurfaceB = doubleList[index + 1 + yRowIndex * 9];
      this._YSurfaceC = doubleList[index + 2 + yRowIndex * 9];
      yRowIndex++;
      this._ZSurfaceA = doubleList[index + yRowIndex * 9];
      this._ZSurfaceB = doubleList[index + 1 + yRowIndex * 9];
      this._ZSurfaceC = doubleList[index + 2 + yRowIndex * 9];

      void AssignConstantsByMASlopePercentage()
      {
        switch (this._OasConstantsMissedApproachSlope)
        {
          case OasConstantsMissedApproachSlopes.Percentage2point0:
            yRowIndex = 11;
            break;
          case OasConstantsMissedApproachSlopes.Percentage2point5:
            yRowIndex = 9;
            break;
          case OasConstantsMissedApproachSlopes.Percentage3point0:
            yRowIndex = 7;
            break;
          case OasConstantsMissedApproachSlopes.Percentage4point0:
            yRowIndex = 5;
            break;
          case OasConstantsMissedApproachSlopes.Percentage5point0:
            yRowIndex = 3;
            break;
        }
      }
    }

    private string GetGPAKey()
    {
      switch (this._GlidePathAngle)
      {
        case OasConstantsGreenPagesGlidePathAngles.GPA25:
          return "2.5";
        case OasConstantsGreenPagesGlidePathAngles.GPA26:
          return "2.6";
        case OasConstantsGreenPagesGlidePathAngles.GPA27:
          return "2.7";
        case OasConstantsGreenPagesGlidePathAngles.GPA28:
          return "2.8";
        case OasConstantsGreenPagesGlidePathAngles.GPA29:
          return "2.9";
        case OasConstantsGreenPagesGlidePathAngles.GPA30:
          return "3.0";
        case OasConstantsGreenPagesGlidePathAngles.GPA31:
          return "3.1";
        case OasConstantsGreenPagesGlidePathAngles.GPA32:
          return "3.2";
        case OasConstantsGreenPagesGlidePathAngles.GPA33:
          return "3.3";
        case OasConstantsGreenPagesGlidePathAngles.GPA34:
          return "3.4";
        case OasConstantsGreenPagesGlidePathAngles.GPA35:
          return "3.5";
        default:
          throw new Exception("Invalid enum key value");
      }
    }

    private string GetThrDistanceKey()
    {
      switch (this._ThreasholdDistance)
      {
        case OasConstantsGreenPagesThreasholdDistances.Si2000Metres:
          return "2000";
        case OasConstantsGreenPagesThreasholdDistances.Si2200Metres:
          return "2200";
        case OasConstantsGreenPagesThreasholdDistances.Si2400Metres:
          return "2400";
        case OasConstantsGreenPagesThreasholdDistances.Si2600Metres:
          return "2600";
        case OasConstantsGreenPagesThreasholdDistances.Si2800Metres:
          return "2800";
        case OasConstantsGreenPagesThreasholdDistances.Si3000Metres:
          return "3000";
        case OasConstantsGreenPagesThreasholdDistances.Si3200Metres:
          return "3200";
        case OasConstantsGreenPagesThreasholdDistances.Si3400Metres:
          return "3400";
        case OasConstantsGreenPagesThreasholdDistances.Si3600Metres:
          return "3600";
        case OasConstantsGreenPagesThreasholdDistances.Si3800Metres:
          return "3800";
        case OasConstantsGreenPagesThreasholdDistances.Si4000Metres:
          return "4000";
        case OasConstantsGreenPagesThreasholdDistances.Si4200Metres:
          return "4200";
        case OasConstantsGreenPagesThreasholdDistances.Si4400Metres:
          return "4400";
        case OasConstantsGreenPagesThreasholdDistances.Si4500Metres:
          return "4500";
        default:
          throw new Exception("Invalid distance key enum value");
      }
    }
  }
}
