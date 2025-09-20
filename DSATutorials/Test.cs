//using Microsoft.Azure.Cosmos;

//public class Solution
//{

//    public async Task<string> GetPorScenarioAsync(
//           string scenarioType,
//           string cycle = null)
//    {

//        var query =
//            "SELECT TOP 1 * FROM c " +
//            "WHERE c.scenarioType = @scenarioType " +
//            "AND c.isPor = true " +
//            (string.IsNullOrEmpty(cycle) ? "" : "AND c.cycle = @cycle ") +
//            "ORDER BY c.createdAt DESC";

//        var queryDefinition = new QueryDefinition(query)
//            .WithParameter("@scenarioType", scenarioType);

//        if (!string.IsNullOrEmpty(cycle))
//        {
//            queryDefinition = queryDefinition.WithParameter("@cycle", cycle);
//        }

//        return null;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        s.GetPorScenarioAsync("XYX","Sample" );
//    }
//}