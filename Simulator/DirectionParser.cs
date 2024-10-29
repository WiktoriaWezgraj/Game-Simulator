namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string letters)
    {
        int validCount = 0; //Zakładając, że nie wszystkie litery w letters będą oznaczać kierunki
        for (int i = 0; i < letters.Length; i++)
        {
            char c = char.ToUpper(letters[i]);
            if (c == 'U' || c == 'R' || c == 'D' || c == 'L')
            {
                validCount++;
            }
        }

        Direction[] directions = new Direction[validCount];
        int index = 0;

        foreach (char c in letters.ToUpper())
        {
            switch (c)
            {
                case 'U':
                    directions[index++] = Direction.Up;
                    break;
                case 'R':
                    directions[index++] = Direction.Right;
                    break;
                case 'D':
                    directions[index++] = Direction.Down;
                    break;
                case 'L':
                    directions[index++] = Direction.Left;
                    break;
            }
        }

        return directions;
    }
}
