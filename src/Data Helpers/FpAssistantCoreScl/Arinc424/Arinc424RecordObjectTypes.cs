// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Arinc424RecordObjectTypes
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;

namespace ArincReader.Arinc424
{
    public enum Arinc424RecordObjectTypes
    {
        [Description(Text = "Header1")] Header1,
        [Description(Text = "Header2")] Header2,
        [Description(Text = "Grid MORA")] GridMora,
        [Description(Text = "VHF Navaid")] VhfNavaid,
        [Description(Text = "NDB Navaid Enroute")] NdbNavaidEnroute,
        [Description(Text = "NDB Navaid Terminal")] NdbNavaidTerminal,
        [Description(Text = "Waypoint Enroute")] WaypointEnroute,
        [Description(Text = "Waypoint Terminal")] WaypointTerminal,
        [Description(Text = "Waypoint Heliport Terminal")] WaypointHeliportTerminal,
        [Description(Text = "Enroute Airway")] EnrouteAirway,
        [Description(Text = "Airport")] Airport,
        [Description(Text = "Heliport")] Heliport,
        [Description(Text = "Airport Runway")] AirportRunway,
        [Description(Text = "Restrictive Airspace")] RestrictiveAirspace,
        [Description(Text = "Controlled Airspace")] ControlledAirspace,
        [Description(Text = "Airport SID")] AirportSid,
        [Description(Text = "Airport STAR")] AirportStar,
        [Description(Text = "Airport Approach")] AirportApproach,
        [Description(Text = "Airport MSA")] AirportMsa,
        [Description(Text = "Heliport MSA")] HeliportMsa,
        [Description(Text = "Path Point")] PathPoint,
        [Description(Text = "Airport and Heliport Localizer and Glide Slope")] AirportHeliportLocalizerGlideSlope,
        [Description(Text = "Heliport SID")] HeliportSid,
        [Description(Text = "Heliport STAR")] HeliportStar,
        [Description(Text = "Heliport Approach")] HeliportApproach,
        [Description(Text = "Unknown")] Unknown,
    }
}
