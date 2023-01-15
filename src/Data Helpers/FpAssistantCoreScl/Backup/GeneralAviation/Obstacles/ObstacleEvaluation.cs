// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.Obstacles.ObstacleEvaluation
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.Geographical;
using System;
using System.Runtime.InteropServices;

namespace FpAssistantCore.GeneralAviation.Obstacles
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct ObstacleEvaluation
  {
    public ObstacleEvaluationResult Evaluate(
      Obstacle obstacle,
      Facet facet,
      CoordinateSystem coordinateSystem)
    {
      ObstacleEvaluationResult evaluationResult = new ObstacleEvaluationResult();
      switch (obstacle)
      {
        case PointObstacle _:
          evaluationResult = this.EvaluatePointObstacle(obstacle as PointObstacle, facet, coordinateSystem);
          break;
        case LineObstacle _:
          throw new NotSupportedException();
        case PolygonObstacle _:
          throw new NotSupportedException();
      }
      return evaluationResult;
    }

    public Tuple<bool, Point3d> EvaluateXYPoint(Point2d point2d, Facet facet) => this.EvaluateXYPoint(new Point3d(point2d.X, point2d.Y, 0.0), facet);

    public Tuple<bool, Point3d> EvaluateXYPoint(Point3d point3d, Facet facet) => this.EvaluatePenetration(point3d, 999999.0, 0.0, facet);

    public Tuple<bool, Point3d> EvaluateXYPoint(
      Point2d point2d,
      double cylinderHeight,
      double cylinderRadius,
      Facet facet)
    {
      return this.EvaluatePenetration(new Point3d(point2d.X, point2d.Y, 0.0), cylinderHeight, cylinderRadius, facet);
    }

    public Tuple<bool, Point3d> EvaluateXYPoint(
      Point3d point3d,
      double cylinderHeight,
      double cylinderRadius,
      Facet facet)
    {
      return this.EvaluatePenetration(point3d, cylinderHeight, cylinderRadius, facet);
    }

    private Tuple<bool, Point3d> EvaluatePenetration(
      Point3d cylinderCenter,
      double cylinderHeight,
      double cylinderRadius,
      Facet facet)
    {
      Triangle3d[] triangle3dArray = facet.AsTriangles3d();
      bool flag = false;
      Point3d point3d = new Point3d();
      foreach (Triangle3d triangle in triangle3dArray)
      {
        Tuple<bool, Point3d> tuple = this.DoCylinderPenetrateTriangle(cylinderCenter, cylinderHeight, cylinderRadius, triangle);
        if (tuple.Item1)
        {
          if (!flag)
          {
            point3d = tuple.Item2;
            flag = true;
          }
          else if (tuple.Item2.Z < point3d.Z)
            point3d = tuple.Item2;
        }
      }
      if (cylinderHeight - point3d.Z < 1E-05)
        flag = false;
      return flag ? Tuple.Create<bool, Point3d>(true, point3d) : Tuple.Create<bool, Point3d>(false, new Point3d());
    }

    private Tuple<bool, Point3d> DoCylinderPenetrateTriangle(
      Point3d cylinderCenter,
      double cylinderHeight,
      double cylinderRadius,
      Triangle3d triangle)
    {
      Tuple<bool, Point3d> tuple = Tuple.Create<bool, Point3d>(false, new Point3d());
      if (triangle.Zmin >= cylinderHeight || Math.Abs(triangle.Normal.Z) < 1E-08 || cylinderCenter.X + cylinderRadius < triangle.Xmin || cylinderCenter.X - cylinderRadius > triangle.Xmax || cylinderCenter.Y + cylinderRadius < triangle.Ymin || cylinderCenter.Y - cylinderRadius > triangle.Ymax)
        return tuple;
      Point3d[] point3dArray = new Point3d[3]
      {
        triangle.Point1,
        triangle.Point2,
        triangle.Point3
      };
      bool flag = false;
      Point3d point3d1 = new Point3d();
      foreach (Point3d point3d2 in point3dArray)
      {
        if (point3d2.Distance2dTo(cylinderCenter) < cylinderRadius * 1.00001)
        {
          if (!flag || point3d2.Z < point3d1.Z)
            point3d1 = point3d2;
          flag = true;
        }
      }
      double[] planeAbc = triangle.GetPlaneABC();
      double num1 = Math.Abs(planeAbc[0]) > 1E-08 ? Math.Atan(planeAbc[1] / planeAbc[0]) : Math.PI / 2.0;
      double pointX1 = cylinderCenter.X + cylinderRadius * Math.Cos(num1);
      double pointY1 = cylinderCenter.Y + cylinderRadius * Math.Sin(num1);
      double pointX2 = cylinderCenter.X - cylinderRadius * Math.Cos(num1);
      double pointY2 = cylinderCenter.Y - cylinderRadius * Math.Sin(num1);
      double pointZ = planeAbc[0] * pointX1 + planeAbc[1] * pointY1 + planeAbc[2];
      double num2 = planeAbc[0] * pointX2 + planeAbc[1] * pointY2 + planeAbc[2];
      Point2d point = num2 < pointZ ? new Point2d(pointX2, pointY2) : new Point2d(pointX1, pointY1);
      if (num2 < pointZ)
        pointZ = num2;
      if (triangle.IsInsideOn2D(point))
      {
        if (!flag || pointZ < point3d1.Z)
          point3d1 = new Point3d(point.X, point.Y, pointZ);
        flag = true;
      }
      Point2d circleCenter = cylinderCenter.As2d();
      for (long index = 0; index < 3L; ++index)
      {
        double[] numArray = this.IntersectLineCircle2d(point3dArray[index].As2d(), point3dArray[(index + 1L) % 3L].As2d(), circleCenter, cylinderRadius);
        if (numArray.Length != 0)
        {
          foreach (double t01 in numArray)
          {
            if (t01 >= -1E-07 && t01 <= 1.0000001)
            {
              Point3d point3d3 = point3dArray[index].PointBetween(point3dArray[(index + 1L) % 3L], t01);
              double z = point3d3.Z;
              if (!flag || z < point3d1.Z)
                point3d1 = point3d3;
              flag = true;
            }
          }
        }
      }
      return Tuple.Create<bool, Point3d>(flag, point3d1);
    }

    private double[] IntersectLineCircle2d(
      Point2d lSrart,
      Point2d lEnd,
      Point2d circleCenter,
      double radius)
    {
      Vector3d vector3d = new Vector3d(lSrart.As3d(), lEnd.As3d());
      double magnitude = vector3d.Magnitude;
      vector3d.Normalize();
      double x1 = lSrart.X;
      double x2 = vector3d.X;
      double y1 = lSrart.Y;
      double y2 = vector3d.Y;
      double num1 = x1 - circleCenter.X;
      double y3 = circleCenter.Y;
      double num2 = y1 - y3;
      double num3 = 2.0 * (num1 * x2 + num2 * y2);
      double num4 = num1 * num1 + num2 * num2 - radius * radius;
      double d = num3 * num3 - 4.0 * num4;
      if (Math.Abs(d) < 1E-05)
        return new double[1]{ -num3 / 2.0 / magnitude };
      if (d < 0.0)
        return new double[0];
      double num5 = (-num3 + Math.Sqrt(d)) / 2.0;
      return new double[2]
      {
        (-num3 - Math.Sqrt(d)) / 2.0 / magnitude,
        num5 / magnitude
      };
    }

    private ObstacleEvaluationResult EvaluatePointObstacle(
      PointObstacle pointObstacle,
      Facet facet,
      CoordinateSystem coordinateSystem)
    {
      LinearDistance heightMsl = pointObstacle.HeightMsl;
      heightMsl = heightMsl.ConvertTo(coordinateSystem.CoordinateSystemUnit);
      double cylinderHeight = heightMsl.Value;
      LinearDistance radius = pointObstacle.Radius;
      radius = radius.ConvertTo(coordinateSystem.CoordinateSystemUnit);
      double cylinderRadius = radius.Value;
      Tuple<bool, Point3d> penetration = this.EvaluatePenetration(pointObstacle.CenterXY.XYCoordinate, cylinderHeight, cylinderRadius, facet);
      ObstacleEvaluationResult pointObstacle1 = new ObstacleEvaluationResult();
      pointObstacle1 = !penetration.Item1 ? new ObstacleEvaluationResult(false, (Obstacle) pointObstacle, facet, new LinearDistance(0.0, LinearDistanceUnits.Metres), new Point3d()) : new ObstacleEvaluationResult(true, (Obstacle) pointObstacle, facet, new LinearDistance(penetration.Item2.Z, coordinateSystem.CoordinateSystemUnit), penetration.Item2);
      return pointObstacle1;
    }

    private ObstacleEvaluationResult EvaluateLineObstacle(
      LineObstacle lineObstacle,
      Facet facet,
      CoordinateSystem coordinateSystem)
    {
      foreach (LineObstacleSegment lineSegment in lineObstacle.LineSegments)
      {
        GeoCoordinate startCoordinate = lineSegment.StartCoordinate;
        int mapProjection1 = (int) coordinateSystem.MapProjection;
        GeoCoordinate geoCoordinate = lineSegment.StartCoordinate;
        string projectionZoneIdentifier1 = geoCoordinate.ProjectionZoneDescription(coordinateSystem.MapProjection);
        GridCoordinate gridCoordinate1 = new GridCoordinate(startCoordinate, (MapProjections) mapProjection1, projectionZoneIdentifier1);
        GeoCoordinate endCoordinate = lineSegment.EndCoordinate;
        int mapProjection2 = (int) coordinateSystem.MapProjection;
        geoCoordinate = lineSegment.EndCoordinate;
        string projectionZoneIdentifier2 = geoCoordinate.ProjectionZoneDescription(coordinateSystem.MapProjection);
        GridCoordinate gridCoordinate2 = new GridCoordinate(endCoordinate, (MapProjections) mapProjection2, projectionZoneIdentifier2);
        LinearDistance heightMsl = lineSegment.HeightMsl;
      }
      return new ObstacleEvaluationResult();
    }
  }
}
