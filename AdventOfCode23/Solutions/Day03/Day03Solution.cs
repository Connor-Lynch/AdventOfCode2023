using AdventOfCode23.Interfaces;
using AdventOfCode23.Solutions.Day03.Models;

namespace AdventOfCode23.Solutions.Day03
{
    public class Day03Solution : SolutionBase, ISolution
    {
        private IFileReader _fileReader;
        private List<string> _rows = new List<string>();

        public Day03Solution(IFileReader fileReader)
        {
            _fileReader = fileReader;
            InitRows();
            ResetSolution();
        }

        public void Solve()
        {
            StartTime();
            var part1Answer = GetSumOfValidPartNumbers();
            SetAnswer(part1Answer.ToString());

            StartTime();
            var part2Answer = GetSumOfAllGearRatios();
            SetAnswer(part2Answer.ToString());
        }

        public int GetSumOfValidPartNumbers()
        {
            var rows = new List<Row>();

            _rows.ForEach(rawRow =>
            {
                var row = BuildRow(rawRow);

                if (rows.Count > 0)
                    ValidateRow(row, rows.Last());

                rows.Add(row);
            });

            for (int i = 0; i < rows.Count - 1; i++)
            {
                ValidateRow(rows[i], rows[i + 1]);
            };

            return rows.Sum(r => r.PartNumbers.Where(p => p.Valid).Sum(p => p.Number));
        }

        public int GetSumOfAllGearRatios()
        {
            var rows = new List<Row>();

            var index = 0;
            _rows.ForEach(rawRow =>
            {
                var row = BuildRow(rawRow);
                row.Index = index;

                rows.Add(row);

                index++;
            });

            var potentialGears = rows.Where(r => r.Symbols.Any(s => s.IsPotentialGear)).ToList();

            potentialGears.ForEach(pg =>
            {
                TyrGetGearRation(pg, rows);
            });

            var gearRows = potentialGears.Where(g => g.Symbols.Any(s => s.IsGear));
            var totalSumOfGearRatios = potentialGears.Sum(g => g.Symbols.Where(s => s.IsGear).Sum(s => s.GearRatio));

            return totalSumOfGearRatios;
        }

        private Row BuildRow(string rawRow)
        {
            const string emptyPartNumber = "";
            var row = new Row();
            var workingPartNumber = emptyPartNumber;

            for (int i = 0; i < rawRow.Length; i++)
            {
                if (char.IsDigit(rawRow[i]))
                    workingPartNumber += rawRow[i];
                else
                {
                    if (rawRow[i] != '.')
                        row.Symbols.Add(new Symbol(i, rawRow[i]));

                    if (workingPartNumber != emptyPartNumber)
                        row.PartNumbers.Add(BuildPartNumber(rawRow, i, workingPartNumber));

                    workingPartNumber = emptyPartNumber;
                }

                if (i == rawRow.Length - 1 && workingPartNumber != emptyPartNumber)
                    row.PartNumbers.Add(BuildPartNumber(rawRow, i + 1, workingPartNumber));
            }

            return row;
        }

        private PartNumber BuildPartNumber(string rawRow, int index, string workingPartNumber)
        {
            var partNumber = new PartNumber();

            partNumber.Number = int.Parse(workingPartNumber);
            partNumber.EndIndex = index - 1;
            partNumber.StartIndex = partNumber.EndIndex + 1 - workingPartNumber.Length;
            partNumber.Valid = IsIndexASymbol(rawRow, partNumber.StartIndex - 1) || IsIndexASymbol(rawRow, partNumber.EndIndex + 1);

            return partNumber;
        }

        private bool IsIndexASymbol(string rawRow, int index)
        {
            if (index < 0 || index + 1 > rawRow.Length)
                return false;

            return rawRow[index] != '.';
        }

        private void ValidateRow(Row currentRow, Row adjacentRow)
        {
            var partNumbersToValidate = currentRow.PartNumbers.Where(p => !p.Valid).ToList();            

            partNumbersToValidate.ForEach(p =>
            {
                adjacentRow.Symbols.ForEach(l =>
                {
                    if (!p.Valid)
                        p.Valid = l.Index >= p.StartIndex - 1 && l.Index <= p.EndIndex + 1;
                });

            });

        }

        private void TyrGetGearRation(Row gear, List<Row> rows)
        {
            CheckForGearPieces(gear);

            var upperRowIndex = gear.Index - 1;
            if (upperRowIndex >= 0)
                CheckForGearPieces(gear, rows[upperRowIndex]);

            var lowerRowIndex = gear.Index + 1;
            if (lowerRowIndex <= rows.Count)
                CheckForGearPieces(gear, rows[lowerRowIndex]);
        }

        private void CheckForGearPieces(Row gear)
        {
            CheckForGearPieces(gear, gear);
        }

        private void CheckForGearPieces(Row gear, Row adjacentRow)
        {
            if (!adjacentRow.PartNumbers.Any())
                return;

            var gears = gear.Symbols.Where(s => s.IsPotentialGear).ToList();

            TrySetGearRatios(gears, adjacentRow.PartNumbers);
        }

        private void TrySetGearRatios(List<Symbol> gears, List<PartNumber> parts)
        {
            gears.ForEach(potentialGear =>
            {
                parts.ForEach(part =>
                {
                    if (potentialGear.Index >= part.StartIndex - 1 && potentialGear.Index <= part.EndIndex + 1)
                        potentialGear.TryAddGearRatio(part.Number);
                });
            });
        }

        private void InitRows()
        {
            _rows = _fileReader.ReadFileToStringArray("Solutions/Day03/data.json");
        }
    }
}
