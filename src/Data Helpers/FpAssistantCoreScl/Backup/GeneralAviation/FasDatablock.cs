// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.FasDatablock
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.Geographical;
using System;
using System.Text.RegularExpressions;

namespace FpAssistantCore.GeneralAviation
{
  public class FasDatablock : BaseObjectFasDataBlock
  {
    private static readonly Regex _AirportIdRegex = new Regex("^[A-Z\\d]{3,4}$");
    private static readonly Regex _RouteIndicatorRegex = new Regex("^[A-HJ-NP-Z]{0,1}$");
    private static readonly Regex _ReferencePathIdentifierRegex = new Regex("^[A-Z\\d]{3,4}$");
    private SbasOperationTypes _SbasOperationType;
    private SbasApproachPerformanceDesignators _SbasApproachPerformanceDesignator;
    private GbasOperationTypes _GbasOperationType;
    private GbasApproachPerformanceDesignators _GbasApproachPerformanceDesignator;
    private BlockTypes _BlockType = BlockTypes.Sbas;
    private SbasProviderIdentifiers _SbasProviderIdentifier = SbasProviderIdentifiers.AnySbasServiceProvider;
    private string _AirportIdentifier = string.Empty;
    private int _RunwayNumber = 1;
    private RunwayLetters _RunwayLetter;
    private string _RouteIndicator = string.Empty;
    private int _ReferencePathDataSelector;
    private string _ReferencePathIdentifier = string.Empty;
    private GeoCoordinate _LtpFtp;
    private LinearDistance _LtpFtpHeight;
    private GeoCoordinate _Fpap;
    private Angle _DeltaFpapLatitude;
    private Angle _DeltaFpapLongitude;
    private LinearDistance _ThresholdCrossingHeight = new LinearDistance(0.0, LinearDistanceUnits.Metres);
    private Angle _GlidePathAngle = new Angle(0.0);
    private LinearDistance _CourseWidthThr = new LinearDistance(80.0, LinearDistanceUnits.Metres);
    private LinearDistance? _LengthOffset;
    private LinearDistance _HorizontalAlertLimit = new LinearDistance(0.0, LinearDistanceUnits.Metres);
    private LinearDistance _VerticalAlertLimit = new LinearDistance(0.0, LinearDistanceUnits.Metres);

    public BlockTypes BlockType
    {
      get => this._BlockType;
      set => this._BlockType = value;
    }

    public SbasOperationTypes SbasOperationType
    {
      get
      {
        if (this._BlockType != BlockTypes.Sbas)
          throw new InvalidOperationException("This property is only valid for SBAS block types.");
        return this._SbasOperationType;
      }
      set
      {
        if (this._BlockType != BlockTypes.Sbas)
          throw new InvalidOperationException("This property is only valid for SBAS block types.");
        this._SbasOperationType = value;
      }
    }

    public GbasOperationTypes GbasOperationType
    {
      get
      {
        if (this._BlockType != BlockTypes.Gbas)
          throw new InvalidOperationException("This property is only valid for GBAS block types.");
        return this._GbasOperationType;
      }
      set
      {
        if (this._BlockType != BlockTypes.Gbas)
          throw new InvalidOperationException("This property is only valid for GBAS block types.");
        this._GbasOperationType = value;
      }
    }

    public SbasProviderIdentifiers SbasProviderIdentifier
    {
      get => this._SbasProviderIdentifier;
      set => this._SbasProviderIdentifier = value;
    }

    public string AirportIdentifier
    {
      get => this._AirportIdentifier;
      set
      {
        value = value != null ? value.Trim().ToUpper() : throw new ArgumentNullException(nameof (AirportIdentifier));
        this._AirportIdentifier = FasDatablock._AirportIdRegex.IsMatch(value) ? value : throw new ArgumentException("Airport Identfier may only consist of 3 to 4 alphanumeric characters", nameof (AirportIdentifier));
      }
    }

    public int RunwayNumber
    {
      get => this._RunwayNumber;
      set => this._RunwayNumber = value >= 0 && value <= 36 ? value : throw new ArgumentOutOfRangeException(nameof (RunwayNumber), "The Runway number must be a value between 0 and 36");
    }

    public RunwayLetters RunwayLetter
    {
      get => this._RunwayLetter;
      set => this._RunwayLetter = value;
    }

    public SbasApproachPerformanceDesignators SbasApproachPerformanceDesignator
    {
      get
      {
        if (this._BlockType != BlockTypes.Sbas)
          throw new InvalidOperationException("This property is only valid for SBAS block types.");
        return this._SbasApproachPerformanceDesignator;
      }
      set
      {
        if (this._BlockType != BlockTypes.Sbas)
          throw new InvalidOperationException("This property is only valid for SBAS block types.");
        this._SbasApproachPerformanceDesignator = value;
      }
    }

    public GbasApproachPerformanceDesignators GbasApproachPerformanceDesignator
    {
      get
      {
        if (this._BlockType != BlockTypes.Gbas)
          throw new InvalidOperationException("This property is only valid for GBAS block types.");
        return this._GbasApproachPerformanceDesignator;
      }
      set
      {
        if (this._BlockType != BlockTypes.Gbas)
          throw new InvalidOperationException("This property is only valid for GBAS block types.");
        this._GbasApproachPerformanceDesignator = value;
      }
    }

    public string RouteIndicator
    {
      get => this._RouteIndicator;
      set
      {
        value = value != null ? value.Trim().ToUpper() : throw new ArgumentNullException(nameof (RouteIndicator));
        this._RouteIndicator = FasDatablock._RouteIndicatorRegex.IsMatch(value) ? value : throw new ArgumentException("Route Indicator must consist only of a single alphabetical letter excluding I and O", nameof (RouteIndicator));
      }
    }

    public int ReferencePathDataSelector
    {
      get => this._ReferencePathDataSelector;
      set => this._ReferencePathDataSelector = value >= 0 && value <= 48 ? value : throw new ArgumentOutOfRangeException(nameof (ReferencePathDataSelector), "Reference Path Data Selector number must be between 0 and 48");
    }

    public string ReferencePathIdentifier
    {
      get => this._ReferencePathIdentifier;
      set
      {
        value = value != null ? value.Trim().ToUpper() : throw new ArgumentNullException(nameof (ReferencePathIdentifier));
        this._ReferencePathIdentifier = FasDatablock._ReferencePathIdentifierRegex.IsMatch(value) ? value : throw new ArgumentException("Reference Path Identifier may only consist of 0 to 4 alphanumeric characters", nameof (ReferencePathIdentifier));
      }
    }

    public GeoCoordinate LtpFtp
    {
      get => this._LtpFtp;
      set
      {
        this._LtpFtp = value;
        this.ReconcileCoordinates(FasDatablock.ChangeSource.LtpFtp);
      }
    }

    public LinearDistance LtpFtpHeight
    {
      get => this._LtpFtpHeight;
      set
      {
        if (value.ValueUnit != LinearDistanceUnits.Metres)
          throw new ArgumentException("LTP/FTP height must be in Metres", nameof (LtpFtpHeight));
        this._LtpFtpHeight = value.Value >= -512.0 && value.Value <= 6041.5 ? value : throw new ArgumentOutOfRangeException(nameof (LtpFtpHeight), "LTP/FTP height must have a value between -512m and 6041.5m");
      }
    }

    public GeoCoordinate Fpap
    {
      get => this._Fpap;
      set
      {
        this._Fpap = value;
        this.ReconcileCoordinates(FasDatablock.ChangeSource.Fpap);
      }
    }

    public GeoCoordinate DeltaFpap
    {
      get => new GeoCoordinate((double) this._DeltaFpapLatitude, (double) this._DeltaFpapLongitude);
      set
      {
        this._DeltaFpapLatitude = (Angle) value.Latitude;
        this._DeltaFpapLongitude = (Angle) value.Longitude;
        this.ReconcileCoordinates(FasDatablock.ChangeSource.DeltaFpap);
      }
    }

    public Angle DeltaFpapLatitude
    {
      get => this._DeltaFpapLatitude;
      set
      {
        this._DeltaFpapLatitude = value;
        this.ReconcileCoordinates(FasDatablock.ChangeSource.DeltaFpap);
      }
    }

    public Angle DeltaFpapLongitude
    {
      get => this._DeltaFpapLongitude;
      set
      {
        this._DeltaFpapLongitude = value;
        this.ReconcileCoordinates(FasDatablock.ChangeSource.DeltaFpap);
      }
    }

    public LinearDistance ThresholdCrossingHeight
    {
      get => this._ThresholdCrossingHeight;
      set
      {
        if (value.ValueUnit == LinearDistanceUnits.KM || value.ValueUnit == LinearDistanceUnits.NM)
          throw new ArgumentException("TCH height must be in Metres or Feet", nameof (ThresholdCrossingHeight));
        switch (value.ValueUnit)
        {
          case LinearDistanceUnits.Metres:
            if (value.Value < 0.0 || value.Value > 1638.35)
              goto default;
            else
              break;
          case LinearDistanceUnits.Feet:
            if (value.Value < 0.0 || value.Value > 3276.7)
              goto default;
            else
              break;
          default:
            throw new ArgumentOutOfRangeException(nameof (ThresholdCrossingHeight), "TCH height must have a value between 0 and 1638.35m/3276.7ft");
        }
        this._ThresholdCrossingHeight = value;
      }
    }

    public Angle GlidePathAngle
    {
      get => this._GlidePathAngle;
      set => this._GlidePathAngle = value.AsDegrees() >= 0.0 && value.AsDegrees() <= 90.0 ? value : throw new ArgumentOutOfRangeException(nameof (GlidePathAngle), "Glide Path Angle must be between 0 and 90 degrees");
    }

    public LinearDistance CourseWidthTHR
    {
      get => this._CourseWidthThr;
      set
      {
        if (value.ValueUnit != LinearDistanceUnits.Metres)
          throw new ArgumentException("Course width must be in Metres", nameof (CourseWidthTHR));
        this._CourseWidthThr = value.Value >= 80.0 && value.Value <= 143.75 ? value : throw new ArgumentOutOfRangeException(nameof (CourseWidthTHR), "Course width at THR must have a value between 80m and 143.75m");
      }
    }

    public LinearDistance? LengthOffset
    {
      get => this._LengthOffset;
      set
      {
        if (value.HasValue)
        {
          LinearDistance linearDistance = value.Value;
          if (linearDistance.ValueUnit != LinearDistanceUnits.Metres)
            throw new ArgumentException("Length offset must be in Metres", nameof (LengthOffset));
          if (linearDistance.Value < 0.0 || linearDistance.Value > 2032.0)
            throw new ArgumentOutOfRangeException(nameof (LengthOffset), "Length offset must have a value between 0m and 2032m");
        }
        this._LengthOffset = value;
      }
    }

    public LinearDistance HorizontalAlertLimit
    {
      get => this._HorizontalAlertLimit;
      set
      {
        if (value.ValueUnit != LinearDistanceUnits.Metres)
          throw new ArgumentException("Horizontal alert limit must be in Metres", nameof (HorizontalAlertLimit));
        this._HorizontalAlertLimit = value.Value >= 0.0 && value.Value <= 50.8 ? value : throw new ArgumentOutOfRangeException(nameof (HorizontalAlertLimit), "Horizontal alert limit must have a value between 0m and 50.8m");
      }
    }

    public LinearDistance VerticalAlertLimit
    {
      get => this._VerticalAlertLimit;
      set
      {
        if (value.ValueUnit != LinearDistanceUnits.Metres)
          throw new ArgumentException("Vertical alert limit must be in Metres", nameof (VerticalAlertLimit));
        this._VerticalAlertLimit = value.Value >= 0.0 && value.Value <= 50.8 ? value : throw new ArgumentOutOfRangeException(nameof (VerticalAlertLimit), "Vertical alert limit must have a value between 0m and 50.8m");
      }
    }

    public byte[] CrcChecksum() => Crc.GenerateChecksumBytes(this.EncodeParameters());

    public byte[] EncodeDatablock()
    {
      byte[] numArray = this.EncodeParameters();
      byte[] checksumBytes = Crc.GenerateChecksumBytes(numArray);
      byte[] destinationArray = new byte[numArray.Length + checksumBytes.Length];
      Array.Copy((Array) numArray, (Array) destinationArray, numArray.Length);
      Array.Copy((Array) checksumBytes, 0, (Array) destinationArray, numArray.Length, checksumBytes.Length);
      return destinationArray;
    }

    public string AsHexString(byte[] block)
    {
      string empty = string.Empty;
      foreach (byte num in block)
        empty += string.Format("{0:X2} ", (object) num);
      return empty.TrimEnd();
    }

    private byte[] EncodeParameters()
    {
      int length;
      byte lowerValue;
      byte performanceDesignator;
      if (this._BlockType == BlockTypes.Sbas)
      {
        length = 36;
        lowerValue = (byte) this._SbasOperationType;
        performanceDesignator = (byte) this._SbasApproachPerformanceDesignator;
      }
      else
      {
        length = 34;
        lowerValue = (byte) this._GbasOperationType;
        performanceDesignator = (byte) this._GbasApproachPerformanceDesignator;
      }
      byte[] datablock = new byte[length];
      byte providerIdentifier = (byte) this._SbasProviderIdentifier;
      datablock[0] = FasDatablock.Pack(providerIdentifier, lowerValue, 4);
      string str1 = this._AirportIdentifier.PadRight(4, ' ');
      int num1 = 1;
      for (int index = 3; index >= 0; --index)
        datablock[num1++] = str1[index].ToIA5Byte();
      byte runwayLetter = (byte) this._RunwayLetter;
      byte runwayNumber = (byte) this._RunwayNumber;
      datablock[5] = FasDatablock.Pack(runwayLetter, runwayNumber, 6);
      byte ia5Byte = this._RouteIndicator.PadRight(1, ' ')[0].ToIA5Byte();
      datablock[6] = FasDatablock.Pack(ia5Byte, performanceDesignator, 3);
      datablock[7] = (byte) this._ReferencePathDataSelector;
      string str2 = this._ReferencePathIdentifier.PadRight(4, ' ');
      int num2 = 8;
      for (int index = 3; index >= 0; --index)
        datablock[num2++] = str2[index].ToIA5Byte();
      Angle angle = new Angle(this._LtpFtp.Latitude);
      FasDatablock.WriteInteger(datablock, 12, angle.TotalSeconds, 0.0005);
      angle = new Angle(this._LtpFtp.Longitude);
      FasDatablock.WriteInteger(datablock, 16, angle.TotalSeconds, 0.0005);
      FasDatablock.WriteShort(datablock, 20, this._LtpFtpHeight.Value - -512.0, 0.1);
      FasDatablock.WriteInteger(datablock, 22, this._DeltaFpapLatitude.TotalSeconds, 0.0005, 3);
      FasDatablock.WriteInteger(datablock, 25, this._DeltaFpapLongitude.TotalSeconds, 0.0005, 3);
      int num3 = this._ThresholdCrossingHeight.IsSi ? 1 : 0;
      short int16 = Convert.ToInt16(this._ThresholdCrossingHeight.Value / (num3 != 0 ? 0.05 : 0.1));
      short num4 = num3 != 0 ? (short) ((int) int16 | 32768) : (short) ((int) int16 & (int) short.MaxValue);
      FasDatablock.WriteShort(datablock, 28, num4);
      FasDatablock.WriteShort(datablock, 30, this._GlidePathAngle.AsDegrees(), 0.01);
      FasDatablock.WriteByte(datablock, 32, this._CourseWidthThr.Value - 80.0, 0.25);
      if (this._LengthOffset.HasValue)
        FasDatablock.WriteByte(datablock, 33, this._LengthOffset.Value.Value, 8.0);
      else
        datablock[33] = byte.MaxValue;
      if (this._BlockType == BlockTypes.Sbas)
      {
        FasDatablock.WriteByte(datablock, 34, this._HorizontalAlertLimit.Value, 0.2);
        FasDatablock.WriteByte(datablock, 35, this._VerticalAlertLimit.Value, 0.2);
      }
      return datablock;
    }

    private void ReconcileCoordinates(FasDatablock.ChangeSource changeSource)
    {
      switch (changeSource)
      {
        case FasDatablock.ChangeSource.LtpFtp:
          if (!this._Fpap.IsEmpty)
          {
            this._DeltaFpapLatitude = (Angle) (this._Fpap.Latitude - this._LtpFtp.Latitude);
            this._DeltaFpapLongitude = (Angle) (this._Fpap.Longitude - this._LtpFtp.Longitude);
            break;
          }
          if (!(this._DeltaFpapLatitude != (Angle) 0.0) || !(this._DeltaFpapLongitude != (Angle) 0.0))
            break;
          this._Fpap = new GeoCoordinate(this._LtpFtp.Latitude + (double) this._DeltaFpapLatitude, this._LtpFtp.Longitude + (double) this._DeltaFpapLongitude);
          break;
        case FasDatablock.ChangeSource.Fpap:
          if (!this._LtpFtp.IsEmpty)
          {
            this._DeltaFpapLatitude = (Angle) (this._Fpap.Latitude - this._LtpFtp.Latitude);
            this._DeltaFpapLongitude = (Angle) (this._Fpap.Longitude - this._LtpFtp.Longitude);
            break;
          }
          if (!(this._DeltaFpapLatitude != (Angle) 0.0) || !(this._DeltaFpapLongitude != (Angle) 0.0))
            break;
          this._LtpFtp = new GeoCoordinate(this._Fpap.Latitude - (double) this._DeltaFpapLatitude, this._Fpap.Longitude - (double) this._DeltaFpapLongitude);
          break;
        case FasDatablock.ChangeSource.DeltaFpap:
          if (!this._LtpFtp.IsEmpty)
          {
            this._Fpap = new GeoCoordinate(this._LtpFtp.Latitude + (double) this._DeltaFpapLatitude, this._LtpFtp.Longitude + (double) this._DeltaFpapLongitude);
            break;
          }
          if (this._Fpap.IsEmpty)
            break;
          this._LtpFtp = new GeoCoordinate(this._Fpap.Latitude - (double) this._DeltaFpapLatitude, this._Fpap.Longitude - (double) this._DeltaFpapLongitude);
          break;
      }
    }

    private static byte Pack(byte higherValue, byte lowerValue, int lowerWidth) => (byte) ((uint) higherValue << lowerWidth | (uint) lowerValue);

    private static void WriteInteger(
      byte[] datablock,
      int byteIndex,
      double value,
      double resolution,
      int length = 0)
    {
      byte[] bytes = FasDatablock.GetBytes(Convert.ToInt32(value / resolution));
      FasDatablock.WriteBytes(datablock, byteIndex, bytes, length);
    }

    private static void WriteShort(
      byte[] datablock,
      int byteIndex,
      double value,
      double resolution)
    {
      short int16 = Convert.ToInt16(value / resolution);
      FasDatablock.WriteShort(datablock, byteIndex, int16);
    }

    private static void WriteShort(byte[] datablock, int byteIndex, short value)
    {
      byte[] bytes = FasDatablock.GetBytes(value);
      FasDatablock.WriteBytes(datablock, byteIndex, bytes);
    }

    private static void WriteBytes(byte[] datablock, int byteIndex, byte[] bytes, int length = 0)
    {
      if (length == 0)
        length = bytes.Length;
      for (int index = 0; index < length; ++index)
        datablock[byteIndex++] = bytes[index];
    }

    private static void WriteByte(
      byte[] datablock,
      int byteIndex,
      double value,
      double resolution)
    {
      byte num = Convert.ToByte(value / resolution);
      datablock[byteIndex++] = num;
    }

    private static byte[] GetBytes(int value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      if (!BitConverter.IsLittleEndian)
        Array.Reverse((Array) bytes);
      return bytes;
    }

    private static byte[] GetBytes(short value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      if (!BitConverter.IsLittleEndian)
        Array.Reverse((Array) bytes);
      return bytes;
    }

    public bool DecodeDatablock(byte[] dataBlock) => throw new NotImplementedException();

    private enum ChangeSource
    {
      LtpFtp,
      Fpap,
      DeltaFpap,
    }

    public static class Constants
    {
      public const double CourseWidthResolution = 0.25;
      public const double CourseWidthOffset = 80.0;
      public const double GpaResolution = 0.01;
      public const double LatLongResolution = 0.0005;
      public const double LengthOffsetResolution = 8.0;
      public const double LtpHeightResolution = 0.1;
      public const double LtpHeightOffset = -512.0;
      public const double TchMetricResolution = 0.05;
      public const double TchNonMetricResolution = 0.1;
      public const double AlertLimitResolution = 0.2;
    }
  }
}
