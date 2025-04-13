using System;

class Program
{
    static void Main()
    {
        string configPath = "covid_config.json";
        CovidConfig config = CovidConfig.LoadFromFile(configPath);

        Console.WriteLine($"Satuan suhu saat ini adalah: {config.satuan_suhu}");
        Console.Write("Apakah anda ingin mengubah satuan suhu? (Y/N): ");
        string input = Console.ReadLine().ToLower();
        if (input == "y" || input == "yes")
        {
            config.UbahSatuan();
        }

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = Convert.ToInt32(Console.ReadLine());



        bool suhuValid = false;
        if (config.satuan_suhu == "celcius")
        {
            suhuValid = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            suhuValid = suhu >= 97.7 && suhu <= 99.5;
        }

        bool hariValid = hari < config.batas_hari_demam;

        if (suhuValid && hariValid)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}
