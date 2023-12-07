namespace AdventOfCode23.Solutions.Day03.Models
{
    public class Symbol
    {
        private bool _invalidGear = false;
        public List<int> _gearRatios = new List<int>();
        public int Index { get; set; }
        public char Value { get; set; }
        public bool IsPotentialGear { get => _invalidGear ? false : Value == '*'; }
        public bool IsGear { get => _gearRatios.Count == 2; }
        public int GearRatio { get => _gearRatios.First() * _gearRatios.Last(); }

        public Symbol(int index, char value) 
        { 
            Index = index;
            Value = value;
        }

        public void TryAddGearRatio(int ratio)
        {
            if (_gearRatios.Count >= 2)
            {
                _gearRatios.Clear();
                _invalidGear = true;
                return;
            }

            _gearRatios.Add(ratio);
        }
    }
}
