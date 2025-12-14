import json
import os

def load_locations():
    # Obtener la ruta absoluta del archivo JSON
    # Esto asegura que funcione sin importar desde dónde se ejecute el script
    current_dir = os.path.dirname(os.path.abspath(__file__))
    json_path = os.path.join(current_dir, '..', '..', 'provincias.json')
    
    try:
        with open(json_path, 'r', encoding='utf-8') as f:
            data = json.load(f)
        return data
    except FileNotFoundError:
        print(f"Error: No se encontró el archivo en {json_path}")
        return None

def main():
    print("--- Cargando Datos de Ecuador ---")
    data = load_locations()
    
    if data:
        # Ejemplo: Imprimir todas las provincias
        print(f"Se encontraron {len(data)} provincias:")
        for id_prov, info in data.items():
            print(f"- {info['provincia']} (ID: {id_prov})")
            
        # Ejemplo: Acceder a una provincia específica (ej. Azuay - ID 1)
        if '1' in data:
            azuay = data['1']
            print("\n--- Detalle de Azuay ---")
            print(f"Cantones: {len(azuay['cantones'])}")
            first_canton_id = list(azuay['cantones'].keys())[0]
            print(f"Primer Cantón: {azuay['cantones'][first_canton_id]['canton']}")

if __name__ == "__main__":
    main()
