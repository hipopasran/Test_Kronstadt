namespace Test_Kronstadt
{
    using System.Collections.Generic;

    public class Train
    {
        public Queue<Station> StationPath = new Queue<Station>();

        public Train(IEnumerable<Station> route)
        {
            this.IsOnStation = true;
            foreach (var station in route)
            {
                this.StationPath.Enqueue(station);
            }

            this.SetStartPosition();
        }

        public int StepsLeft { get; private set; }

        public bool IsOnStation { get; private set; }

        public Station LastStation { get; private set; }

        public Station NextStation { get; private set; }

        public Station CurrentStation { get; private set; }

        public Path CurrentPath { get; private set; }

        public void SetNextDirection()
        {
            this.NextStation = this.StationPath.Dequeue();
            this.CurrentPath = this.CurrentStation.Paths[this.NextStation.Id];
            this.LeaveFromStation();
            this.ComeToPath();
        }

        public void ComeToStation()
        {
            this.IsOnStation = true;
            this.CurrentStation = this.NextStation;
            this.LastStation = this.NextStation;
            this.NextStation.AddTrain(this);
        }

        public void LeaveFromStation()
        {
            this.IsOnStation = false;
            this.LastStation = this.CurrentStation;
            this.CurrentStation.RemoveTrain(this);
            this.CurrentStation = null;
        }

        public void ComeToPath()
        {
            this.StepsLeft = this.CurrentPath.Length;
            this.CurrentPath.AddTrain(this);
        }

        public void LeaveFromPath()
        {
            this.CurrentPath.RemoveTrain(this);
            this.CurrentPath = null;
        }

        public void MakeStep()
        {
            this.StepsLeft = this.StepsLeft - 1;

            if (this.StepsLeft < 0)
            {
                this.LeaveFromPath();
                this.ComeToStation();
            }
        }

        public void EndOfTrip()
        {
            this.CurrentStation.EndTrainTrip();
        }

        private void SetStartPosition()
        {
            this.CurrentStation = this.StationPath.Dequeue();
            this.CurrentStation.AddTrain(this);
        }
    }
}
