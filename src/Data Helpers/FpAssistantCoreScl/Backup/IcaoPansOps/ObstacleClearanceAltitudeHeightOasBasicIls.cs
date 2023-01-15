// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.IcaoPansOps.ObstacleClearanceAltitudeHeightOasBasicIls
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.GeneralAviation;
using System;

namespace FpAssistantCore.IcaoPansOps
{
  public class ObstacleClearanceAltitudeHeightOasBasicIls : BaseObjectPansOps
  {
    private LinearDistance _HeightOfEquivalentApproachObstacleCatA_D;
    private LinearDistance _HeightOfEquivalentApproachObstacleCatH;
    private LinearDistance _HeightOfMissedApproachObstacle;
    private Angle _AngleOfGlidePath;
    private Angle _AngleOfMissedApproachSurface;
    private LinearDistance _RangeOfObstacleRelativeToThreshold;

    public ObstacleClearanceAltitudeHeightOasBasicIls(CriteriaUnits pansOpsUnit)
      : base(pansOpsUnit)
    {
      this._HeightOfMissedApproachObstacle = new LinearDistance(100.0, LinearDistanceUnits.Metres);
      this._AngleOfGlidePath = new Angle(15.0);
      this._AngleOfMissedApproachSurface = new Angle(5.0);
      this._RangeOfObstacleRelativeToThreshold = new LinearDistance(-5000.0, LinearDistanceUnits.Metres);
    }

    public LinearDistance HeightOfEquivalentApproachObstacleCatA2D => this._HeightOfEquivalentApproachObstacleCatA_D;

    public LinearDistance HeightOfEquivalentApproachObstacleCatH => this._HeightOfEquivalentApproachObstacleCatH;

    public LinearDistance HeightOfMissedApproachObstacle
    {
      get => this._HeightOfMissedApproachObstacle;
      set
      {
        this._HeightOfMissedApproachObstacle = value;
        this.CalculateHeightOfEquivalentApproachObstacle();
      }
    }

    public Angle AngleOfGlidePath
    {
      get => this._AngleOfGlidePath;
      set
      {
        this._AngleOfGlidePath = value;
        this.CalculateHeightOfEquivalentApproachObstacle();
      }
    }

    public Angle AngleOfMissedApproachSurface
    {
      get => this._AngleOfMissedApproachSurface;
      set
      {
        this._AngleOfMissedApproachSurface = value;
        this.CalculateHeightOfEquivalentApproachObstacle();
      }
    }

    public LinearDistance RangeOfObstacleRelativeToThreshold
    {
      get => this._RangeOfObstacleRelativeToThreshold;
      set
      {
        this._RangeOfObstacleRelativeToThreshold = value;
        this.CalculateHeightOfEquivalentApproachObstacle();
      }
    }

    private void CalculateHeightOfEquivalentApproachObstacle()
    {
      if (this._AngleOfGlidePath.AsDegrees() <= 0.0)
        throw new ArgumentException(string.Format("{0} Angle of Glide Path can't be less than or equal to zero", (object) this._AngleOfGlidePath), "AngleOfGlidePath");
      if (this._AngleOfMissedApproachSurface.AsDegrees() <= 0.0)
        throw new ArgumentException(string.Format("{0} Angle Of Missed Approach Surface can't be less than or equal to zero", (object) this._AngleOfMissedApproachSurface), "AngleOfMissedApproachSurface");
      LinearDistance linearDistance1 = this._HeightOfMissedApproachObstacle * Cot(this._AngleOfMissedApproachSurface.AsRadians()) + (ObstacleClearanceAltitudeHeightOasBasicIls.IcaoValues.DistanceThresholdToOriginZSurfaceCatAD + this._RangeOfObstacleRelativeToThreshold);
      double num = Cot(this._AngleOfMissedApproachSurface.AsRadians()) + Cot(this._AngleOfGlidePath.AsRadians());
      this._HeightOfEquivalentApproachObstacleCatA_D = new LinearDistance(linearDistance1.Value / num, linearDistance1.ValueUnit);
      LinearDistance linearDistance2 = this._HeightOfMissedApproachObstacle * Cot(this._AngleOfMissedApproachSurface.AsRadians()) + (ObstacleClearanceAltitudeHeightOasBasicIls.IcaoValues.DistanceThresholdToOriginZSurfaceCatH + this._RangeOfObstacleRelativeToThreshold);
      this._HeightOfEquivalentApproachObstacleCatH = new LinearDistance(linearDistance2.Value / num, linearDistance2.ValueUnit);

      static double Cot(double x) => Math.Cos(x) / Math.Sin(x);
    }

    public static class IcaoValues
    {
      public static readonly LinearDistance DistanceThresholdToOriginZSurfaceCatAD = new LinearDistance(900.0, LinearDistanceUnits.Metres);
      public static readonly LinearDistance DistanceThresholdToOriginZSurfaceCatH = new LinearDistance(700.0, LinearDistanceUnits.Metres);
    }
  }
}
