# 📚 Biblioteca Personal - ASP.NET MVC

## 1. Contexto elegido y justificación

He elegido el contexto de una biblioteca personal porque es una aplicación sencilla y útil para gestionar libros.  
La aplicación permite añadir, editar, eliminar y marcar libros como leídos.  
Este contexto es adecuado para practicar operaciones CRUD y trabajar con arquitectura MVC y SQLite.

---

# 2. Estructura de la base de datos

## Tabla: Libros

| Columna   | Tipo     | Descripción |
|------------|----------|--------------|
| Id         | INTEGER  | Identificador único |
| Titulo     | TEXT     | Título del libro |
| Autor      | TEXT     | Autor del libro |
| Leido      | INTEGER  | Estado leído (0 o 1) |
| Categoria  | TEXT     | Categoría del libro |



# 3. URLs de la aplicación

| URL | Acción |
|-----|---------|
| /Libros | Mostrar todos los libros |
| /Libros/Crear | Añadir un nuevo libro |
| /Libros/Editar/{id} | Editar un libro |
| /Libros/Leer/{id} | Marcar libro como leído |
| /Libros/Eliminar/{id} | Eliminar libro |
| /Libros?filtro=leidos | Mostrar libros leídos |
| /Libros?filtro=noleidos | Mostrar libros no leídos |



# 4. Cambios realizados respecto al código base

Se realizaron las siguientes modificaciones:

- Cambio del contexto original de tareas a biblioteca personal.
- Creación del modelo `Libro`.
- Añadido un nuevo campo llamado `Categoria`.
- Implementación de la funcionalidad de edición.
- Implementación de validación en el controlador.
- Uso de SQLite para guardar datos.
- Implementación de filtros por estado (leídos / no leídos).
- Mejora visual mediante CSS.

---

# 5. Tecnologías utilizadas

- ASP.NET Core MVC
- C#
- SQLite
- HTML / Razor
- CSS



# 6. Capturas de pantalla

## Página principal
<img width="1762" height="667" alt="Captura de pantalla 2026-05-21 095417" src="https://github.com/user-attachments/assets/2b7dbac1-e7fa-4f61-afde-14475b2f4214" />


## Formulario Crear
<img width="781" height="539" alt="Captura de pantalla 2026-05-21 095808" src="https://github.com/user-attachments/assets/3d09d59a-545c-481e-8312-3f4cd668e955" />



## Formulario Editar

<img width="1373" height="545" alt="Captura de pantalla 2026-05-21 095548" src="https://github.com/user-attachments/assets/d8fdd38e-c5ac-4134-8a74-c2d3529aa30c" />


## Filtro de libros
<img width="1292" height="621" alt="Captura de pantalla 2026-05-21 095556" src="https://github.com/user-attachments/assets/2e13bb5e-584d-470b-b369-ae4cd8b1081f" />



# 7. Funcionamiento general

La aplicación utiliza arquitectura MVC:

- Model: representa los datos del libro.
- View: muestra la interfaz al usuario.
- Controller: gestiona la lógica y las consultas SQL.

Las operaciones CRUD se realizan mediante consultas SQL:
- SELECT
- INSERT
- UPDATE
- DELETE

