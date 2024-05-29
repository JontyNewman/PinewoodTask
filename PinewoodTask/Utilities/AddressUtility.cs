namespace JontyNewman.PinewoodTask.Utilities;

public static class AddressUtility
{
    public static IEnumerable<string> ToAddressLinesWithoutBlanks(Address address)
        => ToAddressLines(address).Where(l => !string.IsNullOrWhiteSpace(l));

    public static IEnumerable<string> ToAddressLines(Address address)
        => [address.Line1, address.Line2, address.Town, address.County, address.Postcode];
}
