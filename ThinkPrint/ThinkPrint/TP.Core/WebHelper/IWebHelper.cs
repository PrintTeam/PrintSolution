using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP.Core.WebHelper
{
    public interface IWebHelper
    {
        /// <summary>
        /// Get URL referrer
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetUrlReferrer();

        /// <summary>
        /// Get context IP address
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetCurrentIpAddress();
    }
}
