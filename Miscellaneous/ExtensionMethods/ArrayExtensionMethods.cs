using System;


namespace Webyneter.ComponentsAnalysis.Miscellaneous.ExtensionMethods
{
    public static class ArrayExtensionMethods
    {
        public static void For<TItem>(this TItem[] array, Action<TItem> action)
        {
            int arrayLength = array.Length;
            for (int i = 0; i < arrayLength; ++i)
            {
                action(array[i]);
            }
        }

        public static void ForEach<TItem>(this TItem[] array, Action<TItem> action)
        {
            foreach (var item in array)
            {
                action(item);
            }
        }
    }
}