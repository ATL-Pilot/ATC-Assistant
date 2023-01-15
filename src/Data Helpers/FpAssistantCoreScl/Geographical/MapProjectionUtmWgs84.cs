// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.MapProjectionUtmWgs84
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;

namespace ArincReader.Geographical
{
    public enum MapProjectionUtmWgs84
    {
        [Description(Text = "UTM84-1N")] UTM841N = 1,
        [Description(Text = "UTM84-2N")] UTM842N = 2,
        [Description(Text = "UTM84-3N")] UTM843N = 3,
        [Description(Text = "UTM84-4N")] UTM844N = 4,
        [Description(Text = "UTM84-5N")] UTM845N = 5,
        [Description(Text = "UTM84-6N")] UTM846N = 6,
        [Description(Text = "UTM84-7N")] UTM847N = 7,
        [Description(Text = "UTM84-8N")] UTM848N = 8,
        [Description(Text = "UTM84-9N")] UTM849N = 9,
        [Description(Text = "UTM84-10N")] UTM8410N = 10, // 0x0000000A
        [Description(Text = "UTM84-11N")] UTM8411N = 11, // 0x0000000B
        [Description(Text = "UTM84-12N")] UTM8412N = 12, // 0x0000000C
        [Description(Text = "UTM84-13N")] UTM8413N = 13, // 0x0000000D
        [Description(Text = "UTM84-14N")] UTM8414N = 14, // 0x0000000E
        [Description(Text = "UTM84-15N")] UTM8415N = 15, // 0x0000000F
        [Description(Text = "UTM84-16N")] UTM8416N = 16, // 0x00000010
        [Description(Text = "UTM84-17N")] UTM8417N = 17, // 0x00000011
        [Description(Text = "UTM84-18N")] UTM8418N = 18, // 0x00000012
        [Description(Text = "UTM84-19N")] UTM8419N = 19, // 0x00000013
        [Description(Text = "UTM84-20N")] UTM8420N = 20, // 0x00000014
        [Description(Text = "UTM84-21N")] UTM8421N = 21, // 0x00000015
        [Description(Text = "UTM84-22N")] UTM8422N = 22, // 0x00000016
        [Description(Text = "UTM84-23N")] UTM8423N = 23, // 0x00000017
        [Description(Text = "UTM84-24N")] UTM8424N = 24, // 0x00000018
        [Description(Text = "UTM84-25N")] UTM8425N = 25, // 0x00000019
        [Description(Text = "UTM84-26N")] UTM8426N = 26, // 0x0000001A
        [Description(Text = "UTM84-27N")] UTM8427N = 27, // 0x0000001B
        [Description(Text = "UTM84-28N")] UTM8428N = 28, // 0x0000001C
        [Description(Text = "UTM84-29N")] UTM8429N = 29, // 0x0000001D
        [Description(Text = "UTM84-30N")] UTM8430N = 30, // 0x0000001E
        [Description(Text = "UTM84-31N")] UTM8431N = 31, // 0x0000001F
        [Description(Text = "UTM84-32N")] UTM8432N = 32, // 0x00000020
        [Description(Text = "UTM84-33N")] UTM8433N = 33, // 0x00000021
        [Description(Text = "UTM84-34N")] UTM8434N = 34, // 0x00000022
        [Description(Text = "UTM84-35N")] UTM8435N = 35, // 0x00000023
        [Description(Text = "UTM84-36N")] UTM8436N = 36, // 0x00000024
        [Description(Text = "UTM84-37N")] UTM8437N = 37, // 0x00000025
        [Description(Text = "UTM84-38N")] UTM8438N = 38, // 0x00000026
        [Description(Text = "UTM84-39N")] UTM8439N = 39, // 0x00000027
        [Description(Text = "UTM84-40N")] UTM8440N = 40, // 0x00000028
        [Description(Text = "UTM84-41N")] UTM8441N = 41, // 0x00000029
        [Description(Text = "UTM84-42N")] UTM8442N = 42, // 0x0000002A
        [Description(Text = "UTM84-43N")] UTM8443N = 43, // 0x0000002B
        [Description(Text = "UTM84-44N")] UTM8444N = 44, // 0x0000002C
        [Description(Text = "UTM84-45N")] UTM8445N = 45, // 0x0000002D
        [Description(Text = "UTM84-46N")] UTM8446N = 46, // 0x0000002E
        [Description(Text = "UTM84-47N")] UTM8447N = 47, // 0x0000002F
        [Description(Text = "UTM84-48N")] UTM8448N = 48, // 0x00000030
        [Description(Text = "UTM84-49N")] UTM8449N = 49, // 0x00000031
        [Description(Text = "UTM84-50N")] UTM8450N = 50, // 0x00000032
        [Description(Text = "UTM84-51N")] UTM8451N = 51, // 0x00000033
        [Description(Text = "UTM84-52N")] UTM8452N = 52, // 0x00000034
        [Description(Text = "UTM84-53N")] UTM8453N = 53, // 0x00000035
        [Description(Text = "UTM84-54N")] UTM8454N = 54, // 0x00000036
        [Description(Text = "UTM84-55N")] UTM8455N = 55, // 0x00000037
        [Description(Text = "UTM84-56N")] UTM8456N = 56, // 0x00000038
        [Description(Text = "UTM84-57N")] UTM8457N = 57, // 0x00000039
        [Description(Text = "UTM84-58N")] UTM8458N = 58, // 0x0000003A
        [Description(Text = "UTM84-59N")] UTM8459N = 59, // 0x0000003B
        [Description(Text = "UTM84-60N")] UTM8460N = 60, // 0x0000003C
        [Description(Text = "UTM84-1S")] UTM841S = 101, // 0x00000065
        [Description(Text = "UTM84-2S")] UTM842S = 102, // 0x00000066
        [Description(Text = "UTM84-3S")] UTM843S = 103, // 0x00000067
        [Description(Text = "UTM84-4S")] UTM844S = 104, // 0x00000068
        [Description(Text = "UTM84-5S")] UTM845S = 105, // 0x00000069
        [Description(Text = "UTM84-6S")] UTM846S = 106, // 0x0000006A
        [Description(Text = "UTM84-7S")] UTM847S = 107, // 0x0000006B
        [Description(Text = "UTM84-8S")] UTM848S = 108, // 0x0000006C
        [Description(Text = "UTM84-9S")] UTM849S = 109, // 0x0000006D
        [Description(Text = "UTM84-10S")] UTM8410S = 110, // 0x0000006E
        [Description(Text = "UTM84-11S")] UTM8411S = 111, // 0x0000006F
        [Description(Text = "UTM84-12S")] UTM8412S = 112, // 0x00000070
        [Description(Text = "UTM84-13S")] UTM8413S = 113, // 0x00000071
        [Description(Text = "UTM84-14S")] UTM8414S = 114, // 0x00000072
        [Description(Text = "UTM84-15S")] UTM8415S = 115, // 0x00000073
        [Description(Text = "UTM84-16S")] UTM8416S = 116, // 0x00000074
        [Description(Text = "UTM84-17S")] UTM8417S = 117, // 0x00000075
        [Description(Text = "UTM84-18S")] UTM8418S = 118, // 0x00000076
        [Description(Text = "UTM84-19S")] UTM8419S = 119, // 0x00000077
        [Description(Text = "UTM84-20S")] UTM8420S = 120, // 0x00000078
        [Description(Text = "UTM84-21S")] UTM8421S = 121, // 0x00000079
        [Description(Text = "UTM84-22S")] UTM8422S = 122, // 0x0000007A
        [Description(Text = "UTM84-23S")] UTM8423S = 123, // 0x0000007B
        [Description(Text = "UTM84-24S")] UTM8424S = 124, // 0x0000007C
        [Description(Text = "UTM84-25S")] UTM8425S = 125, // 0x0000007D
        [Description(Text = "UTM84-26S")] UTM8426S = 126, // 0x0000007E
        [Description(Text = "UTM84-27S")] UTM8427S = 127, // 0x0000007F
        [Description(Text = "UTM84-28S")] UTM8428S = 128, // 0x00000080
        [Description(Text = "UTM84-29S")] UTM8429S = 129, // 0x00000081
        [Description(Text = "UTM84-30S")] UTM8430S = 130, // 0x00000082
        [Description(Text = "UTM84-31S")] UTM8431S = 131, // 0x00000083
        [Description(Text = "UTM84-32S")] UTM8432S = 132, // 0x00000084
        [Description(Text = "UTM84-33S")] UTM8433S = 133, // 0x00000085
        [Description(Text = "UTM84-34S")] UTM8434S = 134, // 0x00000086
        [Description(Text = "UTM84-35S")] UTM8435S = 135, // 0x00000087
        [Description(Text = "UTM84-36S")] UTM8436S = 136, // 0x00000088
        [Description(Text = "UTM84-37S")] UTM8437S = 137, // 0x00000089
        [Description(Text = "UTM84-38S")] UTM8438S = 138, // 0x0000008A
        [Description(Text = "UTM84-39S")] UTM8439S = 139, // 0x0000008B
        [Description(Text = "UTM84-40S")] UTM8440S = 140, // 0x0000008C
        [Description(Text = "UTM84-41S")] UTM8441S = 141, // 0x0000008D
        [Description(Text = "UTM84-42S")] UTM8442S = 142, // 0x0000008E
        [Description(Text = "UTM84-43S")] UTM8443S = 143, // 0x0000008F
        [Description(Text = "UTM84-44S")] UTM8444S = 144, // 0x00000090
        [Description(Text = "UTM84-45S")] UTM8445S = 145, // 0x00000091
        [Description(Text = "UTM84-46S")] UTM8446S = 146, // 0x00000092
        [Description(Text = "UTM84-47S")] UTM8447S = 147, // 0x00000093
        [Description(Text = "UTM84-48S")] UTM8448S = 148, // 0x00000094
        [Description(Text = "UTM84-49S")] UTM8449S = 149, // 0x00000095
        [Description(Text = "UTM84-50S")] UTM8450S = 150, // 0x00000096
        [Description(Text = "UTM84-51S")] UTM8451S = 151, // 0x00000097
        [Description(Text = "UTM84-52S")] UTM8452S = 152, // 0x00000098
        [Description(Text = "UTM84-53S")] UTM8453S = 153, // 0x00000099
        [Description(Text = "UTM84-54S")] UTM8454S = 154, // 0x0000009A
        [Description(Text = "UTM84-55S")] UTM8455S = 155, // 0x0000009B
        [Description(Text = "UTM84-56S")] UTM8456S = 156, // 0x0000009C
        [Description(Text = "UTM84-57S")] UTM8457S = 157, // 0x0000009D
        [Description(Text = "UTM84-58S")] UTM8458S = 158, // 0x0000009E
        [Description(Text = "UTM84-59S")] UTM8459S = 159, // 0x0000009F
        [Description(Text = "UTM84-60S")] UTM8460S = 160, // 0x000000A0
    }
}
