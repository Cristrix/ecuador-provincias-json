require 'json'

def load_locations
  # Ruta relativa al archivo JSON
  json_path = File.expand_path('../../provincias.json', __FILE__)

  begin
    file = File.read(json_path)
    data = JSON.parse(file)
    return data
  rescue Errno::ENOENT
    puts "Error: No se encontró el archivo en #{json_path}"
    return nil
  end
end

puts "--- Cargando Datos de Ecuador (Ruby) ---"
data = load_locations

if data
  puts "Se encontraron #{data.keys.length} provincias:"
  
  data.each do |id, info|
    puts "- #{info['provincia']} (ID: #{id})"
  end

  # Ejemplo: Acceder a una provincia específica
  if data.key?("1")
    puts "\n--- Detalle de Azuay ---"
    puts "Cantones: #{data['1']['cantones'].length}"
  end
end
