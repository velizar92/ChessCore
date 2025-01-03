namespace ChessCore
{
    public class Position : IPosition
    {
        public Position(char file, int rank)
        {
            File = file;
            Rank = rank;
        }

        public char File { get; private set; }
        public int Rank { get; private set; }   
    }
}
