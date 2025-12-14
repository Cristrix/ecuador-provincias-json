use serde::Deserialize;
use std::collections::HashMap;
use std::fs;
use std::path::Path;

#[derive(Deserialize, Debug)]
struct Parroquia(HashMap<String, String>); // Las parroquias son un mapa ID -> Nombre

#[derive(Deserialize, Debug)]
struct Canton {
    canton: String,
    // parroquias: HashMap<String, String>, // Simplificado
}

#[derive(Deserialize, Debug)]
struct Provincia {
    provincia: String,
    cantones: HashMap<String, Canton>,
}

fn main() {
    println!("--- Cargando Datos de Ecuador (Rust) ---");

    // Ruta al JSON
    let path = Path::new("../../provincias.json");
    
    match fs::read_to_string(path) {
        Ok(data) => {
            let provincias: HashMap<String, Provincia> = serde_json::from_str(&data).expect("Error parseando JSON");
            
            println!("Se encontraron {} provincias:", provincias.len());
            
            // Iterar
            for (id, p) in &provincias {
                println!("- {} (ID: {})", p.provincia, id);
            }
            
            if let Some(azuay) = provincias.get("1") {
                println!("\n--- Detalle de Azuay ---");
                println!("Cantones: {}", azuay.cantones.len());
            }
        },
        Err(e) => println!("Error leyendo archivo: {}", e),
    }
}
