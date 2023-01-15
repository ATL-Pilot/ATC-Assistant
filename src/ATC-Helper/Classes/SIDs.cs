namespace ATC_Helper.Classes
{
    //public enum SID
    //{
    //    ICONS4,
    //    BARMY4,
    //    BEAVY4,
    //    BOBZY4,
    //    ESTRR4,
    //    JOJO4,
    //    KILNS4,
    //    KRTR5,
    //    KWEEN4,
    //    LILLS2,
    //    WEAZL4,
    //    KER3,
    //    CLT2,
    //    KNI2
    //}

    //public enum Prop_SIDs
    //{
    //    KNI2
    //}

    //public enum Jet_Lowlevel_SIDs
    //{
    //    CLT2
    //}

    //public enum Jet_HighLevel_NonRNAV_SIDs
    //{
    //    KER3
    //}

    //public enum Jet_HighLevel_RNAV_SIDs
    //{
    //    ICONS4,
    //    BARMY4,
    //    BEAVY4,
    //    BOBZY4,
    //    ESTRR4,
    //    JOJO4,
    //    KILNS4,
    //    KRTR5,
    //    KWEEN4,
    //    LILLS2,
    //    WEAZL4,
    //    KER3
    //}

    public enum EquiptmentSuffix
    {
        W,
        A,
        Z,
        L,
        G
    }

    //internal class RouteSID
    //{
    //    public RouteSID()
    //    { }

    //    public RouteSID(string sid)
    //    {
    //        Enum.TryParse(sid, out SID tempValue);
    //        Name = tempValue;
    //    }

    //    private SID _Name;
    //    public SID Name { get { return _Name; } 
    //        set 
    //        { 
    //            _Name = value;

    //            switch (value)
    //            {
    //                case SID.ICONS4:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.G };
    //                    break;
    //                case SID.BARMY4:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.G };
    //                    break;
    //                case SID.BEAVY4:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.G };
    //                    break;

    //                case SID.BOBZY4:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.G };
    //                    break;
    //                case SID.ESTRR4:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.G };
    //                    break;
    //                case SID.JOJO4:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.G };
    //                    break;
    //                case SID.KILNS4:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.G };
    //                    break;
    //                case SID.KRTR5:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.G };
    //                    break;
    //                case SID.KWEEN4:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.G };
    //                    break;
    //                case SID.LILLS2:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.G };
    //                    break;
    //                case SID.WEAZL4:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.G };
    //                    break;
    //                case SID.KER3:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 11000;
    //                    _MaxAlt = 90000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.W, EquiptmentSuffix.A };
    //                    break;
    //                case SID.CLT2:
    //                    _EngineType = "Jet";
    //                    _MinAlt = 0;
    //                    _MaxAlt = 10000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.W, EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.A, EquiptmentSuffix.G };
    //                    break;
    //                case SID.KNI2:
    //                    _EngineType = "Prop";
    //                    _MinAlt = 0;
    //                    _MaxAlt = 40000;
    //                    _SuffixTypes = new EquiptmentSuffix[] { EquiptmentSuffix.W, EquiptmentSuffix.Z, EquiptmentSuffix.L, EquiptmentSuffix.A, EquiptmentSuffix.G };
    //                    break;
    //                default:
    //                    break;
    //            }

    //        } 
    //    }

    //    private EquiptmentSuffix[] _SuffixTypes;
    //    public EquiptmentSuffix[] SuffixTypes { get { return _SuffixTypes; } }

    //    private int _MinAlt;
    //    public int MinAlt { get { return _MinAlt; } }

    //    private int _MaxAlt;
    //    public int MaxAlt { get { return _MaxAlt; } }

    //    private string _EngineType;
    //    public string EngineType { get { return _EngineType; } }


    //}
}
