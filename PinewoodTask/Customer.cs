﻿namespace JontyNewman.PinewoodTask;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Address Address { get; set; } = new();

    public DateTime? Removed { get; set; }
}
