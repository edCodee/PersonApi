# 🧑‍💻 Persons API

Una API RESTful desarrollada con ASP.NET Core y Entity Framework Core para gestionar información de personas. Ofrece operaciones CRUD completas, búsqueda por nombre y está documentada con Swagger.

---

## 🚀 Tecnologías Utilizadas

- ASP.NET Core 7+
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)
- LINQ
- C#

---

## 📦 Funcionalidades

- Obtener la lista completa de personas.
- Obtener una persona por ID.
- Buscar personas por nombre o apellido.
- Crear una nueva persona.
- Actualizar información existente.
- Eliminar una persona de la base de datos.

---

## 🏗️ Estructura del Proyecto

PersonsApi/
├── Controllers/
│ └── PersonController.cs
├── Data/
│ └── AppDbContext.cs
├── Models/
│ └── PersonModel.cs
├── Program.cs
├── appsettings.json




---

## 📡 Endpoints Disponibles

| Método | Endpoint                 | Descripción                                 |
|--------|--------------------------|---------------------------------------------|
| GET    | `/api/person`            | Obtener todas las personas                  |
| GET    | `/api/person/{id}`       | Obtener persona por ID                      |
| GET    | `/api/person/search?name=Joel` | Buscar personas por nombre o apellido |
| POST   | `/api/person`            | Crear nueva persona                         |
| PUT    | `/api/person/{id}`       | Actualizar información de una persona       |
| DELETE | `/api/person/{id}`       | Eliminar una persona                        |

---

## 🗃️ Modelo de Datos

```csharp
public class PersonModel
{
    public int person_serial { get; set; }
    public string person_firstName { get; set; }
    public string person_lastName { get; set; }
    public DateTime person_dateOfBirth { get; set; }
    public string person_id { get; set; } // Cédula (única)
}

🔧 Configuración de la Base de Datos
Ubicada en appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=DESKTOP-RC2HO3L;Database=PersonDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

🛠️ Ejecución del Proyecto
Clona el repositorio:
git clone https://github.com/tu_usuario/PersonsApi.git
cd PersonsApi
Restaura dependencias:
dotnet restore
Aplica las migraciones y crea la base de datos:
dotnet ef database update
Ejecuta el proyecto:
dotnet run
Accede a Swagger:
https://localhost:<puerto>/swagger

💡 Autor
Joel @edcode
📚 Desarrollador apasionado por la tecnología, la educación y la creación de soluciones eficientes.
