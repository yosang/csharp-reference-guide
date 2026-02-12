
int cityNumber = 1; // Stan
string cityName = cityNumber switch
{
    0 => "Stavanger",
    1 => "Bergen",
    _ => "Oslo"
};

System.Console.WriteLine(cityName); // Bergen
System.Console.WriteLine(giveMeACity(0)); // Stavanger


string giveMeACity(int c)
{
    switch (c)
    {
        case 0:
            return "Stavanger";
            break;
        case 1:
            return "Bergen";
            break;
        default:
            return "Oslo";
            break;
    }
}
;