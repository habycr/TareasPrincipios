public class Golpe
{
    public string Nombre { get; }
    public int Poder { get; }
    public bool Cura { get; }
    public bool DanaExtra { get; }

    public Golpe(string nombre, int poder, bool cura = false, bool danaExtra = false)
    {
        Nombre = nombre;
        Poder = poder;
        Cura = cura;
        DanaExtra = danaExtra;
    }
}
