<h1 align="center">🐾 Veterinaria</h1>

<p align="center">
  Sistema de escritorio para una clínica veterinaria: registro de mascotas,<br />
  agenda de citas con costo y reportes, sobre <b>SQL Server</b>.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/.NET%20Framework%204.7.2-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET Framework 4.7.2" />
  <img src="https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white" alt="Windows Forms" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server" />
</p>

---

## ✨ Funciones

| 🐶 Animales | 📅 Citas | 📊 Reportes |
|---|---|---|
| Nombre, especie y raza | Folio consecutivo automático | Consulta de citas registradas |
| Peso, talla y fecha de nacimiento | Fecha y hora, teléfono de contacto | Búsqueda por animal |
| Guardar, buscar, modificar y eliminar | Costo por cita y comentarios | |

## 🗃️ Base de datos

El script [`animales.sql`](animales.sql) crea la base `Veterinaria` con dos tablas:

```text
Animal (ID, Nombre, Especie, Raza, Peso, Talla, FechadeNacimiento)
Cita   (Folio, NombreCita, NoTelefono, FechaYHora, IDAnimal → Animal.ID, CostoxCita, Comentario)
```

## 🚀 Cómo correrlo

1. Ejecuta `animales.sql` en **SQL Server** para crear la base de datos.
2. Abre `Veterinaria.sln` en **Visual Studio** y ejecuta con <kbd>F5</kbd>.

---

<p align="center">Hecho por <a href="https://github.com/hermes2324">Hermes Verdugo</a> · TecNM Campus Guasave</p>
