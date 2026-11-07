
# Laboratorio-Parcial#2 - Patrón MVP y por Capas en C#

Ejercicio desarrollado para practicar la implementación del **patrón MVP (Modelo-Vista-Presentador)**, utilizando **C# Windows Forms**, arquitectura por capas, validación de contraseñas mediante hash y conexión a una base de datos MySQL.

**Laboratorio de MVP - Parcial Práctico**  
**Universidad Tecnológica de Panamá - Facultad de Ingeniería en Sistemas**

**Programado por:** Kevin Esquivel

**Fecha:** 07/11/2026

---

## 📋 Descripción

Este laboratorio implementa un sistema de inicio de sesión utilizando el **patrón MVP** y una arquitectura dividida en cuatro capas: **Entidades, Datos, Negocio y Presentación**.

El programa permite validar las credenciales de un usuario mediante **hash SHA-512** y acceder a una ventana principal con un menú lateral.

En la ventana principal se muestra la hora, la fecha actual y el usuario que inició sesión. También cuenta con una sección de productos donde se visualizan los registros almacenados en MySQL mediante un **DataGridView**.

---

## 🔧 Funciones principales

El programa permite realizar las siguientes operaciones:

- **Inicio de sesión:** validar el usuario y la contraseña ingresados.
- **Hash:** generar y verificar contraseñas mediante dos interfaces independientes.
- **Validaciones:** mostrar mensajes cuando las credenciales son incorrectas.
- **Menú lateral:** expandir y contraer el menú de navegación.
- **Reloj:** mostrar la hora y fecha actual automáticamente.
- **Usuario conectado:** mostrar el nombre del usuario que inició sesión.
- **Productos:** consultar los productos almacenados en MySQL mediante un DataGridView.
- **Ventanas:** maximizar, restaurar, minimizar y cerrar la aplicación.

### Inicio de sesión

**Login:**

<img width="794" height="478" alt="image" src="https://github.com/user-attachments/assets/f2b3fa62-598b-4ac1-9911-acb70ff1af29" />


**Validación de credenciales:**

<img width="799" height="475" alt="image" src="https://github.com/user-attachments/assets/f3660935-6373-4fb0-9f1b-5617bc0b00b6" />


### Ventana principal

**Menú lateral, reloj y usuario conectado:**

<img width="1295" height="649" alt="image" src="https://github.com/user-attachments/assets/a0c4b1d5-1f1f-46ac-bcdf-40bce6ceab40" />


**Menú contraído:**

<img width="1297" height="646" alt="image" src="https://github.com/user-attachments/assets/649ac32f-f0e2-41cd-b333-c958121a5c3b" />

### Productos

**Consulta de productos registrados:**

<img width="1299" height="642" alt="image" src="https://github.com/user-attachments/assets/abb906e7-4306-40e7-add8-bd01387af73d" />


---

## 🛠️ Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework:** .NET Framework 4.8
- **IDE:** Visual Studio
- **Tipo de aplicación:** Windows Forms
- **Base de datos:** MySQL
- **Conexión:** MySql.Data
- **Seguridad:** SHA-512
- **Patrón de diseño:** MVP
- **Arquitectura:** Entidades, Datos, Negocio y Presentación
- **Paradigmas:** Programación Orientada a Objetos e interfaces de C#

---

## 🗄️ Base de datos

El sistema utiliza la base de datos **`problema1_productos`**, que contiene las tablas:

- **usuarios:** almacena la información de los usuarios y sus contraseñas mediante hash.
- **productos:** almacena el nombre, precio, cantidad, gama e imagen de cada producto.

Para consultar la información se utilizan **procedimientos almacenados** de MySQL.

La conexión se realiza mediante un usuario específico con permisos limitados, sin utilizar la cuenta root.

El archivo **`problema1_productos.sql`** se encuentra en la carpeta `BaseDeDatos` del repositorio.

---

## ⚙️ Instalación

**Requisitos:** Visual Studio, .NET Framework 4.8, MySQL Server, MySQL Workbench y Git.


**Importar la base de datos:**

1. Abrir MySQL Workbench.
2. Ir a **Server → Data Import**.
3. Seleccionar **Import from Self-Contained File**.
4. Buscar el archivo `problema1_productos.sql`.
5. Importar la base de datos.

**Configurar la conexión:**

En el archivo `D_Conexion.cs`, configurar los datos de conexión según el servidor MySQL utilizado:

- **Server:** dirección del servidor.
- **Database:** `problema1_productos`.
- **Uid:** usuario MySQL con los permisos necesarios.
- **Pwd:** contraseña correspondiente a ese usuario.

El usuario de MySQL debe tener los permisos necesarios para ejecutar los procedimientos almacenados utilizados por la aplicación.
