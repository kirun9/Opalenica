## Wszystkie dostępne obecnie komendy
### Ogólny charakterystyka komend:
- `[numer toru]` - oznacza parametr opcjonalny z odpowiedniego zakresu wartości
- `[true|false]` - oznacza parametr opcjonalny o określonych wartościach
- `<numer toru>` - oznacza parametr wymagany z odpowiedniego zakresu wartości
- `<true|false>` - oznacza parametr wymagany o określonych wartościach

---

komendy można ze sobą łączyć w łancuchy komend przy użyciu znaku `|` (`shift` + `\`)<br>
<br>
*np. `debugmode true | fullscreen false | debugmode false`&hookleftarrow; - uruchamia tryb deweloperski, wyłącza tryb pełnoekranowy a na koniec wyłącza tryb deweloperski*

---

komendy wymagające powtózenia nie zostaną wykonane jeżeli zostaną przerwane inną komendą<br>
<br>
*np.<br>
`exit`&hookleftarrow;<br>
`debugmode`&hookleftarrow;<br>
`exit`&hookleftarrow;<br>
komenda `exit` nie zostanie wykonana ponieważ zamiast powtórzenia pojawiła się komenda `debugmode`*

### Zwykłe komendy:

| Komenda | Opis |
|:--- |:--- |
|`Debugmode [true\|false]` | Uruchamia tryb deweloperski|
|`<ID Toru> Zmk`|Indywidualne zamknięcie ruchowe toru/szlaku|
|`<ID Toru> oZmk`|Odwołanie zamknięcia ruchowego toru/szlaku|

### Komendy z potwierdzeniem

| Komenda | Możliwe powtórznenia | Opis |
| :--- | :-- | :--- |
|`Exit`|`Exit`|Zamyka program|
|`<sem ID> SZ`|`<sem ID>`|Ustawia sygnał zastępczy na semaforze|
|`<ID Toru> ZeroLO` lub<br>`<ID Toru> ZLO`|`<ID Toru>`|Zerowanie licznika osi sekcji kontroli niezajętości|

### Debugmode commands
| Komenda | Opis |
| :--- |:--- |
| `Fullscreen [true\|false]` | Przełącza program pomiędzy trybem pełnoekranowym a okienkiem |
| `DisplayAllColors [true\|false]` | Wyświetla wszystkie wykorzystywane kolory w symbolu kontrolnym zamiast trzech podstawowych barw |