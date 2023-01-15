namespace ATC_Helper.Classes
{
    public enum SidRouteType
    {
        EngineOutSID = 0,
        SidRunwayTransition = 1,
        SidCommonRoute = 2,
        SidEnrouteTransition = 3,
        RnavSidRunwayTransition = 4,
        RnavSidCommonRoute = 5,
        RnavSidEnrouteTransition = 6,
        FmsSidRunwayTransition = 'F',
        FmsSidCommonRoute = 'M',
        FmsSidEnrouteTransition = 'S',
        VectorSidRunwayTransition = 'T',
        VectorSIDEnrouteTransition = 'V'
    }

    public enum SidType
    {
        EngineOut,
        Standard,
        RNAV,
        FMS,
        Vector,
        Unknown
    }

}
