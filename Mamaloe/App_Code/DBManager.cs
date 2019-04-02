using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;


public class DBManager
{
    public static Database Connect()
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Mamaloe.mdf;Integrated Security=True";
        string provider = "System.Data.SqlClient";
        return Database.OpenConnectionString(connectionString, provider);
    }

    public static bool SetReservation(string voornaam, string tussenvoegsel, string achternaam, string email, string telefoon, string straat, string huisnummer, string woonplaats, string postcode, string land, string opmerking, string incheck_datum, string uitcheck_datum, int aantal_personen, bool huisdier)
    {
        Database db = DBManager.Connect();

        var reserverings_datum = DateTime.Now;
        var factuurnummer = 0;
        var status = "";

        string insertCommand = "INSERT INTO Klant (voornaam, tussenvoegsel, achternaam, email, telefoon, straat, huisnummer, woonplaats, postcode, land) Values (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9)";
        string insertCommand1 = "INSERT INTO Reservering (reserverings_datum, opmerking, incheck_datum, uitcheck_datum, aantal_personen, huisdier, factuurnummer, status) Values (@0, @1, @2, @3, @4, @5, @6, @7)";
        db.Execute(insertCommand, voornaam, tussenvoegsel, achternaam, email, telefoon, straat, huisnummer, woonplaats, postcode, land);
        db.Execute(insertCommand1, reserverings_datum, opmerking, incheck_datum, uitcheck_datum, aantal_personen, huisdier, factuurnummer, status);
        return true;
    }
}
