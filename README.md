In dieser Übung geht es um Bewegungen ('Transactions') von Ladungsträgern ('LoadCarrierTypes') zwischen verschiedenen Standorten ('Locations'). Jede Bewegung hat einen Start- und Ziel-Standort und eine Menge von Ladungsträgern. Manche Bewegungen wurden vom Ziel-Standort bereits bestätigt ('AcceptedDate'). In dieser Übung gibt es eine definierte Liste von möglichen Ladungsträgertypen: 'EPAL' (Europalette), 'GIBO' (Gitterbox), 'IFCO' (Lebensmittelkiste), 'IBC' (Tankcontainer)
 
Ziel dieser Übung ist es eine einfache REST API zu erstellen:

    Verwende die angehängte JSON-Datei, sie enthält alle benötigten Daten
    Die API sollte drei Routen besitzen, welche die Daten aufbereiten und zurückgeben:

                - Top drei 'Locations' mit den meisten 'Transactions' (Ausgabe: 'LocationId', 'LocationName', Anzahl)
                - Alle 'DestinationLocations' mit unbestätigten ‚Transactions‘ (Ausgabe: 'LocationId', 'LocationName', Anzahl)
                - Saldos (=eingehende Menge abzüglich ausgehender Menge) aller 'Locations' zum Stichtag 01.05.2024 für Ladungsträgertyp 'EPAL' (Ausgabe: 'LocationId', 'LocationName', Saldo)
        - Die Aufgabenstellung ist bewusst offengehalten, löse die Aufgabe nach bestem Wissen und Gewissen
        - Der Zeitaufwand sollte zwei Stunden nach Möglichkeit nicht überschreiten
        - Stelle uns den Code mit dem Medium Deiner Wahl zur Verfügung

Kommentare:
Die Zeit wurde auf Grund eines dummen Fehlers am Ende echt knapp, deswegen habe ich:
- Die letzte API nur für genau den beschriebenen Fall implementiert
- Keine Kommentare geschrieben
- Nur eine API Beschreibung geschrieben
- Gegen Ende besonders in den LINQ Abfragen keine vernünftigen Variablennamen benutzt
- Nicht so ausführlich getestet wie ich es gern gemacht hätte
