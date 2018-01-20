# projekt1

## Opis
Przykładowy projekt z wykorzystaniem IO / Random / Threading / Net

## Działanie
Program wczytuje maksymalną liczbę wątków dla klientów TCP, po czym losuje liczbę wątków uwzględniając maksimum. Utworzony zostaje wątek serwera TCP, a następnie po sekundzie utworzone zostają wątki klientów, które łączą sie z serwerem i wysyłają do niego wiadomości.

## Uruchomienie
Projekt zawiera jedynie kod źródłowy zawarty w pliku proj.cs. Należy skompikować ten plik a następnie uruchomić jako aplikację konsolową. W lokalizacji z klikiem wykonywalnym powiniene się znajdować plik tekstowy o nazwie "MaxLiczbaWatkow.txt", który zawiera wartość całkowitą wyznaczającą liczbę wątków. W przypadku braku pliku wybrana zostanie wartość domyślna.
