## Ziel
Eine externe Parkhaus-Informations-App (Monitoring), die die Auslastung von Parkhäusern übersichtlich darstellt.

## Screens / Navigation
1. Dashboard
2. Parkhaus-Liste
3. Parkhaus-Details

Navigation über AppShell (Tabs oder Flyout).

## Funktionen

### Dashboard
- Anzahl Parkhäuser
- Summe freie Plätze / Summe Kapazität
- Auslastung gesamt in %
- Optional: Top 3 (am meisten frei / fast voll)

### Parkhaus-Liste
- Liste aller Parkhäuser mit:
  - Name
  - Ort/Adresse (kurz)
  - freie Plätze / Kapazität
  - Status (z.B. Grün/Gelb/Rot anhand % frei)
- Sortierung:
  - nach Name
  - nach freie Plätze (absteigend)
  - nach Auslastung (aufsteigend)

### Parkhaus-Details
- Detaillierte Infos zum Parkhaus:
  - Name
  - Adresse
  - Kapazität + freie Plätze + Auslastung
  - Öffnungszeiten (Text)
  - Tarifinfo (Text)

## Datenmodell (SQL Server)
Tabelle: Garages
- Id (int, PK)
- Name (nvarchar)
- Address (nvarchar)
- Capacity (int)
- FreeSpaces (int)
- OpeningHours (nvarchar)
- PricingInfo (nvarchar)
- LastUpdated (datetime2)