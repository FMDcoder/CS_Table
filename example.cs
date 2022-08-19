namespace Program {
    public class example
    {
        public static void Main(string[] args)
        {
            // step 1 create object
            Table tb = new Table(3);

            // step 2 add columns
            tb.addColum(new string[] { "jake", "carlson", "20" });
            tb.addColum(new string[] { "jennifer", "depthsson", "1204" });
            tb.addColum(new string[] { "Harry", "Potter", "2" });
            tb.addColum(new string[] { "Bread", "Toast", "1240" });


            // step 3 get list and print it out
            Console.WriteLine(tb.getList());
        }
    }
}