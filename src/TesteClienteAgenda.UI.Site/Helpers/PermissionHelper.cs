using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace TesteClienteAgenda.UI.Site.Helpers
{
    public static class PermissionHelper
    {
        public static string IfAplicarTaxaShow(this RazorPage page, bool quarentena)
        {
            return quarentena ? "disabled=\"disabled\"" : string.Empty;
        }

        public static string IfLinkShow(this RazorPage page, bool ativo)
        {
            return !ativo ? "aria-disabled=\"True\"" : string.Empty;
        }
    }
}
