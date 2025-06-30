using System;
using System.Collections.Generic;

public class Sambo : IEstrategia
{
    private List<Golpe> golpes = new List<Golpe>
    {
        new Golpe("Derribo ruso", 18),
        new Golpe("Luxación de brazo", 25, danaExtra: true),
        new Golpe("Técnica de sujeción", 10, cura: true)
    };

    public string Nombre => "Sambo";

    public void EjecutarCombo(Peleador atacante, Peleador oponente, List<string> bitacora)
    {
        var rand = new Random();
        int cantidad = rand.Next(3, 7); // Entre 3 y 6 golpes
        for (int i = 0; i < cantidad; i++)
        {
            var golpe = golpes[rand.Next(golpes.Count)];
            int danio = golpe.Poder + (golpe.DanaExtra ? 5 : 0);
            oponente.RecibirDanio(danio);
            if (golpe.Cura)
                atacante.Curar(10);

            bitacora.Add($"{atacante.Nombre} usa {golpe.Nombre} de {Nombre} ({golpe.Poder})"
                         + (golpe.Cura ? " [cura +10]" : "")
                         + (golpe.DanaExtra ? " [daño extra +5]" : ""));
        }
    }
    public List<Golpe> ObtenerGolpes() => golpes;
}
