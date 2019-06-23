namespace Test_Kronstadt
{
    using System.Collections.Generic;
    using System.Linq;

    public class MapManager
    {
        private List<Train> trains = new List<Train>();

        private Dictionary<int, Station> dictOfStations = new Dictionary<int, Station>();

        public MapManager(RailRoadData data)
        {
            foreach (var st in data.Stations)
            {
                this.dictOfStations.Add(st.Id, new Station(st.Id));
            }

            foreach (var pt in data.Paths)
            {
                var path = new Path(pt.Length);

                this.dictOfStations[pt.FirstStationId].Paths.Add(pt.SecondStationId, path);
                this.dictOfStations[pt.SecondStationId].Paths.Add(pt.FirstStationId, path);
            }

            foreach (var tr in data.Trains)
            {
                var trainStations = tr.Route.Select(stationId => this.dictOfStations[stationId]);
                var train = new Train(trainStations);
                this.trains.Add(train);
            }
        }

        public string CheckMap()
        {
            foreach (var train in this.trains)
            {
                if (this.CheckCollision())
                {
                    return "Авария при начальной расстановке поездов!";
                }
            }

            while (this.trains.Any(t => (t.StationPath.Any() || !t.IsOnStation)))
            {
                foreach (var train in this.trains)
                {
                    if (train.StationPath.Count == 0 && train.IsOnStation)
                    {
                        train.EndOfTrip();
                        continue;
                    }

                    if (train.IsOnStation)
                    {
                        train.SetNextDirection();
                    }

                    train.MakeStep();
                }

                if (this.CheckCollision())
                {
                    return "Произойдет столкновение!";
                }
            }

            return "Столкновений не обнаружено!";
        }

        private bool CheckCollision()
        {
            return this.dictOfStations.Any(s =>
            {
                var station = s.Value;
                var stationPaths = station.Paths.Select(p => p.Value);
                return station.IsCrash || stationPaths.Any(p => p.IsCrash);
            });
        }
    }
}
