import java.util.Map;
import java.util.HashMap;

public class ConfigurationManager {
    private static ConfigurationManager instance;
    private Map<String, Object> config;

    private ConfigurationManager() {
        config = ConfigurationLoader.loadConfig();
    }

    public static synchronized ConfigurationManager getInstance() {
        if (instance == null) {
            instance = new ConfigurationManager();
        }
        return instance;
    }

    public Object getConfigValue(String key) {
        return config.get(key);
    }

    public void setConfigValue(String key, Object value) {
        Object oldValue = config.get(key);
        config.put(key, value);
        System.out.printf("[ConfigManager] '%s' actualizado: %s → %s\n", key, oldValue, value);
        ConfigurationLoader.saveConfig(config);
    }

    public Map<String, Object> getAllConfig() {
        return new HashMap<>(config);
    }
}