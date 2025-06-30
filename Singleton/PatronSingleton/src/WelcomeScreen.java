import java.text.SimpleDateFormat;
import java.util.Date;

public class WelcomeScreen {
    private final ConfigurationManager configManager;

    public WelcomeScreen() {
        this.configManager = ConfigurationManager.getInstance();
    }

    public void display() {
        // Obtener tema actual
        String theme = (String) configManager.getConfigValue("theme");
        String color = theme.equals("dark") ? ConsoleColors.BLUE : ConsoleColors.WHITE;

        // Aplicar color al texto
        System.out.print(color); // Cambia el color aquí

        // Resto del código (sin cambios)
        String language = (String) configManager.getConfigValue("language");
        String timeFormat = (String) configManager.getConfigValue("timeFormat");
        String welcomeMessage = language.equals("ES") ?
                "¡Bienvenido al sistema!" : "Welcome to the system!";
        String timePattern = timeFormat.equals("24H") ? "HH:mm:ss" : "hh:mm:ss a";
        String currentTime = new SimpleDateFormat(timePattern).format(new Date());

        System.out.println("\n=== PANEL DE BIENVENIDA ===");
        System.out.println(welcomeMessage);
        System.out.println("Hora actual: " + currentTime);
        System.out.println("Tema: " + theme);
        System.out.println("==========================\n");

        // Resetear color al final
        System.out.print(ConsoleColors.RESET);
    }
}