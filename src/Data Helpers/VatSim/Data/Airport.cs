namespace VatSim.Data
{
    public class Airport
    {
        public string Id;
        public string Icao;
        public string Name;
        public WorldPoint Loc;
        public string FirIcao;
        public bool IsPseudo;

        public Airport(
          string id,
          string icao,
          string name,
          WorldPoint loc,
          string firIcao,
          bool pseudo)
        {
            this.Id = id;
            this.Icao = icao;
            this.Name = name;
            this.Loc = loc;
            this.FirIcao = firIcao;
            this.IsPseudo = pseudo;
        }
    }
}
