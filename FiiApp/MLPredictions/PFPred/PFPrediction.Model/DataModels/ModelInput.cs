//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using Microsoft.ML.Data;

namespace PFPrediction.Model.DataModels
{
    public class ModelInput
    {
        [ColumnName("Gender"), LoadColumn(0)]
        public float Gender { get; set; }


        [ColumnName("Class"), LoadColumn(1)]
        public float Class { get; set; }


        [ColumnName("NrPS1"), LoadColumn(2)]
        public float NrPS1 { get; set; }


        [ColumnName("NrPSM1"), LoadColumn(3)]
        public float NrPSM1 { get; set; }


        [ColumnName("NrPSA1"), LoadColumn(4)]
        public float NrPSA1 { get; set; }


        [ColumnName("NrPCA1"), LoadColumn(5)]
        public float NrPCA1 { get; set; }


        [ColumnName("NrPC1"), LoadColumn(6)]
        public float NrPC1 { get; set; }


        [ColumnName("NET1"), LoadColumn(7)]
        public float NET1 { get; set; }


        [ColumnName("NL1"), LoadColumn(8)]
        public float NL1 { get; set; }


        [ColumnName("NrPS2"), LoadColumn(9)]
        public float NrPS2 { get; set; }


        [ColumnName("NrPSM2"), LoadColumn(10)]
        public float NrPSM2 { get; set; }


        [ColumnName("NrPSA2"), LoadColumn(11)]
        public float NrPSA2 { get; set; }


        [ColumnName("NrPCA2"), LoadColumn(12)]
        public float NrPCA2 { get; set; }


        [ColumnName("NrPC2"), LoadColumn(13)]
        public float NrPC2 { get; set; }


        [ColumnName("NET2"), LoadColumn(14)]
        public float NET2 { get; set; }


        [ColumnName("NL2"), LoadColumn(15)]
        public float NL2 { get; set; }


        [ColumnName("BS"), LoadColumn(16)]
        public float BS { get; set; }


        [ColumnName("PF"), LoadColumn(17)]
        public float PF { get; set; }


    }
}
