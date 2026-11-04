using System;

namespace BibliotecaMenu
{
    class Program
    {
        static void Main()
        {
            ShowMainMenu();
        }
        static int ReadOption(int min, int max)
        {
            while (true)
            {
                Console.Write("Seleccione una opción: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int option) && option >= min && option <= max)
                    return option;
                Console.WriteLine($"[!] Opción inválida. Ingrese un número entre {min} y {max}.");
            }
        }

        static bool ReadYesNo(string question)
        {
            while (true)
            {
                Console.Write($"{question} (S/N): ");
                string input = (Console.ReadLine() ?? "").Trim().ToUpper();
                if (input == "S") return true;
                if (input == "N") return false;
                Console.WriteLine("[!] Respuesta inválida. Escriba S o N.");
            }
        }

        
        static string ReadText(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? "").Trim();
                if (input != "") return input;
                Console.WriteLine("[!] El valor no puede estar vacío.");
            }
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.Write("Presione ENTER para continuar...");
            Console.ReadLine();
        }

        static void Header(string title)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("  " + title);
            Console.WriteLine("==========================================");
        }

        
        static void ShowMainMenu()
        {
            bool running = true;
            while (running)
            {
                Header("SISTEMA DE BIBLIOTECA - MENÚ PRINCIPAL");
                Console.WriteLine("1. Libros");
                Console.WriteLine("2. Usuarios");
                Console.WriteLine("3. Préstamos");
                Console.WriteLine("4. Búsquedas y reportes");
                Console.WriteLine("5. Guardar / Cargar datos");
                Console.WriteLine("6. Salir");

                switch (ReadOption(1, 6))
                {
                    case 1: ShowBooksMenu(); break;
                    case 2: ShowUsersMenu(); break;
                    case 3: ShowLoansMenu(); break;
                    case 4: ShowSearchReportsMenu(); break;
                    case 5: ShowPersistenceMenu(); break;
                    case 6:
                        ConfirmExitAndSave();
                        running = false;
                        break;
                }
            }
        }

        
        static void ShowBooksMenu()
        {
            bool back = false;
            while (!back)
            {
                Header("MENÚ LIBROS");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Listar libros");
                Console.WriteLine("3. Ver detalle (por ID/ISBN)");
                Console.WriteLine("4. Actualizar libro");
                Console.WriteLine("5. Eliminar libro");
                Console.WriteLine("0. Volver al menú principal");

                switch (ReadOption(0, 5))
                {
                    case 1: RegisterBook(); break;
                    case 2: ListBooksMenu(); break;
                    case 3: ViewBookDetail(); break;
                    case 4: UpdateBookMenu(); break;
                    case 5: DeleteBook(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void RegisterBook()
        {
            Header("REGISTRAR LIBRO");
            Console.WriteLine("Acción: se registraría un nuevo libro en el sistema.");
            Pause();
        }

        static void ListBooksMenu()
        {
            bool back = false;
            while (!back)
            {
                Header("LISTAR LIBROS");
                Console.WriteLine("1. Listar todos");
                Console.WriteLine("2. Listar disponibles");
                Console.WriteLine("3. Listar prestados");
                Console.WriteLine("0. Volver");

                switch (ReadOption(0, 3))
                {
                    case 1: ListBooksAll(); break;
                    case 2: ListBooksAvailable(); break;
                    case 3: ListBooksBorrowed(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void ListBooksAll()
        {
            Console.WriteLine("\nAcción: se listarían TODOS los libros registrados.");
            Pause();
        }

        static void ListBooksAvailable()
        {
            Console.WriteLine("\nAcción: se listarían los libros DISPONIBLES.");
            Pause();
        }

        static void ListBooksBorrowed()
        {
            Console.WriteLine("\nAcción: se listarían los libros PRESTADOS.");
            Pause();
        }

        static void ViewBookDetail()
        {
            Header("DETALLE DE LIBRO");
            string id = ReadText("Ingrese el ID o ISBN del libro: ");
            Console.WriteLine($"Acción: se mostraría el detalle del libro con ID/ISBN '{id}'.");
            Pause();
        }

        static void UpdateBookMenu()
        {
            bool back = false;
            while (!back)
            {
                Header("ACTUALIZAR LIBRO");
                Console.WriteLine("1. Editar título");
                Console.WriteLine("2. Editar autor");
                Console.WriteLine("3. Editar año / categoría");
                Console.WriteLine("0. Volver");

                switch (ReadOption(0, 3))
                {
                    case 1: EditBookTitle(); break;
                    case 2: EditBookAuthor(); break;
                    case 3: EditBookYearCategory(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void EditBookTitle()
        {
            Console.WriteLine("\nAcción: se editaría el TÍTULO del libro seleccionado.");
            Pause();
        }

        static void EditBookAuthor()
        {
            Console.WriteLine("\nAcción: se editaría el AUTOR del libro seleccionado.");
            Pause();
        }

        static void EditBookYearCategory()
        {
            Console.WriteLine("\nAcción: se editaría el AÑO y la CATEGORÍA del libro seleccionado.");
            Pause();
        }

        static void DeleteBook()
        {
            Header("ELIMINAR LIBRO");
            Console.WriteLine("Validar no permitir si está prestado.");
            Pause();
        }

        
        static void ShowUsersMenu()
        {
            bool back = false;
            while (!back)
            {
                Header("MENÚ USUARIOS");
                Console.WriteLine("1. Registrar usuario");
                Console.WriteLine("2. Listar usuarios");
                Console.WriteLine("3. Ver detalle (por ID/documento)");
                Console.WriteLine("4. Actualizar usuario");
                Console.WriteLine("5. Eliminar usuario");
                Console.WriteLine("0. Volver al menú principal");

                switch (ReadOption(0, 5))
                {
                    case 1: RegisterUser(); break;
                    case 2: ListUsers(); break;
                    case 3: ViewUserDetail(); break;
                    case 4: UpdateUserMenu(); break;
                    case 5: DeleteUser(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void RegisterUser()
        {
            Header("REGISTRAR USUARIO");
            Console.WriteLine("Acción: se registraría un nuevo usuario en el sistema.");
            Pause();
        }

        static void ListUsers()
        {
            Header("LISTAR USUARIOS");
            Console.WriteLine("Acción: se listarían todos los usuarios registrados.");
            Pause();
        }

        static void ViewUserDetail()
        {
            Header("DETALLE DE USUARIO");
            string id = ReadText("Ingrese el ID o documento del usuario: ");
            Console.WriteLine($"Acción: se mostraría el detalle del usuario con ID/documento '{id}'.");
            Pause();
        }

        static void UpdateUserMenu()
        {
            bool back = false;
            while (!back)
            {
                Header("ACTUALIZAR USUARIO");
                Console.WriteLine("1. Editar nombre");
                Console.WriteLine("2. Editar contacto");
                Console.WriteLine("3. Activar / desactivar");
                Console.WriteLine("0. Volver");

                switch (ReadOption(0, 3))
                {
                    case 1: EditUserName(); break;
                    case 2: EditUserContact(); break;
                    case 3: ToggleUserActiveStatus(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void EditUserName()
        {
            Console.WriteLine("\nAcción: se editaría el NOMBRE del usuario seleccionado.");
            Pause();
        }

        static void EditUserContact()
        {
            Console.WriteLine("\nAcción: se editaría el CONTACTO del usuario seleccionado.");
            Pause();
        }

        static void ToggleUserActiveStatus()
        {
            Console.WriteLine("\nAcción: se ACTIVARÍA o DESACTIVARÍA al usuario seleccionado.");
            Pause();
        }

        static void DeleteUser()
        {
            Header("ELIMINAR USUARIO");
            Console.WriteLine("Validar no permitir si tiene préstamos activos.");
            Pause();
        }

       
        static void ShowLoansMenu()
        {
            bool back = false;
            while (!back)
            {
                Header("MENÚ PRÉSTAMOS");
                Console.WriteLine("1. Crear préstamo");
                Console.WriteLine("2. Listar préstamos");
                Console.WriteLine("3. Ver detalle de préstamo (por ID)");
                Console.WriteLine("4. Registrar devolución");
                Console.WriteLine("5. Eliminar préstamo");
                Console.WriteLine("0. Volver al menú principal");

                switch (ReadOption(0, 5))
                {
                    case 1: CreateLoan(); break;
                    case 2: ListLoansMenu(); break;
                    case 3: ViewLoanDetail(); break;
                    case 4: RegisterReturn(); break;
                    case 5: DeleteLoan(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void CreateLoan()
        {
            Header("CREAR PRÉSTAMO");
            Console.WriteLine("Acción: se crearía un nuevo préstamo.");
            Console.WriteLine("Validaciones sugeridas:");
            Console.WriteLine(" - El usuario debe existir y estar activo.");
            Console.WriteLine(" - El libro debe existir y estar disponible.");
            Console.WriteLine(" - El usuario no debe superar el máximo de préstamos activos.");
            Console.WriteLine(" - El usuario no debe tener préstamos vencidos.");
            Console.WriteLine(" - Definir fecha de préstamo y fecha de devolución.");
            Pause();
        }

        static void ListLoansMenu()
        {
            bool back = false;
            while (!back)
            {
                Header("LISTAR PRÉSTAMOS");
                Console.WriteLine("1. Todos");
                Console.WriteLine("2. Activos");
                Console.WriteLine("3. Cerrados");
                Console.WriteLine("0. Volver");

                switch (ReadOption(0, 3))
                {
                    case 1: ListLoansAll(); break;
                    case 2: ListLoansActive(); break;
                    case 3: ListLoansClosed(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void ListLoansAll()
        {
            Console.WriteLine("\nAcción: se listarían TODOS los préstamos.");
            Pause();
        }

        static void ListLoansActive()
        {
            Console.WriteLine("\nAcción: se listarían los préstamos ACTIVOS.");
            Pause();
        }

        static void ListLoansClosed()
        {
            Console.WriteLine("\nAcción: se listarían los préstamos CERRADOS.");
            Pause();
        }

        static void ViewLoanDetail()
        {
            Header("DETALLE DE PRÉSTAMO");
            string id = ReadText("Ingrese el ID del préstamo: ");
            Console.WriteLine($"Acción: se mostraría el detalle del préstamo con ID '{id}'.");
            Pause();
        }

        static void RegisterReturn()
        {
            Header("REGISTRAR DEVOLUCIÓN");
            Console.WriteLine("Acción: se marcaría el préstamo como devuelto y el libro quedaría disponible.");
            Pause();
        }

        static void DeleteLoan()
        {
            Header("ELIMINAR PRÉSTAMO");
            Console.WriteLine("Acción: se eliminaría un préstamo. Reglas sugeridas:");
            Console.WriteLine(" - Solo permitir eliminar préstamos cerrados (ya devueltos).");
            Console.WriteLine(" - No permitir eliminar préstamos activos o vencidos.");
            Console.WriteLine(" - Conservar historial si se requiere para reportes.");
            Pause();
        }

        
        static void ShowSearchReportsMenu()
        {
            bool back = false;
            while (!back)
            {
                Header("BÚSQUEDAS Y REPORTES");
                Console.WriteLine("1. Buscar libro (título/autor/id/categoría)");
                Console.WriteLine("2. Buscar usuario (nombre/id)");
                Console.WriteLine("3. Reportes");
                Console.WriteLine("0. Volver al menú principal");

                switch (ReadOption(0, 3))
                {
                    case 1: SearchBook(); break;
                    case 2: SearchUser(); break;
                    case 3: ReportsMenu(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void SearchBook()
        {
            Header("BUSCAR LIBRO");
            Console.WriteLine("Buscar por: 1. Título  2. Autor  3. ID  4. Categoría");
            int criterio = ReadOption(1, 4);
            string[] nombres = { "título", "autor", "ID", "categoría" };
            string termino = ReadText("Ingrese el término de búsqueda: ");
            Console.WriteLine($"Acción: se buscarían libros por {nombres[criterio - 1]} = '{termino}'.");
            Pause();
        }

        static void SearchUser()
        {
            Header("BUSCAR USUARIO");
            Console.WriteLine("Buscar por: 1. Nombre  2. ID");
            int criterio = ReadOption(1, 2);
            string termino = ReadText("Ingrese el término de búsqueda: ");
            string campo = criterio == 1 ? "nombre" : "ID";
            Console.WriteLine($"Acción: se buscarían usuarios por {campo} = '{termino}'.");
            Pause();
        }

        static void ReportsMenu()
        {
            bool back = false;
            while (!back)
            {
                Header("REPORTES");
                Console.WriteLine("1. Reporte por usuario");
                Console.WriteLine("2. Reporte por libro");
                Console.WriteLine("3. Reporte de vencidos");
                Console.WriteLine("4. Resumen general");
                Console.WriteLine("0. Volver");

                switch (ReadOption(0, 4))
                {
                    case 1: ReportByUser(); break;
                    case 2: ReportByBook(); break;
                    case 3: ReportOverdue(); break;
                    case 4: ReportSummary(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void ReportByUser()
        {
            Console.WriteLine("\nAcción: se generaría el reporte de préstamos POR USUARIO.");
            Pause();
        }

        static void ReportByBook()
        {
            Console.WriteLine("\nAcción: se generaría el reporte de préstamos POR LIBRO.");
            Pause();
        }

        static void ReportOverdue()
        {
            Console.WriteLine("\nAcción: se generaría el reporte de préstamos VENCIDOS.");
            Pause();
        }

        static void ReportSummary()
        {
            Console.WriteLine("\nAcción: se generaría el RESUMEN general (libros, usuarios y préstamos).");
            Pause();
        }

      
        static void ShowPersistenceMenu()
        {
            bool back = false;
            while (!back)
            {
                Header("GUARDAR / CARGAR DATOS");
                Console.WriteLine("1. Guardar datos");
                Console.WriteLine("2. Cargar datos");
                Console.WriteLine("3. Reiniciar datos");
                Console.WriteLine("0. Volver al menú principal");

                switch (ReadOption(0, 3))
                {
                    case 1: SaveData(); break;
                    case 2: LoadData(); break;
                    case 3: ConfirmResetData(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void SaveData()
        {
            Console.WriteLine("\nAcción: se guardarían los datos del sistema.");
            Pause();
        }

        static void LoadData()
        {
            Console.WriteLine("\nAcción: se cargarían los datos del sistema.");
            Pause();
        }

        static void ConfirmResetData()
        {
            Header("REINICIAR DATOS");
            if (ReadYesNo("Esto borraría todos los datos. ¿Desea continuar?"))
                ResetData();
            else
                Console.WriteLine("Operación cancelada. No se reinició ningún dato.");
            Pause();
        }

        static void ResetData()
        {
            Console.WriteLine("Acción: los datos del sistema serían reiniciados.");
        }

        
        static void ConfirmExitAndSave()
        {
            Header("SALIR");
            if (ReadYesNo("¿Guardar antes de salir?"))
            {
                SaveData();
            }
            else
            {
                Console.WriteLine("Se saldrá sin guardar.");
            }
            Console.WriteLine("¡Hasta pronto!");
        }
    }
}
