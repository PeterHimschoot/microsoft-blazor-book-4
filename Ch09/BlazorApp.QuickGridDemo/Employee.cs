using System;

public record class Name(string Title, string First, string Last);

public record class Picture(string Large, string Medium, string Thumbnail);

public record class Dob(DateTime Date, int Age);

public record class Employee(Name Name, Dob Dob, Picture Picture);
