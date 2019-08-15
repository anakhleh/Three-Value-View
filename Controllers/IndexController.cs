using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThreeValueViewApi.Managers;

namespace ThreeValueVueApi.Controllers
{
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly IIndexManager _IIndexManager;

        public IndexController(IIndexManager indexManager)
        {
            _IIndexManager = indexManager;
        }

        // GET api/values
        [HttpGet]
        [Route("/")]
        public IActionResult GetSPAPage()
        {
            var _IIndexManagerResult = _IIndexManager.GetIndexPageHtml();

            if (_IIndexManagerResult == null)
            {
                return new ContentResult()
                {
                    Content = "<html>This website has encountered an error."
                                + "Please contact Alex at <a href=\"mailto:alexnakhleh@outlook.com\">alexnakhleh@outlook.com</a>"
                                + "or contact him through <a href=\"alexnakhleh.co\">alexnakhleh.co</a>"
                                + "<br /><br />Thank you for your patience and understanding."
                                +"</html>",
                    ContentType = "text/html",
                };
            }
            else
            {
                return new ContentResult()
                {
                    Content = _IIndexManagerResult,
                    ContentType = "text/html",
                };
            }
        }
    }
}
