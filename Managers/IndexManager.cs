using System;

namespace ThreeValueViewApi.Managers
{
    public class IndexManager : IIndexManager
    {
        public string GetIndexPageHtml()
        {
            try
            {
                return System.IO.File.ReadAllText("wwwroot/index.html");
            }
            catch (Exception)
            {
                return null;
            }

        }
    }

}