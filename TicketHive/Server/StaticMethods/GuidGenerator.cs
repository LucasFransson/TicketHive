namespace TicketHive.Server.StaticMethods
{
    public static class GuidGenerator
    {
        public static int GenerateInt()
        {
            Guid myGuid = Guid.NewGuid();
            byte[] byteArray = myGuid.ToByteArray();
            int myInt = BitConverter.ToInt32(byteArray, 0);
            return myInt;
        }
    }
}
