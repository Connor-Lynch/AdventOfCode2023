namespace AdventOfCode23.Solutions.Day06.Models
{
    public class Race
    {
        public long Time { get; set; }
        public long Distance { get; set; }

        public Race(long time, long distance) 
        {
            Time = time;
            Distance = distance;
        }

        public long GetNumberOfWinningPreLoads()
        {
            var winningPreLoads = new List<long>();

            for(long i = 1; i < Time; i ++)
            {
                var runDistance = i * (Time - i);
    
                if (runDistance > Distance)
                    winningPreLoads.Add(runDistance);

                if (winningPreLoads.Count > 0 && runDistance < Distance)
                    break;
            }

            return winningPreLoads.Count;
        }
    }
}
