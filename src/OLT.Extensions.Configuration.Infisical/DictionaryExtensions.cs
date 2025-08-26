namespace OLT.Extensions.Configuration.Infisical;

internal static class DictionaryExtensions
{
    public static bool EquivalentTo<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second) => EquivalentTo(first, second, null);

    public static bool EquivalentTo<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second, IEqualityComparer<TValue>? valueComparer)
    {
        if (first == second) return true;
        if (first == null || second == null) return false;
        if (first.Count != second.Count) return false;

        valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;

        foreach (var kvp in first)
        {
            if (!second.TryGetValue(kvp.Key, out var secondValue)) return false;
            if (!valueComparer.Equals(kvp.Value, secondValue)) return false;
        }
        return true;
    }
}
