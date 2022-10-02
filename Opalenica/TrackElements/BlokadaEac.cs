namespace Opalenica;

using CommandProcessor;

using Opalenica.TrackElements.Other;

public class BlokadaEac
{
    public static List<BlokadaEac> RegisteredEac = new List<BlokadaEac>();

    public string Name { get; set; } = "BlokadaEac";

    public BlokadaKierunek Kierunek { get; set; } = BlokadaKierunek.Nieznany;

    public EacData Data { get; set; } = EacData.StanPodstawowy;

    public bool Selected { get; set; }

    public Color ColorA
    {
        get
        {
            return GetColorA(Data, Kierunek);
        }
    }

    public Color ColorB
    {
        get
        {
            return GetColorB(Data, Kierunek);
        }
    }

    public bool PulsingSignalA
    {
        get
        {
            return Data switch
            {
                EacData.Nieprawidłowy when Kierunek is BlokadaKierunek.Neutralny => true,
                EacData.Nieprawidłowy when Kierunek is BlokadaKierunek.Nieznany => true,
                EacData.ZadanieDaniaPozwolenia when Kierunek is BlokadaKierunek.Przyjazd or BlokadaKierunek.Wyjazd => true,
                EacData.AwaryjnaZmianaKierunku when Kierunek is BlokadaKierunek.Przyjazd or BlokadaKierunek.Wyjazd => true,
                _ => false,
            };
        }
    }

    public bool PulsingSignalB
    {
        get
        {
            return Data switch
            {
                EacData.Nieprawidłowy when Kierunek is BlokadaKierunek.Neutralny => true,
                EacData.Nieprawidłowy when Kierunek is BlokadaKierunek.Nieznany => true,
                EacData.AwaryjnaZmianaKierunku when Kierunek is BlokadaKierunek.Przyjazd or BlokadaKierunek.Wyjazd => true,
                EacData.ZwalnianieKierunku when Kierunek is BlokadaKierunek.Przyjazd or BlokadaKierunek.Wyjazd => true,
                _ => false,
            };
        }
    }

    public Color SecondPulsingColorA
    {
        get
        {
            return GetColorA(Data, Kierunek, true);
        }
    }

    public Color SecondPulsingColorB
    {
        get
        {
            return GetColorB(Data, Kierunek, true);
        }
    }

    private BlokadaEac()
    {

    }

    public Color GetColorA(EacData data, BlokadaKierunek kierunek, bool pulse = false)
    {
        return kierunek switch
        {
            BlokadaKierunek.Neutralny or BlokadaKierunek.Nieznany => Data switch
            {
                EacData.BrakDanych         => Colors.White,
                EacData.StanPodstawowy     => Colors.Gray,
                EacData.Nieprawidłowy or _ when  pulse => Colors.Red, // Migający
                EacData.Nieprawidłowy or _ when !pulse => Colors.White, // Migający
            },
            BlokadaKierunek.Przyjazd => Data switch
            {
                EacData.ZadanieDaniaPozwolenia when  pulse => Colors.Gray,
                EacData.ZadanieDaniaPozwolenia when !pulse => Colors.Yellow,
                EacData.UstawionyKierunek                  => Colors.Yellow,
                EacData.AwaryjnaZmianaKierunku when  pulse => Colors.Gray,
                EacData.AwaryjnaZmianaKierunku when !pulse => Colors.Red,
                EacData.ZwalnianieKierunku                 => Colors.Yellow,
                _ => Colors.White,
            },
            BlokadaKierunek.Wyjazd => Data switch
            {
                EacData.ZadanieDaniaPozwolenia when  pulse    => Colors.Gray,
                EacData.ZadanieDaniaPozwolenia when !pulse    => Colors.Yellow,
                EacData.UstawionyKierunek                     => Colors.Yellow,
                EacData.UstawionyKierunekZamkniety            => Colors.Pink,
                EacData.AwaryjnaZmianaKierunku when  pulse    => Colors.Gray,
                EacData.AwaryjnaZmianaKierunku when !pulse    => Colors.Red,
                EacData.ZwalnianieKierunku                    => Colors.Yellow,
                _ => Colors.White,
            },
            _ => Colors.White,
        };
    }

    public Color GetColorB(EacData data, BlokadaKierunek kierunek, bool pulse = false)
    {

        return kierunek switch
        {
            BlokadaKierunek.Neutralny or BlokadaKierunek.Nieznany => Data switch
            {
                EacData.BrakDanych                     => Colors.White,
                EacData.StanPodstawowy                 => Colors.Gray,
                EacData.Nieprawidłowy or _ when pulse  => Colors.Red, // Migający
                EacData.Nieprawidłowy or _ when !pulse => Colors.White, // Migający
            },
            BlokadaKierunek.Przyjazd => Data switch
            {
                EacData.ZadanieDaniaPozwolenia             => Colors.Yellow,
                EacData.UstawionyKierunek                  => Colors.Yellow,
                EacData.AwaryjnaZmianaKierunku when pulse  => Colors.Gray,
                EacData.AwaryjnaZmianaKierunku when !pulse => Colors.Red,
                EacData.ZwalnianieKierunku when pulse      => Colors.Gray,
                EacData.ZwalnianieKierunku when !pulse     => Colors.Yellow,
                _ => Colors.White,
            },
            BlokadaKierunek.Wyjazd => Data switch
            {
                EacData.ZadanieDaniaPozwolenia             => Colors.Yellow,
                EacData.UstawionyKierunek                  => Colors.Yellow,
                EacData.UstawionyKierunekZamkniety         => Colors.Pink,
                EacData.AwaryjnaZmianaKierunku when pulse  => Colors.Gray,
                EacData.AwaryjnaZmianaKierunku when !pulse => Colors.Red,
                EacData.ZwalnianieKierunku when pulse      => Colors.Gray,
                EacData.ZwalnianieKierunku when !pulse     => Colors.Yellow,
                _ => Colors.White,
            },
            _ => Colors.White,
        };
    }

    public static BlokadaEac GetEac(string name)
    {
        var blokada = RegisteredEac.FirstOrDefault(e => e.Name == name, null);
        if (blokada is not null) return blokada;

        blokada = new BlokadaEac();
        blokada.Name = name;
        RegisteredEac.Add(blokada);

        ChainedCommand chain = new ChainedCommand(blokada.Name, (CommandContext context) =>
        {
            if (context.Args is null || context.Args.Length != 1) return false;
            string blokadaCommand = (context.GetArgAs<string>(0) ?? "").ToLower();
            switch (blokadaCommand)
            {
                case "wbl":
                    if (blokada.Data is EacData.UstawionyKierunekZamkniety)
                    {
                        blokada.Data = EacData.UstawionyKierunek;
                    }
                    else if (blokada.Data is EacData.StanPodstawowy)
                    {
                        blokada.Kierunek = BlokadaKierunek.Wyjazd;
                        blokada.Data = EacData.ZadanieDaniaPozwolenia;
                    }
                    blokada.Selected = false;
                    return CommandProcessor.BreakChainCommand();

                case "owbl":
                    if (blokada.Kierunek == BlokadaKierunek.Wyjazd && blokada.Data == EacData.ZadanieDaniaPozwolenia)
                    {
                        blokada.Kierunek = BlokadaKierunek.Neutralny;
                        blokada.Data = EacData.StanPodstawowy;
                    }
                    blokada.Selected = false;
                    return CommandProcessor.BreakChainCommand();

                case "pzk":
                    if (blokada.Kierunek == BlokadaKierunek.Przyjazd && blokada.Data == EacData.ZadanieDaniaPozwolenia)
                    {
                        blokada.Kierunek = BlokadaKierunek.Przyjazd;
                        blokada.Data = EacData.UstawionyKierunek;
                    }
                    blokada.Selected = false;
                    return CommandProcessor.BreakChainCommand();

                case "zwbl":
                    if (blokada.Kierunek == BlokadaKierunek.Przyjazd && blokada.Data == EacData.UstawionyKierunek)
                    {
                        blokada.Data = EacData.StanPodstawowy;
                        blokada.Kierunek = BlokadaKierunek.Neutralny;
                    }
                    blokada.Selected = false;
                    return CommandProcessor.BreakChainCommand();

                case "stop":
                    if (blokada.Kierunek == BlokadaKierunek.Wyjazd && blokada.Data == EacData.UstawionyKierunek)
                    {
                        blokada.Data = EacData.UstawionyKierunekZamkniety;
                    }
                    blokada.Selected = false;
                    return CommandProcessor.BreakChainCommand();

                case "azk":
                    blokada.Selected = true;
                    return true;
            }
            return false;
        });

        Command command = new Command(blokada.Name, (context) => {
            if (context is not null and ChainedCommandContext ccc && ccc.Args.Length == 0)
            {
                if (ccc.PrevArgs.Length == 1 && (ccc.GetPrevArgAs<string>(0) ?? "").ToLower() == "azk" && blokada.Kierunek == BlokadaKierunek.Przyjazd && blokada.Data == EacData.UstawionyKierunek)
                {
                    blokada.Kierunek = BlokadaKierunek.Wyjazd;
                    blokada.Data = EacData.UstawionyKierunekZamkniety;
                    return true;
                }
            }
            return false;
        });
        return blokada;
    }
}
