# Sistema de Gestión de Configuración

## Descripción
Este proyecto implementa un sistema completo de gestión de configuración en Java que permite administrar parámetros del sistema de forma persistente mediante archivos JSON. El sistema incluye funcionalidades como simulación de conexiones, pantalla de bienvenida personalizable y soporte para múltiples temas visuales.

## Características Principales

###  Gestión de Configuración
- **Persistencia**: Configuración guardada en archivo JSON (`config.json`)
- **Patrón Singleton**: Garantiza una única instancia del gestor de configuración
- **Valores por defecto**: Configuración inicial predefinida en caso de archivos faltantes
- **Actualización dinámica**: Cambios reflejados inmediatamente en el sistema

###  Interfaz de Usuario
- **Temas visuales**: Soporte para tema claro (`light`) y oscuro (`dark`)
- **Colores ANSI**: Interfaz colorizada en consola
- **Menú interactivo**: Navegación intuitiva por opciones numeradas
- **Conversión de moneda**: Transformación automática entre CRC y USD

###  Simulador de Conexiones
- **Conexiones configurables**: Número máximo definido por configuración
- **Logging opcional**: Sistema de logs activable/desactivable
- **Simulación realista**: Delays para simular conexiones reales

## Estructura del Proyecto

```
src/
├── Main.java                    # Clase principal con menú interactivo
├── ConfigurationManager.java    # Gestor singleton de configuración
├── ConfigurationLoader.java     # Cargador/guardador de JSON
├── WelcomeScreen.java          # Pantalla de bienvenida personalizable
├── ConnectionSimulator.java    # Simulador de conexiones
└── ConsoleColors.java          # Constantes de colores ANSI
```

## Parámetros de Configuración

| Parámetro | Tipo | Valores Posibles | Descripción |
|-----------|------|------------------|-------------|
| `defaultCurrency` | String | CRC, USD | Moneda por defecto del sistema |
| `timeFormat` | String | 24H, AM/PM | Formato de visualización de hora |
| `maxConnections` | Integer | 1-999 | Máximo número de conexiones simuladas |
| `language` | String | ES, EN | Idioma de la interfaz |
| `autoSaveInterval` | Integer | 1-3600 | Intervalo de guardado automático (min/seg) |
| `enableLogs` | Boolean | true/false | Activar/desactivar sistema de logs |
| `theme` | String | light/dark | Tema visual de la interfaz |
| `region` | String | LATAM, Asia, África, Europa, Oceanía | Región geográfica |
| `backupEnabled` | Boolean | true/false | Activar sistema de respaldos |
| `backupDirectory` | String | ruta válida | Directorio para archivos de respaldo |

## Funcionalidades del Menú

### 1. Ver Configuración Actual
Muestra todos los parámetros de configuración con sus valores actuales en formato tabla.

### 2. Cambiar Configuración
Permite modificar cualquier parámetro de configuración con las siguientes características:
- **Validación de entrada**: Verificación de tipos y valores válidos
- **Conversión de moneda**: Cálculo automático al cambiar entre CRC/USD (tasa: 1 USD = 505.17 CRC)
- **Feedback inmediato**: Confirmación de cambios con valores anterior/nuevo

### 3. Panel de Bienvenida
Pantalla personalizada que muestra:
- Mensaje de bienvenida en idioma configurado
- Hora actual en formato seleccionado
- Tema visual activo
- Colores adaptados al tema

### 4. Simulador de Conexiones
Simula conexiones de red con:
- Número configurable de conexiones
- Logs opcionales de progreso
- Información de moneda por defecto
- Delays realistas entre conexiones

### 5. Salir del Sistema
Cierre seguro de la aplicación.

## Patrones de Diseño Implementados

### Singleton (ConfigurationManager)
```java
public static synchronized ConfigurationManager getInstance() {
    if (instance == null) {
        instance = new ConfigurationManager();
    }
    return instance;
}
```
Garantiza una única instancia del gestor de configuración en toda la aplicación.

### Static Helper (ConfigurationLoader)
Proporciona métodos estáticos para operaciones de carga y guardado de configuración sin necesidad de instanciación.

## Dependencias

- **Java 8+**: Características de streams y lambdas
- **org.json.simple**: Librería para manejo de archivos JSON
  ```xml
  <dependency>
      <groupId>com.googlecode.json-simple</groupId>
      <artifactId>json-simple</artifactId>
      <version>1.1.1</version>
  </dependency>
  ```

## Instalación y Ejecución

### Requisitos Previos
- JDK 8 o superior
- Librería json-simple en el classpath

### Pasos de Instalación
1. **Clonar/descargar** el proyecto
2. **Agregar dependencia** json-simple al proyecto
3. **Compilar** todas las clases Java
4. **Ejecutar** la clase Main

### Ejecución
```bash
# Compilación
javac -cp "lib/json-simple-1.1.1.jar" *.java

# Ejecución
java -cp ".:lib/json-simple-1.1.1.jar" Main
```

## Archivo de Configuración (config.json)

El sistema crea automáticamente un archivo `config.json` con la configuración por defecto:

```json
{
  "defaultCurrency": "CRC",
  "timeFormat": "24H",
  "maxConnections": 5,
  "language": "ES",
  "autoSaveInterval": 10,
  "enableLogs": true,
  "theme": "light",
  "region": "LATAM",
  "backupEnabled": false,
  "backupDirectory": "/backups"
}
```

## Características Técnicas

### Manejo de Errores
- **Archivos faltantes**: Carga configuración por defecto
- **JSON malformado**: Recuperación automática con valores predeterminados
- **Entrada inválida**: Validación y mensajes de error descriptivos

### Persistencia de Datos
- **Guardado automático**: Cada cambio se persiste inmediatamente
- **Formato JSON**: Legible y editable manualmente
- **Backup opcional**: Sistema de respaldos configurable

### Interfaz de Usuario
- **Colores adaptativos**: Cambian según el tema seleccionado
- **Reset de colores**: Previene contaminación visual
- **Navegación intuitiva**: Menús numerados y confirmaciones


