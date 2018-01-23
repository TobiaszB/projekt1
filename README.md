# projekt1

## Opis
Przykładowy projekt z wykorzystaniem IO / Random / Threading / Net oraz Windows Forms

## Działanie
Program wczytuje maksymalną liczbę wątków dla klientów TCP z pliku wskazanego przez użytkownika, po czym losuje liczbę wątków uwzględniając maksimum. Utworzony zostaje wątek serwera TCP, a następnie po sekundzie utworzone zostają wątki klientów, które łączą sie z serwerem i wysyłają do niego wiadomości. Otrzymane wiadomości zostają wyświetlone na ekranie.

## Uruchomienie
Cały kod źródłowy zawarty w pliku Program.cs. Można skompikować ten plik samodzielnie lub wykorzystać załączone pliki solucji programu Visual Studio. Plik z maksymalną liczbą wątków do wczytania powinien być plikiem tekstowym zawierającym w pierwszej linii tekstu liczbę czałowitą.
