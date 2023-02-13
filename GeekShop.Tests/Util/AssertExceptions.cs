namespace GeekShop.Tests.Util
{
    public static class AssertExceptions
    {
        public static bool HasContent(List<Object> listOfObject)
        {
            if (listOfObject.Count > 0)
                return true;
            return false;

        }
    }
}
