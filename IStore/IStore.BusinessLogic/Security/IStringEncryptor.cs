namespace IStore.BusinessLogic.Security
{
    internal interface IStringEncryptor
    {
        public string EncryptString(string plain);
        public string DecryptString(string encrypted);
    }
}
