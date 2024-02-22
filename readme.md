Projekt na zajęcia z Programowania Wizualnego.
Aplikacja Web API oraz .NET MAUI umożliwiające zarządzanie systemem świątecznym (dziećmi oraz prezentami).
Aplikacja korzysta z System.Reflections w celu dynamicznego wyboru bazy danych poprzez konfigurację. 

W celu użycia jednej z baz danych należy wprowadzić zmiany w pliku appsettings.json dla danej aplikacji (webowej lub desktopowej).

W pliku appsettings.json należy ustawić wartość parametru DAOLibraryPath na:
"..\\ChristmasApp.DAO2\\Rzucidlo.ChristmasApp.DAO2.csproj", w celu użycia bazy danych w pamięci,
"..\\ChristmasApp.DAO\\Rzucidlo.ChristmasApp.DAO.csproj", w celu użycia bazy danych SQL.

Uwaga: przed użyciem bazy danych należy skorzystać z komendy menadzera pakietow "Update-database -Project Rzucidlo.ChristmasApp.DAO" oraz ustawić API jako projekt startowy.

Projekty UI oraz API zawierają odwołania do DAO i DAO2 tylko w celu budowania i następnie tworzenia dynamicznie ścieżki do pliku .dll.
