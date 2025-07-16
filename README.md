# Restaurant Manager

Aplikacja desktopowa w C# (WinForms) do zarządzania zamówieniami w restauracji oraz rezerwacją stolików. Pozwala wybierać pizze, sosy, napoje, składać zamówienia na wynos oraz rezerwować stoliki z podaniem szczegółów klienta i liczby osób.

---

## Funkcjonalności

### Zamówienia

- Dodawanie pizzy z wybranymi dodatkami (toppingami) i informacją o wegetariańskości  
- Wybór sosu za dodatkową opłatą  
- Dodawanie napojów z listy dostępnych produktów  
- Wyświetlanie listy zamówionych produktów oraz podsumowanie kwoty  
- Usuwanie pozycji z zamówienia  
- Formularz danych klienta (imię, nazwisko, e-mail, telefon)  
- Wybór sposobu odbioru (odbiór osobisty lub dowóz z podaniem adresu)  
- Walidacja danych klienta i zamówienia przed zatwierdzeniem  
- Generowanie podsumowania zamówienia z szacowanym czasem oczekiwania  
- Zapis zamówienia do pliku `.txt` w folderze `C:\Temp\Zamowienia`  
- Prosty i intuicyjny interfejs graficzny  

### Rezerwacja stolika

- Formularz do rezerwacji stolika z wymaganymi danymi: imię, nazwisko, e-mail, telefon  
- Wybór godziny rezerwacji (godzinowy picker)  
- Określenie liczby osób (od 2 do 10)  
- Potwierdzenie rezerwacji w oknie dialogowym  
- Przycisk „Menu” do podglądu dostępnych potraw 
- Możliwość powrotu do poprzedniego okna  

---

## Technologie

- .NET 6+ / .NET Framework  
- WinForms  
- C#  
- Regex do ekstrakcji cen  
- Kultura pl-PL do formatowania liczb  

---

## Jak uruchomić

1. Sklonuj repozytorium lub pobierz pliki projektu.  
2. Otwórz projekt w Visual Studio (wersja 2019 lub nowsza rekomendowana).  
3. Upewnij się, że masz zainstalowane odpowiednie frameworki .NET.  
4. Skonfiguruj startową formę na `MainForm`.  
5. Uruchom projekt (F5).  
6. W aplikacji możesz:  
   - Dodawać produkty i składać zamówienia z zapisem do pliku.  
   - Rezerwować stolik w dedykowanym formularzu.  

---

## Struktura projektu

- `WinFormsUI/` — interfejs użytkownika, formularze WinForms: `MainForm`, `PizzaForm`, `SauceForm`, `TableReservationForm` itd.  
- `Core.Models/` — modele biznesowe: `Food`, `Drink`, `Topping`, `MenuItem`  
- `Infrastructure.Repositories/` — warstwa dostępu do danych (np. do zapisywania rezerwacji)  
- `MainForm.cs` — główny formularz zarządzający zamówieniem  
- `TableReservationForm.cs` — formularz rezerwacji stolika  

---

## Możliwe rozszerzenia

- Dodanie bazy danych do przechowywania zamówień i rezerwacji  
- Rozbudowa formularzy wyboru produktów (więcej opcji, zdjęcia)  
- Integracja z systemem płatności online  
- Eksport zamówień i rezerwacji do PDF lub wysyłka e-mailem  
- Obsługa użytkowników i logowanie  
- Powiadomienia SMS/e-mail o rezerwacji lub statusie zamówienia  

---

## Autorzy

Paweł Iwanowski
Oskar Grudzień

---

## Licencja

Projekt udostępniony na licencji MIT.

---

**Miłego zarządzania restauracją i rezerwacjami! 🍕🍹🪑**
