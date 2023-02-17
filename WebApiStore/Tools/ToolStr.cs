using WebApiStore.Entities;

namespace WebApiStore.Tools
{
    public static class ToolStr
    {
        public enum TypeTransaction
        {
            INGRESO,
            EGRESO
        }

        public static string GenerateCode(string prefix = "", string value = "",int numChar = 1) {
            return prefix + value.PadLeft(numChar, '0');
        }

    }
}
