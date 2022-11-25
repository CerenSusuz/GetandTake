namespace GetandTake.Core.CrossCuttingConcerns.Caching;

public interface ICacheService
{
    T Get<T>(string key);
    void Add<T>(string key, T value, int duration);
    bool IsAdded(string key);
    void Remove(string key);
    void RemoveByPattern(string pattern);
}