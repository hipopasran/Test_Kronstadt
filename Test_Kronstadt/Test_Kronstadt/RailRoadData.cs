namespace Test_Kronstadt
{
    using System.Collections.Generic;

    public class RailRoadData
    {
        public IEnumerable<TrainData> Trains { get; set; }

        public IEnumerable<PathData> Paths { get; set; }

        public IEnumerable<StationData> Stations { get; set; }
    }
}
