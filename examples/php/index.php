<?php

function loadLocations()
{
    $jsonPath = __DIR__ . '/../../provincias.json';

    if (!file_exists($jsonPath)) {
        die("Error: No se encontró el archivo provincias.json");
    }

    $json = file_get_contents($jsonPath);
    return json_decode($json, true);
}

echo "--- Cargando Datos de Ecuador ---\n";
$data = loadLocations();

if ($data) {
    echo "Se encontraron " . count($data) . " provincias:\n";

    foreach ($data as $id => $info) {
        echo "- " . $info['provincia'] . " (ID: $id)\n";
    }

    // Ejemplo: Acceder a Pichincha (usualmente ID 17, chequeamos si existe)
    // Nota: Los IDs pueden variar según tu JSON, aquí usamos el 1 como ejemplo seguro
    if (isset($data['1'])) {
        echo "\n--- Detalle de la Provincia ID 1 ---\n";
        $prov = $data['1'];
        echo "Nombre: " . $prov['provincia'] . "\n";
        echo "Número de Cantones: " . count($prov['cantones']) . "\n";
    }
}
?>