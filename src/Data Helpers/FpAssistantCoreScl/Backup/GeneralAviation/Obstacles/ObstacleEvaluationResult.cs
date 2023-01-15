// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.Obstacles.ObstacleEvaluationResult
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;

namespace FpAssistantCore.GeneralAviation.Obstacles
{
  public struct ObstacleEvaluationResult
  {
    public ObstacleEvaluationResult(
      bool obstacleIntersectsFacet,
      Obstacle obstacle,
      Facet facet,
      LinearDistance contactHeightOnFacet,
      Point3d contactPoint)
    {
      this.ObstacleIntersectsFacet = obstacleIntersectsFacet;
      this.ObstacleUsed = obstacle;
      this.FacetUsed = facet;
      this.ContactHeightOnFacet = contactHeightOnFacet;
      this.ContactPoint = contactPoint;
    }

    public Obstacle ObstacleUsed { get; private set; }

    public Facet FacetUsed { get; private set; }

    public LinearDistance ContactHeightOnFacet { get; private set; }

    public Point3d ContactPoint { get; private set; }

    public bool ObstacleIntersectsFacet { get; private set; }
  }
}
