namespace queensnxn
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var size = 15;
            var heuristic = new HeuristicAlgorithm();
            heuristic.RunAlgorithm(size);
        }
    }
}