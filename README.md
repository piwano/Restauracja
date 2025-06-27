# Restaurant Manager

## 🎯 Cel aplikacji
Zarządzanie produktami w restauracji. Przechowywanie danych o pozycjach menu (np. dania, napoje), dodawanie ich, zapisywanie do pliku `foods.json`.

## 🛠 Technologie
- C# (.NET 8)
- Windows Forms (WinForms)
- Programowanie obiektowe: dziedziczenie, interfejsy, hermetyzacja
- JSON (zapis danych)
- Trójwarstwowa architektura: Core / Infrastructure / UI

## ✨ Funkcjonalności
- Przeglądanie produktów (ListBox)
- Dodawanie pozycji do menu (np. Pizza)
- Zapis i odczyt danych z pliku JSON

## 🧱 Architektura
- `Core` – definicje modeli (`MenuItem`, `Food`)
- `Infrastructure` – zapis/odczyt danych (`JsonRepository`)
- `WinFormsUI` – interfejs użytkownika (`MainForm`)

## 💾 Instalacja i uruchomienie
1. Otwórz projekt w Visual Studio.
2. Przywróć pakiety NuGet: `dotnet restore`
3. Ustaw `WinFormsUI` jako projekt startowy.
4. Uruchom.

## 📊 UML (klasy)
