import java.io.*;
import java.util.HashMap;
import java.util.Map;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

/**
 * Clase auxiliar para cargar y guardar la configuración desde/hacia un archivo JSON.
 */
public class ConfigurationLoader {
    private static final String CONFIG_FILE = "config.json";
    private static final Map<String, Object> DEFAULT_CONFIG = createDefaultConfig();

    private static Map<String, Object> createDefaultConfig() {
        Map<String, Object> defaultConfig = new HashMap<>();
        defaultConfig.put("defaultCurrency", "CRC");
        defaultConfig.put("timeFormat", "24H");
        defaultConfig.put("maxConnections", 5);
        defaultConfig.put("language", "ES");
        defaultConfig.put("autoSaveInterval", 10);
        defaultConfig.put("enableLogs", true);
        defaultConfig.put("theme", "light");
        defaultConfig.put("region", "LATAM");
        defaultConfig.put("backupEnabled", false);
        defaultConfig.put("backupDirectory", "/backups");
        return defaultConfig;
    }

    /**
     * Carga la configuración desde el archivo JSON.
     * Si el archivo no existe o hay un error, retorna la configuración por defecto.
     */
    public static Map<String, Object> loadConfig() {
        JSONParser parser = new JSONParser();

        try (FileReader reader = new FileReader(CONFIG_FILE)) {
            JSONObject jsonObject = (JSONObject) parser.parse(reader);
            Map<String, Object> config = new HashMap<>();

            // Copiamos todos los valores del JSON al mapa
            for (Object key : jsonObject.keySet()) {
                config.put((String) key, jsonObject.get(key));
            }

            return config;
        } catch (IOException | ParseException e) {
            System.out.println("Error al cargar configuración. Usando valores por defecto.");
            return new HashMap<>(DEFAULT_CONFIG);
        }
    }

    /**
     * Guarda la configuración actual en el archivo JSON.
     */
    public static void saveConfig(Map<String, Object> config) {
        JSONObject jsonObject = new JSONObject();
        jsonObject.putAll(config);

        try (FileWriter file = new FileWriter(CONFIG_FILE)) {
            file.write(jsonObject.toJSONString());
            file.flush();
        } catch (IOException e) {
            System.out.println("Error al guardar configuración: " + e.getMessage());
        }
    }
}