import java.util.Map;
import java.util.Scanner;

public class Main {
    // Códigos ANSI para colores
    private static final String RESET = "\u001B[0m";
    private static final String WHITE = "\u001B[37m";
    private static final String BLUE = "\u001B[34m";

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        ConfigurationManager configManager = ConfigurationManager.getInstance();
        WelcomeScreen welcomeScreen = new WelcomeScreen();
        ConnectionSimulator connectionSimulator = new ConnectionSimulator();

        while (true) {
            // Obtener tema y color actual
            String theme = (String) configManager.getConfigValue("theme");
            String color = theme.equals("dark") ? BLUE : WHITE;

            // Aplicar color al menú
            System.out.print(color);
            System.out.println("=== MENÚ PRINCIPAL ===");
            System.out.println("1. Ver configuración actual");
            System.out.println("2. Cambiar configuración");
            System.out.println("3. Ir al panel de bienvenida");
            System.out.println("4. Ejecutar simulador de conexiones");
            System.out.println("5. Salir del sistema");
            System.out.print("Seleccione una opción: ");
            System.out.print(RESET); // Resetear color después del menú

            int option = scanner.nextInt();
            scanner.nextLine(); // Consumir el salto de línea

            // Resetear color si hay errores
            System.out.print(color);

            switch (option) {
                case 1:
                    showCurrentConfig(configManager);
                    break;
                case 2:
                    changeConfiguration(configManager, scanner);
                    break;
                case 3:
                    welcomeScreen.display();
                    break;
                case 4:
                    connectionSimulator.runSimulation();
                    break;
                case 5:
                    System.out.println("Saliendo del sistema...");
                    System.exit(0);
                    break;
                default:
                    System.out.println("Opción no válida. Intente de nuevo.");
            }
            System.out.print(RESET); // Resetear color al final de cada opción
        }
    }

    private static void showCurrentConfig(ConfigurationManager configManager) {
        String theme = (String) configManager.getConfigValue("theme");
        String color = theme.equals("dark") ? BLUE : WHITE;

        System.out.print(color);
        System.out.println("\n=== CONFIGURACIÓN ACTUAL ===");
        Map<String, Object> config = configManager.getAllConfig();
        for (Map.Entry<String, Object> entry : config.entrySet()) {
            System.out.println(entry.getKey() + ": " + entry.getValue());
        }
        System.out.println("===========================\n");
        System.out.print(RESET);
    }

    private static void changeConfiguration(ConfigurationManager configManager, Scanner scanner) {
        String theme = (String) configManager.getConfigValue("theme");
        String color = theme.equals("dark") ? BLUE : WHITE;

        System.out.print(color);
        System.out.println("\n=== CAMBIAR CONFIGURACIÓN ===");
        System.out.println("Parámetros disponibles:");
        System.out.println("1. defaultCurrency (CRC, USD)");
        System.out.println("2. timeFormat (24H o AM/PM)");
        System.out.println("3. maxConnections (número)");
        System.out.println("4. language (ES, EN)");
        System.out.println("5. autoSaveInterval (minutos, segundos)");
        System.out.println("6. enableLogs (true/false)");
        System.out.println("7. theme (light/dark)");
        System.out.println("8. region (LATAM, Asia, África, Europa, Oceanía)");
        System.out.println("9. backupEnabled (true/false)");
        System.out.println("10. backupDirectory (ruta)");
        System.out.print("Seleccione el parámetro a modificar (1-10): ");
        System.out.print(RESET);

        int paramOption = scanner.nextInt();
        scanner.nextLine(); // Consumir el salto de línea

        String key;
        Object value;
        Object oldValue = configManager.getConfigValue(getKeyFromOption(paramOption));

        System.out.print(color); // Aplicar color a la entrada de datos

        switch (paramOption) {
            case 1:
                key = "defaultCurrency";
                System.out.print("Nueva moneda (CRC, USD): ");
                value = scanner.nextLine().toUpperCase();

                if (!value.equals(oldValue)) {
                    if (value.equals("CRC") || value.equals("USD")) {
                        System.out.print("Digite el valor que desea transformar: ");
                        double amount = scanner.nextDouble();
                        scanner.nextLine(); // Limpiar buffer

                        double convertedAmount;
                        if (oldValue.equals("USD") && value.equals("CRC")) {
                            convertedAmount = amount * 505.17;
                            System.out.printf(">> Conversión: USD %.2f → CRC %.2f\n", amount, convertedAmount);
                        } else if (oldValue.equals("CRC") && value.equals("USD")) {
                            convertedAmount = amount / 505.17;
                            System.out.printf(">> Conversión: CRC %.2f → USD %.2f\n", amount, convertedAmount);
                        }
                    }
                }
                break;
            case 2:
                key = "timeFormat";
                System.out.print("Nuevo formato (24H o AM/PM): ");
                value = scanner.nextLine();
                break;
            case 3:
                key = "maxConnections";
                System.out.print("Nuevo máximo de conexiones: ");
                value = scanner.nextInt();
                scanner.nextLine();
                break;
            case 4:
                key = "language";
                System.out.print("Nuevo idioma (ES, EN): ");
                value = scanner.nextLine();
                break;
            case 5:
                key = "autoSaveInterval";
                System.out.print("Nuevo intervalo (minutos, segundos): ");
                value = scanner.nextInt();
                scanner.nextLine();
                break;
            case 6:
                key = "enableLogs";
                System.out.print("Activar logs (true/false): ");
                value = scanner.nextBoolean();
                scanner.nextLine();
                break;
            case 7:
                key = "theme";
                System.out.print("Nuevo tema (light/dark): ");
                value = scanner.nextLine();
                break;
            case 8:
                key = "region";
                System.out.print("Nueva región (LATAM, Asia, África, Europa, Oceanía): ");
                value = scanner.nextLine();
                break;
            case 9:
                key = "backupEnabled";
                System.out.print("Activar respaldos (true/false): ");
                value = scanner.nextBoolean();
                scanner.nextLine();
                break;
            case 10:
                key = "backupDirectory";
                System.out.print("Nueva ruta de respaldo: ");
                value = scanner.nextLine();
                break;
            default:
                System.out.println("Opción no válida.");
                return;
        }

        // Actualizar configuración y mostrar mensaje
        configManager.setConfigValue(key, value);
        System.out.printf(">> Parámetro '%s' cambiado de '%s' a '%s'.\n", key, oldValue, value);
        System.out.println("Configuración actualizada con éxito.\n");
        System.out.print(RESET);
    }

    private static String getKeyFromOption(int option) {
        switch (option) {
            case 1: return "defaultCurrency";
            case 2: return "timeFormat";
            case 3: return "maxConnections";
            case 4: return "language";
            case 5: return "autoSaveInterval";
            case 6: return "enableLogs";
            case 7: return "theme";
            case 8: return "region";
            case 9: return "backupEnabled";
            case 10: return "backupDirectory";
            default: return "";
        }
    }
}