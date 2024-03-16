﻿using Hackathon.Domain.Enums;
using Hackathon.Domain.Util;

namespace Hackathon.Domain.Videos
{
    public class Video : ClassBase
    {
        public string InputFileName{ get; set; }
        public string OutputFileName { get; set; }
        public FileProcessStatus Status { get; set; }
        public DateTime EndedAt { get; set; }

        public Video(string inputFileName, string outputFileName, FileProcessStatus fileStatus, DateTime endedAt) : base()
        {
            InputFileName = inputFileName;
            OutputFileName = outputFileName;
            Status = fileStatus;
            EndedAt = endedAt;

        }
    }
}