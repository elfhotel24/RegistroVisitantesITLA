# 📋 Registro de Visitantes ITLA

Sistema de escritorio para el **registro y control de visitantes** del ITLA (Instituto Tecnológico de Las Américas). Desarrollado en **C#** con base de datos **SQL Server**, permite llevar un control ordenado de las personas que ingresan a las instalaciones.

---

## 📋 Descripción

Aplicación de gestión que permite registrar la entrada y salida de visitantes, almacenando su información (nombre, motivo de visita, persona a visitar, fecha/hora, etc.) en una base de datos SQL Server. Incluye funcionalidades de consulta, reportes y administración de registros.

---

## 🛠️ Tecnologías utilizadas

| Componente       | Tecnología          |
|------------------|---------------------|
| Lenguaje         | C#                  |
| Framework        | .NET Framework / .NET |
| Base de datos    | SQL Server          |
| IDE              | Visual Studio       |
| Interfaz         | Windows Forms / WPF *(ajusta según corresponda)* |

---

## 📁 Estructura del proyecto
RegistroVisitantesITLA/
├── RegistroVisitantesITLA.sln # Solución de Visual Studio
├── RegistroVisitantesITLA/ # Proyecto principal
│ ├── Forms/ # Formularios de la aplicación
│ ├── Models/ # Modelos de datos
│ ├── Data/ # Acceso a datos
│ ├── App.config # Configuración (cadenas de conexión)
│ └── Program.cs # Punto de entrada
├── .gitignore # Archivos ignorados por Git
└── README.md # Este archivo

text

---

## 🗄️ Base de datos

El sistema requiere una base de datos en **SQL Server**. Para configurarla:

1. Abre SQL Server Management Studio (SSMS).
2. Ejecuta el script `BaseDatos.sql` *(si lo incluyes en el repo)* para crear la base de datos y las tablas.
3. Configura la cadena de conexión en el archivo `App.config`:
   ```xml
   <connectionStrings>
     <add name="MiConexion" 
          connectionString="Server=TU_SERVIDOR;Database=RegistroVisitantes;Integrated Security=True;" 
          providerName="System.Data.SqlClient" />
   </connectionStrings>
⚠️ Importante: No subas tus credenciales reales al repositorio. Usa autenticación de Windows (Integrated Security=True) o variables de entorno.

🚀 Instalación y ejecución
Requisitos previos
Visual Studio 2019 o superior

.NET Framework 4.7.2+ o .NET 6+

SQL Server (Express, Developer o superior)

Pasos
Clona el repositorio:

bash
git clone https://github.com/elfhotel24/RegistroVisitantesITLA.git
Abre la solución:
Abre RegistroVisitantesITLA.sln con Visual Studio.

Configura la base de datos:
Ejecuta el script SQL y actualiza la cadena de conexión en App.config.

Compila y ejecuta:
Presiona F5 en Visual Studio o haz clic en "Iniciar".

⚙️ Funcionalidades
✅ Registro de entrada de visitantes.

✅ Registro de salida de visitantes.

✅ Búsqueda y consulta de visitantes.

✅ Generación de reportes.

✅ Administración de usuarios (si aplica).

👤 Autor
elfhotel24

GitHub: @elfhotel24

⭐ Si este proyecto te resultó útil, considera darle una estrella en GitHub.
