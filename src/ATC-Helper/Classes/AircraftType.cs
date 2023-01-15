namespace ATC_Helper.Classes
{
    public class AircraftType
    {
        private string _Manufacturer;
        public string Manufacturer
        { get { return _Manufacturer; } set { _Manufacturer = value; } }

        private string _Model;
        public string Model { get { return _Model; } set { _Model = value; } }

        private string _TypeDesignator;
        public string TypeDesignator { get { return _TypeDesignator; } set { _TypeDesignator = value; } }

        private string _Description;
        public string Description { get { return _Description; } set { _Description = value; } }

        private string _EnginerType;
        public string EnginerType { get { return _EnginerType; } set { _EnginerType = value; } }

        private string _EngineCount;
        public string EngineCount { get { return _EngineCount; } set { _EngineCount = value; } }

        private string _WTC;
        public string WTC { get { return _WTC; } set { _WTC = value; } }

    }
}
