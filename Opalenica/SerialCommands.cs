namespace Opalenica;

internal class SerialCommands
{
    private readonly static Dictionary<string, byte[]> _commands = new Dictionary<string, byte[]>()
    {
        { "zwr 1 -"   , new byte[] {24, 30, 30, 30, 32, 30, 32, 25 } },
        { "zwr 1 +"   , new byte[] {24, 30, 30, 30, 31, 30, 31, 25 } },
        { "zwr 2ab -" , new byte[] {24, 30, 31, 30, 32, 30, 33, 25 } },
        { "zwr 2ab +" , new byte[] {24, 30, 31, 30, 31, 30, 30, 25 } },
        { "zwr 2cd -" , new byte[] {24, 30, 30, 30, 32, 30, 32, 25 } },
        { "zwr 2cd +" , new byte[] {24, 30, 30, 30, 31, 30, 31, 25 } },
        { "zwr 3ab -" , new byte[] {24, 30, 32, 30, 32, 30, 30, 25 } },
        { "zwr 3ab +" , new byte[] {24, 30, 32, 30, 31, 30, 33, 25 } },
        { "zwr 3cd -" , new byte[] {24, 30, 31, 30, 32, 30, 33, 25 } },
        { "zwr 3cd +" , new byte[] {24, 30, 31, 30, 31, 30, 30, 25 } },
        { "zwr 4 -"   , new byte[] {24, 30, 33, 30, 32, 30, 31, 25 } },
        { "zwr 4 +"   , new byte[] {24, 30, 33, 30, 31, 30, 32, 25 } },
        { "zwr 6 -"   , new byte[] {24, 30, 34, 30, 32, 30, 36, 25 } },
        { "zwr 6 +"   , new byte[] {24, 30, 34, 30, 31, 30, 35, 25 } },
        { "zwr 7 -"   , new byte[] {24, 30, 34, 30, 32, 30, 36, 25 } },
        { "zwr 7 +"   , new byte[] {24, 30, 34, 30, 31, 30, 35, 25 } },
        { "zwr 10ab -", new byte[] {24, 30, 36, 30, 32, 30, 34, 25 } },
        { "zwr 10ab +", new byte[] {24, 30, 36, 30, 31, 30, 37, 25 } },
        { "zwr 10cd -", new byte[] {24, 30, 35, 30, 32, 30, 37, 25 } },
        { "zwr 10cd +", new byte[] {24, 30, 35, 30, 31, 30, 34, 25 } },
        { "zwr 11ab -", new byte[] {24, 30, 37, 30, 32, 30, 35, 25 } },
        { "zwr 11ab +", new byte[] {24, 30, 37, 30, 31, 30, 36, 25 } },
        { "zwr 11cd -", new byte[] {24, 30, 36, 30, 32, 30, 34, 25 } },
        { "zwr 11cd +", new byte[] {24, 30, 36, 30, 31, 30, 37, 25 } },
        { "zwr 12 -"  , new byte[] {24, 30, 37, 30, 32, 30, 35, 25 } },
        { "zwr 12 +"  , new byte[] {24, 30, 37, 30, 31, 30, 36, 25 } },
        { "zwr 13 -"  , new byte[] {24, 30, 38, 30, 32, 30, 41, 25 } },
        { "zwr 13 +"  , new byte[] {24, 30, 38, 30, 31, 30, 39, 25 } },
        { "zwr 14ab -", new byte[] {24, 30, 39, 30, 32, 30, 42, 25 } },
        { "zwr 14ab +", new byte[] {24, 30, 39, 30, 31, 30, 38, 25 } },
        { "zwr 14cd -", new byte[] {24, 30, 38, 30, 32, 30, 41, 25 } },
        { "zwr 14cd +", new byte[] {24, 30, 38, 30, 31, 30, 39, 25 } },
        { "zwr 15 -",   new byte[] {24, 30, 39, 30, 32, 30, 42, 25 } },
        { "zwr 15 +",   new byte[] {24, 30, 39, 30, 31, 30, 38, 25 } },

        { "sem a sz"  , new byte[] {24, 32, 30, 32, 30, 30, 30, 25 } },
        { "sem a osz" , new byte[] {24, 32, 30, 30, 30, 32, 30, 25 } },
        { "sem b sz"  , new byte[] {24, 32, 32, 32, 30, 30, 32, 25 } },
        { "sem b osz" , new byte[] {24, 32, 32, 30, 30, 32, 32, 25 } },
        { "sem c sz"  , new byte[] {24, 32, 34, 32, 30, 30, 34, 25 } },
        { "sem c osz" , new byte[] {24, 32, 34, 30, 30, 32, 34, 25 } },
        { "sem d sz"  , new byte[] {24, 32, 39, 32, 30, 30, 39, 25 } },
        { "sem d osz" , new byte[] {24, 32, 39, 30, 30, 32, 39, 25 } },
        { "sem e sz"  , new byte[] {24, 32, 41, 32, 30, 30, 41, 25 } },
        { "sem e osz" , new byte[] {24, 32, 41, 30, 30, 32, 41, 25 } },
        { "sem f sz"  , new byte[] {24, 32, 42, 32, 30, 30, 42, 25 } },
        { "sem f osz" , new byte[] {24, 32, 42, 30, 30, 32, 42, 25 } },
        { "sem g sz"  , new byte[] {24, 32, 43, 32, 30, 30, 43, 25 } },
        { "sem g osz" , new byte[] {24, 32, 43, 30, 30, 32, 43, 25 } },
        { "sem h sz"  , new byte[] {24, 32, 44, 32, 30, 30, 44, 25 } },
        { "sem h osz" , new byte[] {24, 32, 44, 30, 30, 32, 44, 25 } },
        { "sem l sz"  , new byte[] {24, 32, 45, 32, 30, 30, 45, 25 } },
        { "sem l osz" , new byte[] {24, 32, 45, 30, 30, 32, 45, 25 } },
        { "sem m sz"  , new byte[] {24, 32, 46, 32, 30, 30, 46, 25 } },
        { "sem m osz" , new byte[] {24, 32, 46, 30, 30, 32, 46, 25 } },
        { "sem n sz"  , new byte[] {24, 32, 30, 32, 30, 30, 30, 25 } },
        { "sem n osz" , new byte[] {24, 32, 30, 30, 30, 32, 30, 25 } },
        { "sem o sz"  , new byte[] {24, 33, 31, 32, 30, 31, 31, 25 } },
        { "sem o osz" , new byte[] {24, 33, 31, 30, 30, 33, 31, 25 } },
        { "sem p sz"  , new byte[] {24, 33, 32, 32, 30, 31, 32, 25 } },
        { "sem p osz" , new byte[] {24, 33, 32, 30, 30, 33, 32, 25 } },
        { "sem q sz"  , new byte[] {24, 33, 33, 32, 30, 31, 33, 25 } },
        { "sem q osz" , new byte[] {24, 33, 33, 30, 30, 33, 33, 25 } },
        { "sem r sz"  , new byte[] {24, 33, 35, 32, 30, 31, 35, 25 } },
        { "sem r osz" , new byte[] {24, 33, 35, 30, 30, 33, 35, 25 } },
    };

    public static byte[] GetCommand(string command)
    {
        if (_commands.ContainsKey(command.ToLower()))
        {
            return _commands[command.ToLower()];
        }
        return Array.Empty<Byte>();
    }
}
