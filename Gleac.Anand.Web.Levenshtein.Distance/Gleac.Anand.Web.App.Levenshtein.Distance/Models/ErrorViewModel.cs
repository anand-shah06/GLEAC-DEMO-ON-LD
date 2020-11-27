using System;

namespace Gleac.Anand.Web.App.Levenshtein.Distance.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}