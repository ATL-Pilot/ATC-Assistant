namespace VatSim.Data
{
    public static class RatingExtensions
    {
        public static Rating ToRating(this int i)
        {
            switch (i)
            {
                case 2:
                    return Rating.S1;
                case 3:
                    return Rating.S2;
                case 4:
                    return Rating.S3;
                case 5:
                    return Rating.C1;
                case 6:
                    return Rating.C2;
                case 7:
                    return Rating.C3;
                case 8:
                    return Rating.I1;
                case 9:
                    return Rating.I2;
                case 10:
                    return Rating.I3;
                case 11:
                    return Rating.SUP;
                case 12:
                    return Rating.ADM;
                default:
                    return Rating.OBS;
            }
        }
    }
}
