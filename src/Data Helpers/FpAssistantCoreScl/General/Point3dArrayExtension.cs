// Decompiled with JetBrains decompiler
// Type: ArincReader.General.Point3dArrayExtension
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.Geographical;
using System;

namespace ArincReader.General
{
    public static class Point3dArrayExtension
    {
        public static Point3d[] GetRotated2DByDegrees(
          this Point3d[] points3dArray,
          double degrees)
        {
            Point3d[] points3dArray1 = (Point3d[])points3dArray.Clone();
            points3dArray1.Rotate2DByDegrees(degrees);
            return points3dArray1;
        }

        public static void Rotate2DByDegrees(this Point3d[] points3dArray, double degrees)
        {
            if (points3dArray == null)
                throw new ArgumentNullException(nameof(points3dArray));
            int num = 0;
            foreach (Point3d points3d in points3dArray)
                points3dArray[num++] = points3d.Rotate2DByDegrees(degrees);
        }

        public static Point3d[] GetTranslated(
          this Point3d[] points3dArray,
          double deltaX,
          double deltaY)
        {
            Point3d[] points3dArray1 = points3dArray != null ? (Point3d[])points3dArray.Clone() : throw new ArgumentNullException(nameof(points3dArray));
            points3dArray1.Translate(deltaX, deltaY);
            return points3dArray1;
        }

        public static void Translate(this Point3d[] points3dArray, double deltaX, double deltaY)
        {
            if (points3dArray == null)
                throw new ArgumentNullException(nameof(points3dArray));
            int num = 0;
            foreach (Point3d points3d in points3dArray)
                points3dArray[num++] = points3d.GetTranslated(deltaX, deltaY);
        }

        //TODO Check this if issues as I had to change a few things.
        //    public static void ZAddition(this Point3d[] points3dArray, double zAddition)
        //{
        //  if (points3dArray == null)
        //    throw new ArgumentNullException(nameof (points3dArray));
        //  int num = 0;
        //  foreach (Point3d points3d in points3dArray)
        //  {
        //    ref Point3d local = ref points3d;
        //    points3dArray[num++].Z += zAddition;
        //  }
        //}

        public static void ZAddition(this Point3d[] points3dArray, double zAddition)
        {
            if (points3dArray == null)
                throw new ArgumentNullException(nameof(points3dArray));
            int num = 0;
            foreach (Point3d points3d in points3dArray)
            {
                Point3d local = points3d;
                points3dArray[num++].Z += zAddition;
            }
        }

        public static GeoCoordinateElevationCollection AsGeoCoordinateElevationCollection(
          this Point3d[] points3dArray,
          string projectionZone,
          CoordinateSystem coordinateSystem)
        {
            GeoCoordinateElevationCollection elevationCollection = new GeoCoordinateElevationCollection();
            foreach (Point3d points3d in points3dArray)
            {
                GeoCoordinate coordinate = new GeoCoordinate(points3d.X, points3d.Y, projectionZone);
                elevationCollection.Add(new GeoCoordinateElevation(coordinate, new LinearDistance(points3d.Z, coordinateSystem.CoordinateSystemUnit)));
            }
            return elevationCollection;
        }
    }
}
