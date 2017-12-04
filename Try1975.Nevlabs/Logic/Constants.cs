namespace Try1975.Nevlabs.Logic
{
    public static class Constants
    {
        private const string Prefix = "";

        public static string CreateTableName(string datasetName)
        {
            return $"{Prefix}{datasetName}";
        }

    }
}