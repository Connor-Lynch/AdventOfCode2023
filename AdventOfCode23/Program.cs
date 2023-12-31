﻿using AdventOfCode23.Interfaces;

namespace AdventOfCode23
{
    class Program
    {
        private static ISolutionFactory _solutionFactory;
        private static IConsoleHelper _consoleHelper;
        private static bool _run;

        static void Main(string[] args)
        {
            InIt();

            do
            {
                var day = _consoleHelper.GetDayFromUser();

                if (!string.IsNullOrEmpty(day))
                {
                    _consoleHelper.InitDay(day);

                    var solution = _solutionFactory.GetSolution(day);
                    solution.Solve();
                    solution.PrintAnswers();
                }
                else
                {
                    _run = false;
                }

                _consoleHelper.IterationComplete();
            }
            while (_run);
        }

        private static void InIt()
        {
            _solutionFactory = new SolutionFactory();
            _consoleHelper = new ConsoleHelper();

            _consoleHelper.ShowMainText();

            _run = true;
        }
    }
}