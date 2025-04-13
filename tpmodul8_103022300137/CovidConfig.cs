using System.IO;
using System.Text.Json;

public class CovidConfig
{
    public string satuan_suhu { get; set; } = "celcius";
    public int batas_hari_demam { get; set; } = 14;
    public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
    public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

    public static CovidConfig LoadFromFile(string path)
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<CovidConfig>(json);
        }
        return new CovidConfig();
    }

    public void UbahSatuan()
    {
        satuan_suhu = satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
    }
}
