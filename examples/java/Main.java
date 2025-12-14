
import java.nio.file.Files;
import java.nio.file.Paths;
import java.io.IOException;

public class Main {
    public static void main(String[] args) {
        System.out.println("--- Cargando Datos de Ecuador (Java) ---");
        
        // Ruta al archivo JSON (subiendo dos niveles desde examples/java)
        String filePath = "../../provincias.json";
        
        try {
            // Leer el contenido del archivo como String
            String content = new String(Files.readAllBytes(Paths.get(filePath)));
            
            System.out.println("Archivo leído exitosamente.");
            System.out.println("Tamaño del archivo: " + content.length() + " bytes");
            
            // Nota: Para parsear JSON en Java, se recomienda usar bibliotecas como Jackson o Gson.
            // Aquí solo demostramos la lectura del archivo para no requerir dependencias externas.
            
        } catch (IOException e) {
            System.out.println("Error leyendo el archivo: " + e.getMessage());
            e.printStackTrace();
        }
    }
}
