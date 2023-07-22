internal class MatrixScanner
{
    private readonly Cell[][] _matrix;
    private readonly int _width;
    private readonly int _height;

    public MatrixScanner(string input)
    {
        _matrix = input.Split(";").Select(line => line.Split(",").Select(item => new Cell(item)).ToArray()).ToArray();
        _width = _matrix.First().Length;
        _height = _matrix.Length;
    }

    public int Scan()
    {
        var output = 0;
        // scan rows and columns
        for (int y = 0; y < _height; y++)
            for (int x = 0; x < _width; x++)
            {
                var cell = _matrix[y][x];
                if (cell.Filled && !cell.Used)
                {
                    // "1" cell found 
                    // Increment the counter
                    output += 1;
                    // Recursively mark the connected cells as used
                    MarkUsedAround(x, y);
                }
            }

        return output;
    }

    private void MarkUsedAround(int x, int y)
    {
        if (x < 0 || x >= _width || y < 0 || y >= _height)
        {
            return;
        }
        var cell = _matrix[y][x];
        if (cell.Used || !cell.Filled)
        {
            return;
        }
        cell.Used = true;
        MarkUsedAround(x - 1, y);
        MarkUsedAround(x + 1, y);
        MarkUsedAround(x, y - 1);
        MarkUsedAround(x, y + 1);
    }
}