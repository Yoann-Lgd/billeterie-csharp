namespace Billetterie.Utils
{
    public static class ConverterList
    {
        public static Dictionary<int, T> ConvertListToDictionary<T>(List<T> list)
        {
            Dictionary<int, T> dictionary = new();
            for (int i = 0; i < list.Count; i++)
            {
                dictionary.Add(i + 1, list[i]);
            }
            return dictionary;
        }
    }
}