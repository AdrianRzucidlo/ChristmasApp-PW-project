1 WYMAGANIA OGÓLNE
1.1 Projekty dotyczą implementacji katalogu produktów, przy czym każdy indywidualnie
wybiera sobie produkty. Jako przykład mogą posłużyć samochody. Jest wielu producentów,
z czego każdy produkuje wiele różnych samochodów. Ze względu na prezentowane na
laboratoriach i wykładach przykłady, nie można wybierać samochodów jako tematu
projektu zaliczeniowego.
1.2 Projekty realizuje się w dwuosobowych grupach
1.3 Przy implementacji projektów należy stosować się do wymagań standardu kodowania
opisanego w punkcie 3, który nie odbiega od przyjętego standardu kodowania w języku C#.
1.4 Ocena z projektów wystawiana jest zarówno na podstawie zgodności z wymaganiami.
Wymagania odnośnie terminu oddania projektu wynikają jedynie z decyzji Dziekanatu i
trwania semestru.
1.5 Przy oddawaniu projektów należy je wcześniej wyczyścić z elementów, które są wynikiem
kompilacji, a następnie zgłosić w odpowiednim zadaniu na e-kursach przedmiotu.
1.6 Interfejs aplikacji należy wykonać w technologii WPF, UWP, WINUI 3.0 lub .NET MAUI z
wykorzystaniem architektury opisanej w sekcji 2. Następnie, bazując na utworzonych już
klasach dostępu do danych, należy utworzyć aplikację web-ową z wykorzystaniem
technologii ASP.Net Core, MVC lub Blazor. Oczywiście kolejność może zostać odwrócona –
można realizować aplikację webową w pierwszej kolejności.
1.7 Katalog musi zawierać minimum dwie powiązane relacje Producent-Produkt.
1.8 Wymagane jest wykorzystanie typu wyliczeniowego jako typu jednego z atrybutów
Produktu/Producenta.
2 ARCHITEKTURA APLIKACJI
Zakłada się możliwość wykorzystania jak największej części kodu w innych aplikacjach. Dlatego
aplikacja jest modułowa, a odpowiednie moduły znajdują się w oddzielnych warstwach według
poniższych zasad:
2.1 Należy stosować wzorzec projektowy Aplikacja wielowarstwowa z wydzielonymi
warstwami (w wersji minimalnej):
 UI – interfejsy użytkownika,
 BL – warstwa logiki biznesowej,
 DAO – warstwa dostępu do danych.
Do wyżej wymienionych warstw wspólne są następujące biblioteki pomocnicze:
 CORE – typy wyliczeniowe i ustawienia aplikacji,
 INTERFACES – wszystkie interfejsy.
2.2 Każdy z powyżej wymienionych elementów architektury stanowi osobną bibliotekę dll, przy
czym warstwa UI jest aplikacją. W przypadku aplikacji webowej, niektóre biblioteki mogą
zostać zastąpione przez REST API.
2.3 Dozwolone jest wykorzystanie biblioteki z warstwy wyższej przez bibliotekę warstwy niższej
i tylko w tym kierunku.
2.4 W warstwie DAO umieszczone są obiekty danych DO(Data Objects) implementujące
interfejsy (z biblioteki INTERFACES) tak, aby warstwy UI i BL nie miały bezpośredniej
referencji do tej warstwy. Wczytanie danych powinno zostać wykonane za pomocą techniki
późnego wiązania (ang. late binding) realizowanej z wykorzystaniem System.Reflection.
2.5 Nazwa biblioteki z danymi znajduje się w pliku konfiguracyjnym aplikacji i może zostać
zmieniona bez rekompilacji kodu aplikacji.
2.6 Nazwa przestrzeni nazw (namespace) ma być następująca:
Nazwisko.NazwaAplikacji.NazwaSkładowej, gdzie:
 Nazwisko – bez komentarza – należy pominąć polskie litery. Może to być też nr.
indeksu jeśli ktoś nie chce używać nazwiska,
 NazwaAplikacji – jak podano wcześniej,
 NazwaSkładowej – np. BLC, DAO itp.
