//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using Microsoft.ML.Data;

namespace ECTSPrediction.Model.DataModels
{
    public class ModelInput
    {
        [ColumnName("PF"), LoadColumn(0)]
        public float PF { get; set; }


        [ColumnName("ECTS"), LoadColumn(1)]
        public float ECTS { get; set; }


    }
}
