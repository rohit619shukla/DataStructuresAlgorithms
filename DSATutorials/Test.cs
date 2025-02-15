//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;
//using System.Text.RegularExpressions;
//using System.Formats.Asn1;
//using System.Globalization;
//using CsvHelper.Configuration;
//using CsvHelper;

//public class MTFSDFEStorage
//{
//    public string Scenario { get; set; }
//    public string ResourceType { get; set; }
//    public string ResourceUnit { get; set; }
//    public string Region { get; set; }
//    public string AvailabilityZoneCode { get; set; }
//    public string AvailabilityZoneType { get; set; }
//    public string Segment { get; set; }
//    public float Mean { get; set; }
//    public double Stdev { get; set; }
//    public DateTime Date { get; set; }
//    public int Horizon { get; set; }
//}


//public class MTFSDFECompute
//{
//    public string Scenario { get; set; }
//    public string ResourceType { get; set; }
//    public string ResourceUnit { get; set; }
//    public string Region { get; set; }
//    public string AvailabilityZoneCode { get; set; }
//    public string AvailabilityZoneType { get; set; }
//    public string Segment { get; set; }
//    public float Mean { get; set; }
//    public double Stdev { get; set; }
//    public DateTime Date { get; set; }
//    public int Horizon { get; set; }

//}


//class Sample
//{
//    public static string CombineCsvData(string computeCsvData, string storageCsvData)
//    {
//        // Find the index of the first newline character in the storage CSV data
//        storageCsvData = storageCsvData ?? string.Empty;
//        var storageListData = ConvertCsvToObjectListWithoutId<MTFSDFEStorage>(storageCsvData);
//        var computeListData = ConvertCsvToObjectListWithoutId<MTFSDFECompute>(computeCsvData);
//        var storageCsvString = ConvertToCsvString<MTFSDFEStorage>(storageListData);
//        var computeCsvString = ConvertToCsvString<MTFSDFECompute>(computeListData);
//        int newIndex = storageCsvString.IndexOf('\n');
//        if (newIndex != -1)
//        {
//            // Skip the header of the second CSV data
//            storageCsvString = storageCsvString.Substring(newIndex + 1);
//        }

//        // Concatenate the compute and storage CSV data
//        return computeCsvString + storageCsvString;
//    }

//    public static string ConvertToCsvString<T>(IEnumerable<T> data, bool ShouldQuote = true)
//    {
//        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
//        {
//            ShouldQuote = args => ShouldQuote
//        };

//        using (var writer = new StringWriter())
//        {
//            using (var csv = new CsvWriter(writer, config))
//            {
//                csv.WriteRecords(data);
//                writer.Flush();
//                var output = writer.ToString();
//                return output;
//            }
//        }
//    }

//    /// <summary>
//    /// Helper to convert csv to List
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    /// <param name="csvString"></param>
//    /// <returns>generic list object</returns>
//    private static List<T> ConvertCsvToObjectListWithoutId<T>(string csvString)
//    {
//        var result = new List<T>();
//        if (string.IsNullOrEmpty(csvString))
//        {
//            return result;
//        }

//        var stringReader = new StringReader(csvString);
//        string line = stringReader.ReadLine();
//        line = line.Replace("\"", string.Empty);
//        var headers = line.Split(',');

//        for (var i = 0; i < headers.Length; i++)
//        {
//            headers[i] = Regex.Replace(headers[i], "[ ]{2,}", "_");
//        }
//        while ((line = stringReader.ReadLine()) != null)
//        {
//            var value = line.Split(',');
//            var jobect = new JObject();
//            for (var i = 0; i < headers.Length; i++)
//            {
//                if (headers[i] == "Id")
//                {
//                    continue;
//                }
//                value[i] = value[i].Replace("\"", string.Empty);
//                if (value[i] == "NULL")
//                {
//                    value[i] = null;
//                }
//                jobect.Add(new JProperty(headers[i], value[i]));
//            }
//            result.Add(JsonConvert.DeserializeObject<T>(
//                JsonConvert.SerializeObject(jobect), new JsonSerializerSettings()
//                {
//                    NullValueHandling = NullValueHandling.Ignore
//                }));
//        }
//        return result;
//    }
//}
//class Program
//{
//    public static void Main()
//    {

//        string computePath = "C:\\Work\\MTFSDFECompute_2024_12_Azure_DF_Demand_V1_ComputeSDFE.csv"; // Update with your file path
//        string computeData = File.ReadAllText(computePath); //

//        string storagePath = "C:\\Work\\MTFSDFEStorage_02-02-2024-14-42-MTFSDFEStorage-harinibaddam 1.csv"; // Update with your file path
//        string storageData = File.ReadAllText(storagePath); //





//        var result = Sample.CombineCsvData(computeData, storageData);

//        string mergedpath = "C:\\Work\\MTFSDFEMerged.csv";

//        File.WriteAllText(mergedpath, result); // Write the string to a CSV file
//    }
//}