// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.Obstacles.BulkObstacleEvaluation
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.Geographical;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FpAssistantCore.GeneralAviation.Obstacles
{
  public class BulkObstacleEvaluation
  {
    public ObstacleEvaluationResultCollection Evaluate(
      ObstacleCollection obstacles,
      FacetCollection facets,
      CoordinateSystem coordinateSystem,
      string projectionZoneIdentifier,
      bool parallel)
    {
      ObstacleEvaluationResultCollection obstacleEvaluationResults = new ObstacleEvaluationResultCollection();
      if (parallel)
      {
        Task[] taskArray = new Task[obstacles.Count];
        for (int index = 0; index < obstacles.Count; ++index)
        {
          int taskI = index;
          taskArray[taskI] = Task.Run((Action) (() => obstacles[taskI].AssignGridCoordinate(coordinateSystem, projectionZoneIdentifier)));
        }
        Task.WaitAll(taskArray);
        foreach (Facet facet1 in (Collection<Facet>) facets)
        {
          Facet facet = facet1;
          Parallel.ForEach<Obstacle>((IEnumerable<Obstacle>) obstacles, (Action<Obstacle>) (obstacle => obstacleEvaluationResults.Add(new ObstacleEvaluation().Evaluate(obstacle, facet, coordinateSystem))));
        }
      }
      else
      {
        obstacles.AssignGridCoordinate(coordinateSystem, projectionZoneIdentifier);
        ObstacleEvaluation obstacleEvaluation = new ObstacleEvaluation();
        foreach (Facet facet in (Collection<Facet>) facets)
        {
          foreach (Obstacle obstacle in (Collection<Obstacle>) obstacles)
          {
            ObstacleEvaluationResult evaluationResult = obstacleEvaluation.Evaluate(obstacle, facet, coordinateSystem);
            obstacleEvaluationResults.Add(evaluationResult);
          }
        }
      }
      return obstacleEvaluationResults;
    }
  }
}
