using System;
using System.Web;

namespace LaunchSitecore.Models
{
    public class Error
    {
        private Exception exception;

        public Error()
        {
            exception = ((Exception)HttpContext.Current.Session["Last Exception"]) ?? new Exception();
        }

        public string Message
        {
            get { return exception.Message; }
        }

        public string StackTrace
        {
            get { return (exception.StackTrace ?? string.Empty).Replace("\r\n", "<br />"); }
        }

        public bool HasInnerException
        {
            get { return exception.InnerException != null; }
        }

        public string InnerMessage
        {
            get { return HasInnerException ? exception.InnerException.Message : String.Empty; }
        }

        public string InnerStackTrace
        {
            get { return HasInnerException ? exception.InnerException.StackTrace.Replace("\r\n", "<br />") : String.Empty; }
        }
    }
}