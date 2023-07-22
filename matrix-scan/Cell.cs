internal class Cell
{
    public bool Filled { get; }
    public bool Used { get; set; } = false;
    public Cell(string item)
    {
        Filled = item == "1";
    }
}