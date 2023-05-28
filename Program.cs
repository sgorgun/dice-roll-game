var random = new Random();
var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);

bool xxx = guessingGame.Play();

Console.ReadKey();

public class GuessingGame
{
    private readonly Dice _dice;
    private const int InitialTries = 3;

    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }

    public bool Play()
    {
        var diceRollResult = _dice.Roll();
        Console.WriteLine($"Dice rolled. Guess what number it shows in {InitialTries} tries.");

        var tiesLeft = InitialTries;
        while (tiesLeft > 0)
        {
            var guess = ConsoleReader.ReadInteger("Enter a number:");
            if (guess == diceRollResult)
            {
                return true;
            }
            Console.WriteLine("Wrong number.");
            --tiesLeft;
        }
        return false;
    }
}

public static class ConsoleReader
{
    public static int ReadInteger(string message)
    {
        int result;
        do
        {
            Console.WriteLine(message);
        }
        while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }
}

public class Dice
{
    private readonly Random _random;
    private const int SidesCount = 6;

    public Dice(Random random)
    {
        _random = random;
    }

    public int Roll() => _random.Next(1, SidesCount + 1);

    public void Describe() => Console.WriteLine($"This is a dice with {SidesCount} sides.");
}