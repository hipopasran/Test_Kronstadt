namespace Test_Kronstadt
{

    public class Path
    {
        private int numberOfTrains;
        private Station busyDirection;

        public Path(int length)
        {
            this.Length = length;
        }

        public int Length { get; private set; }

        public bool IsCrash { get; private set; }

        public void AddTrain(Train tr)
        {
            if (this.busyDirection == tr.NextStation)
            {
                this.numberOfTrains++;
            }
            else if (this.busyDirection == tr.LastStation)
            {
                this.IsCrash = true;
            }
            else
            {
                this.numberOfTrains++;
                this.busyDirection = tr.NextStation;
            }
        }

        public void RemoveTrain(Train tr)
        {
            this.numberOfTrains--;

            if (this.numberOfTrains == 0)
            {
                this.busyDirection = null;
            }
        }
    }
}
