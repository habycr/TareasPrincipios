using System;
using System.Collections.Generic;

public class Karate : IEstrategia
{
    private List<Golpe> golpes = new List<Golpe>
    {
        new Golpe("Mae Geri", 10),
        new Golpe("Yoko Geri", 5, cura: true),
        new Golpe("Mawashi Geri", 30)
    };

    public string Nombre => "Karate";

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
