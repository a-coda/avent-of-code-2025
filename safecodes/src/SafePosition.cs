using System.Diagnostics;

namespace safecodes;

public class SafePosition
{
    private int Position { get; set; } = 50;
    public int Zeroes { get; set; } = 0;

    public void ProcessCode(Strategy strategy, Code code)
    {
        switch (code.Direction)
        {
            case Direction.Left:
                Left(strategy, code.Steps);
                break;
            case Direction.Right:
                Right(strategy, code.Steps);
                break;
        }
    }

    private void Left(Strategy strategy, int steps)
    {
        int newPosition;
        switch (strategy)
        {
            case Strategy.EndOfTurn:
                newPosition = (Position - steps) % 100;
                if (newPosition == 0)
                {
                    Zeroes++;
                }
                if (newPosition < 0)
                {
                    newPosition += 100;
                }
                Position = newPosition;
                break;
            case Strategy.AnyClick:
                Console.WriteLine($"Processing Left {steps} from position {Position}");
                newPosition = Position;
                for (int i = 1; i <= steps; i++)
                {
                    newPosition = (newPosition - 1) % 100;
                    if (newPosition == 0)
                    {
                        Console.WriteLine($"Hit zero moving left from {Position} by {steps} steps.");
                        Zeroes++;
                    }
                }
                if (newPosition < 0)
                {
                    newPosition += 100;
                }
                Position = newPosition;
                Console.WriteLine($"New position after moving left: {Position}");
                break;
        }

        
    }

    private void Right(Strategy strategy, int steps)
    {
        int newPosition;
        switch (strategy)
        {
            case Strategy.EndOfTurn:
                newPosition = (Position + steps) % 100;
                if (newPosition == 0)
                {
                    Zeroes++;
                }
                Position = newPosition;
                return;
            case Strategy.AnyClick:
                Console.WriteLine($"Processing Right {steps} from position {Position}");
                newPosition = Position;
                for (int i = 1; i <= steps; i++)
                {
                    newPosition = (newPosition + 1) % 100;
                    if (newPosition == 0)
                    {
                        Console.WriteLine($"Hit zero moving right from {Position} by {steps} steps.");
                        Zeroes++;
                    }
                }
                Position = newPosition;
                Console.WriteLine($"New position after moving right: {Position}");
                return;
        }
    }
}
