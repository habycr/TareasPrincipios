public interface IEstrategia
{
    string Nombre { get; }

    void EjecutarCombo(Peleador atacante, Peleador oponente, List<string> bitacora);

    List<Golpe> ObtenerGolpes(); // <- NECESARIO para acceder a los golpes
}
