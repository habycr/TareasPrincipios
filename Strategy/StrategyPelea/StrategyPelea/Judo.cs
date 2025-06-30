using System;
using System.Collections.Generic;

public class Judo : IEstrategia
{
    private List<Golpe> golpes = new List<Golpe>
    {
        new Golpe("Tai-Otoshi", 8),
        new Golpe("Koshi-Guruma", 20),
        new Golpe("Osoto-Gari", 13, cura: true)
    };

    public string Nombre => "Judo";

    public void EjecutarCombo(Peleador atacante, Peleador oponente, List<string> bitacora)
    {
        var rand = new Random();
        int cantidad = rand.Next(3, 7);
        for (int i = 0; i < cantidad; i++)
        {
            var golpe = golpes[rand.Next(golpes.Count)];
            int danio = golpe.Poder + (golpe.DanaExtra ? 5 : 0);
            oponente.RecibirDanio(danio);
            if (golpe.Cura) atacante.Curar(10);

            bitacora.Add($"{atacante.Nombre} usa {golpe.Nombre} de {Nombre} ({golpe.Poder})"
                        + (golpe.Cura ? " [cura +10]" : "")
                        + (golpe.DanaExtra ? " [daño extra +5]" : ""));
        }
    }
    public List<Golpe> ObtenerGolpes() => golpes;
}
