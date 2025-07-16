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

## Screenshoty


![ss1](https://github.com/user-attachments/assets/7575c4f3-5f58-4d0b-8730-3d32acf349b0)
![ss2](https://github.com/user-attachments/assets/ec3af2e4-c0dd-4e05-b6eb-2ab6bdbd6d2c)
![ss3](https://github.com/user-attachments/assets/375cf2b1-664e-4d82-ba29-931f22956bd3)


---

## Paradygmat obiektowy

Abstrakcja: Kod ukrywa szczegóły działania klas takich jak Drink, PizzaForm, SauceForm, pokazując tylko to, co istotne dla użytkownika (np. nazwa napoju i cena). Użytkownik nie musi wiedzieć, jak wygląda implementacja klasy Drink.
Przykład:
<img width="509" height="72" alt="ss5" src="https://github.com/user-attachments/assets/784ae493-442d-4693-9d42-2a4085aea259" />

Hermetyzacja: Dane, takie jak availableDrinks, są przechowywane jako prywatna lista (private List<Drink> availableDrinks) – inne klasy nie mają bezpośredniego dostępu do tej listy. Dostęp do niej odbywa się tylko poprzez metody klasy MainForm.
Przykład:
<img width="575" height="47" alt="ss6" src="https://github.com/user-attachments/assets/6e9f8e9d-5af7-4d03-96f4-072c50da3f13" />

Polimorfizm: Polimorfizm pojawia się np. przy pracy z kolekcją listBox.Items, która może zawierać różne typy danych w postaci tekstu (opis pizzy, sosu, napoju), ale dla każdego elementu działa ta sama metoda ExtractPrice():
Bez względu na to, czy jest to "Cola - 8.00 zł" czy "Sos czosnkowy - 2,00 zł" — metoda przetwarza każdy z nich jednakowo 
Przykład:
<img width="536" height="73" alt="ss7" src="https://github.com/user-attachments/assets/068583e6-b148-4e93-a61e-79baa4527234" />

Dziedziczenie: Klasa Food dziedziczy po klasie MenuItem.
Oznacza to, że Food dziedziczy wszystkie publiczne i chronione elementy (pola, właściwości, metody) z MenuItem.
Jeśli MenuItem zawiera metody abstrakcyjne, klasa Food musi je zaimplementować, chyba że sama również będzie klasą abstrakcyjną.
Dzięki dziedziczeniu, możemy traktować różne elementy menu (np. Food, Drink, Sauce) jako MenuItem i obsługiwać je w jednolity sposób.

Przykład:
<img width="323" height="43" alt="dzie1" src="https://github.com/user-attachments/assets/50201e7d-ba39-45c9-a5ca-a4413aef4855" />
<img width="301" height="32" alt="dzie2" src="https://github.com/user-attachments/assets/d97d036c-b171-40cb-95d8-08e3aff75b26" />

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
