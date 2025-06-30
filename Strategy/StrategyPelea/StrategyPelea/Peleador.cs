using System.Collections.Generic;

public class Peleador
{
    public string Nombre { get; }
    public int Vida { get; private set; } = 200;
    public List<IEstrategia> Estrategias { get; }
    public List<string> Bitacora { get; }

    public Peleador(string nombre, List<IEstrategia> estrategias)
    {
        Nombre = nombre;
        Estrategias = estrategias;
        Bitacora = new List<string>();
    }

    public void ReasignarEstrategias(List<IEstrategia> nuevas)
    {
        Estrategias.Clear();
        Estrategias.AddRange(nuevas);
        Bitacora.Add($"{Nombre} ha reasignado sus artes marciales.");
    }

    public void Atacar(Peleador oponente, bool elegirAleatoria = true, int indiceManual = 0)
    {
        IEstrategia estrategia = elegirAleatoria
            ? Estrategias[new Random().Next(Estrategias.Count)]
            : Estrategias[indiceManual];

        estrategia.EjecutarCombo(this, oponente, Bitacora);
    }

    public void RecibirDanio(int cantidad)
    {
        Vida -= cantidad;
    }

    public void Curar(int cantidad)
    {
        Vida += cantidad;
    }
}
