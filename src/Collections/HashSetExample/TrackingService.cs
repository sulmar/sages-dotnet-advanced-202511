namespace HashSetExample;

internal class TrackingService
{
    private HashSet<string> _tracks = [];

    public void Request(string ipAddress)
    {        
        _tracks.Add(ipAddress);
    }

    public IEnumerable<string> GetUniqueIPs()
    {
        return _tracks;
    }

    public void Contains(string ipAddress)
    {
        _tracks.Contains(ipAddress);
    }


}
