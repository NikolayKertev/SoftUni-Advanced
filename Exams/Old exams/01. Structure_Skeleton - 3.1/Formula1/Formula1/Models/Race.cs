﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;

        private Race()
        {
            Pilots = new List<IPilot>();
        }
        public Race(string raceName, int numberOfLaps)
            : this()
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                raceName = value;
            }
        }
        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                numberOfLaps = value;
            }
        }
        public bool TookPlace { get; set; }
        public ICollection<IPilot> Pilots { get; }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {RaceName} race has:")
                .AppendLine($"Participants: {Pilots.Count}")
                .AppendLine($"Number of laps: {NumberOfLaps}")
                .AppendLine($"Took place: {(TookPlace ? "Yes" : "No")}");

            return sb.ToString().Trim();
        }
    }
}
