public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public string Type { get; set; }
    public EarthQuakeMetaData MetaData { get; set; }
    public List<Feature> Features { get; set; }
}


// EARTHQUAKE META DATA
public class EarthQuakeMetaData
{
    public long Generated { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
    public string Api { get; set; }
    public int Count { get; set; }
}

// EACH EARTH QUAKE FEATURE DETAILS
public class Feature
{
    public string Type { get; set; }
    public EarthQuakeProperties Properties { get; set; }
    public Geometry Geometry { get; set; }
    public string Id { get; set; }
}

public class EarthQuakeProperties
{
    public double? Mag { get; set; }
    public string Place { get; set; }
    public long Time { get; set; }
    public long Updated { get; set; }
    public int? Tz { get; set; }
    public string Url { get; set; }
    public string Detail { get; set; }
    public int? Felt { get; set; }
    public double? Cdi { get; set; }
    public double? Mmi { get; set; }
    public string Alert { get; set; }
    public string Status { get; set; }
    public int Tsunami { get; set; }
    public int Sig { get; set; }
    public string Net { get; set; }
    public string Code { get; set; }
    public string Ids { get; set; }
    public string Sources { get; set; }
    public string Types { get; set; }
    public int? Nst { get; set; }
    public double? Dmin { get; set; }
    public double? Rms { get; set; }
    public double? Gap { get; set; }
    public string MagType { get; set; }
    public string EarthquakeType { get; set; }
    public string Title { get; set; }
}

public class Geometry
{
    public string Type { get; set; }
    public List<double> Coordinates { get; set; }
}

