namespace Test_Kronstadt
{
    using System.Collections.Generic;

    public class Station
    {
        public Dictionary<int, Path> Paths = new Dictionary<int, Path>();

        private int numberOfTrains;

        public Station(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }

        public bool IsCrash { get; private set; }

        public Path GetPath(int id)
        {
            return this.Paths[id];
        }

        public void AddTrain(Train tr)
        {
            this.numberOfTrains++;
            if (this.numberOfTrains > 1)
            {
                this.IsCrash = true;
            }
        }

        public void RemoveTrain(Train tr)
        {
            this.numberOfTrains--;
            if (this.numberOfTrains <= 1)
            {
                this.IsCrash = false;
            }
        }

        public void EndTrainTrip()
        {
            this.numberOfTrains--;
            if (this.numberOfTrains <= 1)
            {
                this.IsCrash = false;
            }
        }
    }
}
