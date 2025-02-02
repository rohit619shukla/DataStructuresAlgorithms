//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//class Program
//{
//    public const string MEIORegionalLeadTimeOutput = "MEIORegionalLeadTimeOutput";
//    static void Main(string[] args)
//    {
            //var overrideTargetUtil = 1 / (1 + 0.24441425081518164);

            //var result = ((1 - 0.803590926) / 0.803590926);
//        string datalocation = "https://jaynadatalakeprod.dfs.core.windows.net/capacity-planning/teams/Mantis/mantispublish/capacityplanning/datasets/MEIORegionalLeadTimeOutput/2025/1/22/20250122074632/6fc77a0e-e741-4e5b-870f-40804468b09e/LT_FlightTest_22_01_2025_02.csv";


//        string result = "peaktoaveragesolver-peaktoaverage-20250108";
//        string str1 = "SEIoCycleTimeAutomationSolver-leadtime-20250102";
//        string str2 = "MeioRegionalLeadTimeInputV2-MeioRegionalLeadTimeInputV2-20250102";

//        var result1 = str1.Length;
//        var result2 = str2.Length;

//        // Specify the paths to the two files
//        string filePath1 = "C:\\Work\\General\\PeakToAvgByRegion_PeakToAvgByRegion-2024-10-21-08-24-14b9ebea70-b.csv";
//        string filePath2 = "C:\\Work\\General\\PeakToAvgByRegion_PeakToAvgByRegion-2024-10-22-07-54-00edd42a48-f.csv";

//        string outputFilePath = "C:\\Work\\General\\differences.txt";

//        // Read the lines from both files and store them in sets for easy comparison
//        HashSet<string> file1Rows = new HashSet<string>(File.ReadLines(filePath1));
//        HashSet<string> file2Rows = new HashSet<string>(File.ReadLines(filePath2));

//        // Find rows present in file1 but missing in file2
//        var missingInFile2 = file1Rows.Except(file2Rows).ToList();

//        // Find rows present in file2 but missing in file1
//        var missingInFile1 = file2Rows.Except(file1Rows).ToList();

//        // Write the differences to the output file
//        using (StreamWriter writer = new StreamWriter(outputFilePath))
//        {
//            // Write rows missing in file2
//            writer.WriteLine("Rows in file1 but missing in file2:");
//            writer.WriteLine($"Count is {missingInFile2.Count}");
//            //foreach (var row in missingInFile2)
//            //{
//            //    writer.WriteLine(row);
//            //}

//            writer.WriteLine();  // Add a blank line between sections

//            // Write rows missing in file1
//            writer.WriteLine("Rows in file2 but missing in file1:");
//            writer.WriteLine($"Count is {missingInFile1.Count}");
//            //foreach (var row in missingInFile1)
//            //{
//            //    writer.WriteLine(row);
//            //}
//        }

//        Console.WriteLine($"Differences have been written to: {outputFilePath}");
//    }
//}
