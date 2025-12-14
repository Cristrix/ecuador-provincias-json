package main

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"os"
	"path/filepath"
)

// Estructuras para mapear el JSON
type Parroquias map[string]string

type Canton struct {
	Canton     string     `json:"canton"`
	Parroquias Parroquias `json:"parroquias"`
}

type Cantones map[string]Canton

type Provincia struct {
	Provincia string   `json:"provincia"`
	Cantones  Cantones `json:"cantones"`
}

type EcuadorData map[string]Provincia

func main() {
	fmt.Println("--- Cargando Datos de Ecuador ---")

	// Obtener ruta del archivo
	ex, err := os.Executable()
	if err != nil {
		panic(err)
	}
	exPath := filepath.Dir(ex)
	// Nota: Al correr con 'go run', el path puede variar. 
	// Asumimos que provincias.json está en el directorio superior.
	jsonFile, err := os.Open("../../provincias.json")
	if err != nil {
		fmt.Println("Error abriendo el archivo:", err)
		return
	}
	defer jsonFile.Close()

	byteValue, _ := ioutil.ReadAll(jsonFile)

	var data EcuadorData
	json.Unmarshal(byteValue, &data)

	fmt.Printf("Se encontraron %d provincias:\n", len(data))

	// Iterar e imprimir (el orden en mapas de Go no es garantizado)
	for id, p := range data {
		fmt.Printf("- %s (ID: %s)\n", p.Provincia, id)
	}

	// Ejemplo de acceso directo
	if val, ok := data["1"]; ok {
		fmt.Println("\n--- Detalle de Provincia ID 1 ---")
		fmt.Printf("Nombre: %s\n", val.Provincia)
		fmt.Printf("Cantones: %d\n", len(val.Cantones))
	}
}
