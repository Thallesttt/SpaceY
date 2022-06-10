using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SusOnTrack.Constantes
{
    /// <summary>
    /// Padrão de Controller que eu preciso para o futuro
    /// </summary>
    public class ConstanteControllerWeb : Controller
    {
         private string UrlBase;
         private string Controller;
         private string UrlGet;
         private string UrlPost;
         private string UrlDelete;
         private string UrlOptions;
        public ConstanteControllerWeb(string _urlBase, string _controller,string _urlGet, string _urlPost, string _urlDelete, string _urlOptions)
        {
            this.UrlBase = _urlBase;
            this.Controller = _controller;
            this.UrlGet = _urlGet;
            this.UrlPost = _urlPost;
            this.UrlDelete = _urlDelete;
            this.UrlOptions = _urlOptions;
        }        
    }
}
