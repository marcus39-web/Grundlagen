# MySQL Verbindungsprüfung (kurz)

Schnelle Checks, wenn die Anwendung den Fehler "Unable to connect to any of the specified MySQL hosts" wirft.

1) MySQL?Dienst prüfen
- Windows (Powershell):
  - `Get-Service -Name "MySQL*"`
  - Oder im Dienste?Manager nach `MySQL` / `mysqld` suchen
- Linux:
  - `sudo systemctl status mysql`  oder `sudo systemctl status mysqld`

2) Prüfen, ob Port 3306 lauscht
- Windows:
  - `netstat -an | findstr ":3306"`
- Linux:
  - `ss -ltn | grep 3306`  oder `netstat -an | grep 3306`

3) TCP?Verbindung testen
- PowerShell (Windows / PowerShell Core):
  - `Test-NetConnection -ComputerName 127.0.0.1 -Port 3306`  (liefert Reachable/PortOpen)
- Alternativ (plattformunabhängig, kurz):
  - `dotnet` nicht erforderlich; siehe das beiliegende Skript `scripts/test-db-connection.ps1`

4) MySQL?Client testen
- Lokal installiertes mysql: `mysql -h 127.0.0.1 -P 3306 -u root -p`
- Hinweis: Verwende `127.0.0.1` statt `localhost`, um TCP zu erzwingen (manche Plattformen nutzen für `localhost` UNIX?Socket).

5) Docker?Szenario
- Prüfe laufende Container: `docker ps`
- Verbinde dich aus dem Host per mapped port (z. B. `-p 3306:3306`).
- Wenn App im Container läuft und DB in anderem Container: nutze Docker?Network und Service?Namen als Host (z. B. `mysql:3306`).
- Container?IP ermitteln: `docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' <container>`

6) Konfigurationen, die oft das Problem verursachen
- `bind-address` in `my.cnf` (bei Bedarf auf `0.0.0.0` setzen, wenn externe Verbindungen erlaubt sein sollen).
- Firewall/Windows?Firewall Regeln prüfen (Port 3306 freigeben).
- ConnectionString: explizit `Port=3306;` und `SslMode=None` für lokale Entwicklung.
- Wenn App in Container: `localhost` ist innerhalb des Containers der Container selbst — statt dessen Host?IP oder `host.docker.internal` verwenden.

7) Kurz?Snippet (C#) zum Testen der Verbindung aus dem Projekt
```csharp
// Snippet: temporär in einer Console oder Razor Page zur Diagnose
using var conn = new MySql.Data.MySqlClient.MySqlConnection("Server=127.0.0.1;Port=3306;Database=notizmanager;User ID=root;Password=deinPasswort;SslMode=None;");
try
{
    conn.Open();
    Console.WriteLine("Verbindung OK");
}
catch (Exception ex)
{
    Console.WriteLine("Fehler: " + ex.Message);
}
```

8) Falls weiterhin Fehler auftreten
- Prüfe MySQL?Server?Logs (z. B. `/var/log/mysql/` oder Windows?Eventlog).
- Prüfe, ob Benutzer/Passwort korrekt sind und der Nutzer Zugriff auf die Datenbank hat.

Wenn du möchtest, füge ich ein kleines Razor Page Debug?Tool hinzu, das die Verbindung testet und die Fehlermeldung im Browser anzeigt.