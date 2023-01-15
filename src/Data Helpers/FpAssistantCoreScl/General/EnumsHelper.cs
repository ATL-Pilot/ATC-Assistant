﻿// Decompiled with JetBrains decompiler
// Type: ArincReader.General.EnumsHelper
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;
using System.Linq;
using System.Reflection;

namespace ArincReader.General
{
    public static class EnumsHelper
    {
        private static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute => enumVal.GetType().GetTypeInfo().DeclaredMembers.First<MemberInfo>((Func<MemberInfo, bool>)(x => x.Name == enumVal.ToString())).GetCustomAttribute<T>();

        public static string GetDescription(this Enum enumValue) => enumValue.GetAttributeOfType<DescriptionAttribute>().Text;
    }
}
