namespace WebApiStore.Tools
{
    public static class ToolStr
    {
        public static string GenerateCode(string prefix = "", string value = "", int numChar = 1)
        {
            return prefix + value.PadLeft(numChar, '0');
        }
    }
}
