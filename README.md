# Ecuador Locations

Base de datos completa de **Provincias, Cantones y Parroquias del Ecuador** en formato JSON, lista para usar en tus proyectos JavaScript/TypeScript.

## Instalación

```bash
npm install ecuador-locations
```

## Uso

### Importar todo el listado

```javascript
import locations from 'ecuador-locations';

console.log(locations);
// Resultado:
// {
//   "1": {
//     "provincia": "AZUAY",
//     "cantones": { ... }
//   },
//   ...
// }
```

### Estructura de Datos

La data está organizada jerárquicamente por IDs:

```typescript
interface LocationData {
  [idProvincia: string]: {
    provincia: string;
    cantones: {
      [idCanton: string]: {
        canton: string;
        parroquias: {
          [idParroquia: string]: string // Nombre de la parroquia
        }
      }
    }
  }
}
```

## Ejemplo: Llenar un Select de Provincias

```javascript
import locations from 'ecuador-locations';

const provincias = Object.values(locations).map(p => p.provincia);
console.log(provincias); 
// ["AZUAY", "BOLIVAR", "CAÑAR", ...]
```



## Uso en otros lenguajes

Hemos organizado los ejemplos por lenguaje en la carpeta `examples/`. Aquí tienes cómo ejecutar cada uno:

### Python

```bash
cd examples/python
python main.py
```

### PHP

```bash
cd examples/php
php index.php
```

### Go

```bash
cd examples/go
go run main.go
```

### Java

```bash
cd examples/java
java Main.java
```
*(Requiere Java 11+ para ejecutar archivos fuente directamente)*

### C#

```bash
cd examples/csharp
dotnet run
```
*(Requiere .NET SDK instalado)*

### Ruby

```bash
cd examples/ruby
ruby main.rb
```

### Rust

```bash
cd examples/rust
cargo run
```
*(Requiere Cargo/Rust instalado)*

## Recursos Visuales

Puedes encontrar imágenes y recursos visuales en la carpeta [`assets/`](./assets).


## Créditos

Los datos en JSON fueron originalmente adaptados de [este Gist de emamut](https://gist.github.com/emamut/6626d3dff58598b624a1). ¡Gracias por el aporte inicial!

## Contribuir


Si encuentras algún error en los nombres o faltan parroquias, ¡tu PR es bienvenido!

## Licencia

MIT
