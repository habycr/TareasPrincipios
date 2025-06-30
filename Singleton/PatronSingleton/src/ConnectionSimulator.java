/**
 * Simulador de conexiones que utiliza parámetros de configuración.
 */
public class ConnectionSimulator {
    private final ConfigurationManager configManager;

    public ConnectionSimulator() {
        this.configManager = ConfigurationManager.getInstance();
    }

    public void runSimulation() {
        int maxConnections = ((Number) configManager.getConfigValue("maxConnections")).intValue();
        boolean enableLogs = (boolean) configManager.getConfigValue("enableLogs");
        String defaultCurrency = (String) configManager.getConfigValue("defaultCurrency");

        System.out.println("\n=== SIMULADOR DE CONEXIONES ===");
        System.out.println("Moneda por defecto: " + defaultCurrency);
        System.out.println("Intentando establecer " + maxConnections + " conexiones...\n");

        for (int i = 1; i <= maxConnections; i++) {
            try {
                // Simular tiempo de conexión
                Thread.sleep(500);

                if (enableLogs) {
                    System.out.println("Conexión #" + i + " establecida con éxito.");
                }
            } catch (InterruptedException e) {
                if (enableLogs) {
                    System.out.println("Error en conexión #" + i + ": " + e.getMessage());
                }
            }
        }

        System.out.println("\nSimulación completada. Total de conexiones: " + maxConnections);
        System.out.println("==================================\n");
    }
}