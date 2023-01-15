// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.Matrix3d
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;

namespace FpAssistantCore.General
{
  public struct Matrix3d : IEquatable<Matrix3d>
  {
    private double _m11;
    private double _m12;
    private double _m13;
    private double _m14;
    private double _m21;
    private double _m22;
    private double _m23;
    private double _m24;
    private double _m31;
    private double _m32;
    private double _m33;
    private double _m34;
    private double _offsetX;
    private double _offsetY;
    private double _offsetZ;
    private double _m44;
    private bool _isNotKnownToBeIdentity;
    private static Matrix3d s_identity = Matrix3d.CreateIdentity();
    private const int c_identityHashCode = 0;

    public Matrix3d(
      double m11,
      double m12,
      double m13,
      double m14,
      double m21,
      double m22,
      double m23,
      double m24,
      double m31,
      double m32,
      double m33,
      double m34,
      double offsetX,
      double offsetY,
      double offsetZ,
      double m44)
    {
      this._m11 = m11;
      this._m12 = m12;
      this._m13 = m13;
      this._m14 = m14;
      this._m21 = m21;
      this._m22 = m22;
      this._m23 = m23;
      this._m24 = m24;
      this._m31 = m31;
      this._m32 = m32;
      this._m33 = m33;
      this._m34 = m34;
      this._offsetX = offsetX;
      this._offsetY = offsetY;
      this._offsetZ = offsetZ;
      this._m44 = m44;
      this._isNotKnownToBeIdentity = true;
    }

    public double M11
    {
      get => this.IsDistinguishedIdentity ? 1.0 : this._m11;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m11 = value;
      }
    }

    public double M12
    {
      get => this._m12;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m12 = value;
      }
    }

    public double M13
    {
      get => this._m13;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m13 = value;
      }
    }

    public double M14
    {
      get => this._m14;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m14 = value;
      }
    }

    public double M21
    {
      get => this._m21;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m21 = value;
      }
    }

    public double M22
    {
      get => this.IsDistinguishedIdentity ? 1.0 : this._m22;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m22 = value;
      }
    }

    public double M23
    {
      get => this._m23;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m23 = value;
      }
    }

    public double M24
    {
      get => this._m24;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m24 = value;
      }
    }

    public double M31
    {
      get => this._m31;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m31 = value;
      }
    }

    public double M32
    {
      get => this._m32;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m32 = value;
      }
    }

    public double M33
    {
      get => this.IsDistinguishedIdentity ? 1.0 : this._m33;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m33 = value;
      }
    }

    public double M34
    {
      get => this._m34;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m34 = value;
      }
    }

    public double OffsetX
    {
      get => this._offsetX;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._offsetX = value;
      }
    }

    public double OffsetY
    {
      get => this._offsetY;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._offsetY = value;
      }
    }

    public double OffsetZ
    {
      get => this._offsetZ;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._offsetZ = value;
      }
    }

    public double M44
    {
      get => this.IsDistinguishedIdentity ? 1.0 : this._m44;
      set
      {
        if (this.IsDistinguishedIdentity)
        {
          this = Matrix3d.s_identity;
          this.IsDistinguishedIdentity = false;
        }
        this._m44 = value;
      }
    }

    public bool IsAffine
    {
      get
      {
        if (this.IsDistinguishedIdentity)
          return true;
        return this._m14 == 0.0 && this._m24 == 0.0 && this._m34 == 0.0 && this._m44 == 1.0;
      }
    }

    public bool IsIdentity
    {
      get
      {
        if (this.IsDistinguishedIdentity)
          return true;
        if (this._m11 != 1.0 || this._m12 != 0.0 || this._m13 != 0.0 || this._m14 != 0.0 || this._m21 != 0.0 || this._m22 != 1.0 || this._m23 != 0.0 || this._m24 != 0.0 || this._m31 != 0.0 || this._m32 != 0.0 || this._m33 != 1.0 || this._m34 != 0.0 || this._offsetX != 0.0 || this._offsetY != 0.0 || this._offsetZ != 0.0 || this._m44 != 1.0)
          return false;
        this.IsDistinguishedIdentity = true;
        return true;
      }
    }

    public void Translate(Vector3d offset)
    {
      if (this.IsDistinguishedIdentity)
      {
        this.SetTranslationMatrix(ref offset);
      }
      else
      {
        this._m11 += this._m14 * offset.X;
        this._m12 += this._m14 * offset.Y;
        this._m13 += this._m14 * offset.Z;
        this._m21 += this._m24 * offset.X;
        this._m22 += this._m24 * offset.Y;
        this._m23 += this._m24 * offset.Z;
        this._m31 += this._m34 * offset.X;
        this._m32 += this._m34 * offset.Y;
        this._m33 += this._m34 * offset.Z;
        this._offsetX += this._m44 * offset.X;
        this._offsetY += this._m44 * offset.Y;
        this._offsetZ += this._m44 * offset.Z;
      }
    }

    public Point3d Transform(Point3d point)
    {
      this.MultiplyPoint(ref point);
      return point;
    }

    internal void MultiplyPoint(ref Point3d point)
    {
      if (this.IsDistinguishedIdentity)
        return;
      double x = point.X;
      double y = point.Y;
      double z = point.Z;
      point.X = x * this._m11 + y * this._m21 + z * this._m31 + this._offsetX;
      point.Y = x * this._m12 + y * this._m22 + z * this._m32 + this._offsetY;
      point.Z = x * this._m13 + y * this._m23 + z * this._m33 + this._offsetZ;
      if (this.IsAffine)
        return;
      double num = x * this._m14 + y * this._m24 + z * this._m34 + this._m44;
      point.X /= num;
      point.Y /= num;
      point.Z /= num;
    }

    internal void SetTranslationMatrix(ref Vector3d offset)
    {
      this._m11 = this._m22 = this._m33 = this._m44 = 1.0;
      this._offsetX = offset.X;
      this._offsetY = offset.Y;
      this._offsetZ = offset.Z;
      this.IsDistinguishedIdentity = false;
    }

    private static Matrix3d CreateIdentity() => new Matrix3d(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0)
    {
      IsDistinguishedIdentity = true
    };

    private bool IsDistinguishedIdentity
    {
      get => !this._isNotKnownToBeIdentity;
      set => this._isNotKnownToBeIdentity = !value;
    }

    public override bool Equals(object obj) => obj != null && obj is Matrix3d matrix2 && Matrix3d.Equals(this, matrix2);

    public override int GetHashCode()
    {
      if (this.IsDistinguishedIdentity)
        return 0;
      int hashCode1 = this.M11.GetHashCode();
      double num1 = this.M12;
      int hashCode2 = num1.GetHashCode();
      int num2 = hashCode1 ^ hashCode2;
      num1 = this.M13;
      int hashCode3 = num1.GetHashCode();
      int num3 = num2 ^ hashCode3;
      num1 = this.M14;
      int hashCode4 = num1.GetHashCode();
      int num4 = num3 ^ hashCode4;
      num1 = this.M21;
      int hashCode5 = num1.GetHashCode();
      int num5 = num4 ^ hashCode5;
      num1 = this.M22;
      int hashCode6 = num1.GetHashCode();
      int num6 = num5 ^ hashCode6;
      num1 = this.M23;
      int hashCode7 = num1.GetHashCode();
      int num7 = num6 ^ hashCode7;
      num1 = this.M24;
      int hashCode8 = num1.GetHashCode();
      int num8 = num7 ^ hashCode8;
      num1 = this.M31;
      int hashCode9 = num1.GetHashCode();
      int num9 = num8 ^ hashCode9;
      num1 = this.M32;
      int hashCode10 = num1.GetHashCode();
      int num10 = num9 ^ hashCode10;
      num1 = this.M33;
      int hashCode11 = num1.GetHashCode();
      int num11 = num10 ^ hashCode11;
      num1 = this.M34;
      int hashCode12 = num1.GetHashCode();
      int num12 = num11 ^ hashCode12;
      num1 = this.OffsetX;
      int hashCode13 = num1.GetHashCode();
      int num13 = num12 ^ hashCode13;
      num1 = this.OffsetY;
      int hashCode14 = num1.GetHashCode();
      int num14 = num13 ^ hashCode14;
      num1 = this.OffsetZ;
      int hashCode15 = num1.GetHashCode();
      int num15 = num14 ^ hashCode15;
      num1 = this.M44;
      int hashCode16 = num1.GetHashCode();
      return num15 ^ hashCode16;
    }

    public static bool Equals(Matrix3d matrix1, Matrix3d matrix2)
    {
      if (matrix1.IsDistinguishedIdentity || matrix2.IsDistinguishedIdentity)
        return matrix1.IsIdentity == matrix2.IsIdentity;
      return matrix1.M11.Equals(matrix2.M11) && matrix1.M12.Equals(matrix2.M12) && matrix1.M13.Equals(matrix2.M13) && matrix1.M14.Equals(matrix2.M14) && matrix1.M21.Equals(matrix2.M21) && matrix1.M22.Equals(matrix2.M22) && matrix1.M23.Equals(matrix2.M23) && matrix1.M24.Equals(matrix2.M24) && matrix1.M31.Equals(matrix2.M31) && matrix1.M32.Equals(matrix2.M32) && matrix1.M33.Equals(matrix2.M33) && matrix1.M34.Equals(matrix2.M34) && matrix1.OffsetX.Equals(matrix2.OffsetX) && matrix1.OffsetY.Equals(matrix2.OffsetY) && matrix1.OffsetZ.Equals(matrix2.OffsetZ) && matrix1.M44.Equals(matrix2.M44);
    }

    public static bool operator ==(Matrix3d matrix1, Matrix3d matrix2)
    {
      if (matrix1.IsDistinguishedIdentity || matrix2.IsDistinguishedIdentity)
        return matrix1.IsIdentity == matrix2.IsIdentity;
      return matrix1.M11 == matrix2.M11 && matrix1.M12 == matrix2.M12 && matrix1.M13 == matrix2.M13 && matrix1.M14 == matrix2.M14 && matrix1.M21 == matrix2.M21 && matrix1.M22 == matrix2.M22 && matrix1.M23 == matrix2.M23 && matrix1.M24 == matrix2.M24 && matrix1.M31 == matrix2.M31 && matrix1.M32 == matrix2.M32 && matrix1.M33 == matrix2.M33 && matrix1.M34 == matrix2.M34 && matrix1.OffsetX == matrix2.OffsetX && matrix1.OffsetY == matrix2.OffsetY && matrix1.OffsetZ == matrix2.OffsetZ && matrix1.M44 == matrix2.M44;
    }

    public static bool operator !=(Matrix3d matrix1, Matrix3d matrix2) => !(matrix1 == matrix2);

    public bool Equals(Matrix3d other) => throw new NotImplementedException();
  }
}
