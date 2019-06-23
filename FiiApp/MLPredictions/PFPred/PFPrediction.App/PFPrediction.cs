//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using PFPrediction.Model.DataModels;


namespace PFPrediction.App
{
    public class PFPrediction
    {
        //Machine Learning model to load and use for predictions
        private static string MODEL_FILEPATH = Path.GetFullPath(@"..\..\MLPredictions\PFPred\PFPrediction.Model\MLModel.zip");

        //Dataset to use for predictions 
        private string DATA_FILEPATH = Path.GetFullPath(@"..\..\MLPredictions\PFPred\PFPredictionData.csv");

        public static float GetPFPrediction(ModelInput sampleData)
        {
            MLContext mlContext = new MLContext();

            // Training code used by ML.NET CLI and AutoML to generate the model
            //ModelBuilder.CreateModel();

            ITransformer mlModel = mlContext.Model.Load(GetAbsolutePath(MODEL_FILEPATH), out DataViewSchema inputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            // Create sample data to do a single prediction with it 
            //ModelInput sampleData = CreateSingleDataSample(mlContext, DATA_FILEPATH);
            //ModelInput sampleData = new ModelInput()
            //{
            //    NrPS1 = 1,
            //    NrPSM1 = 0,
            //    NrPSA1 = 0,
            //    NrPCA1 = 0,
            //    NrPC1 = 4,
            //    //NFS1 = 10,
            //    //NPS1 = 0,
            //    //NPC1 = 1.01f,
            //    NET1 = 7.6f,
            //    NL1 = 5,
            //    NrPS2 = 7,
            //    NrPSM2 = 1,
            //    NrPSA2 = 0,
            //    NrPCA2 = 0,
            //    NrPC2 = 7,
            //    //NFS2 = 10,
            //    //NPS2 = 2.17f,
            //    //NPC2 = 1.88f,
            //    NET2 = 7.7f,
            //    NL2 = 4,
            //    BS = 2.0f
            //};


            // Try a single prediction
            ModelOutput predictionResult = predEngine.Predict(sampleData);

            //Console.WriteLine($"Single Prediction --> Actual value: {sampleData.PF} | Predicted value: {predictionResult.Score}");

            //Console.WriteLine("=============== End of process, hit any key to finish ===============");
            //Console.ReadKey();
            //ModelBuilder.CreateModel();
            return predictionResult.Score;
        }

        // Method to load single row of data to try a single prediction
        // You can change this code and create your own sample data here (Hardcoded or from any source)
        private static ModelInput CreateSingleDataSample(MLContext mlContext, string dataFilePath)
        {
            // Read dataset to get a single row for trying a prediction          
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: dataFilePath,
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Here (ModelInput object) you could provide new test data, hardcoded or from the end-user application, instead of the row from the file.
            ModelInput sampleForPrediction = mlContext.Data.CreateEnumerable<ModelInput>(dataView, false)
                                                                        .First();
            return sampleForPrediction;
        }

        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(PFPrediction).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
    }
}
