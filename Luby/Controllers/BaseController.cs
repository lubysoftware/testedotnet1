using Luby.Models;
using Luby.Util;
using Luby.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;

namespace Luby.Controllers
{
    public class BaseController : ControllerBase, IDisposable
    {
            private AppSettings AppSettings { get; set; }
            private readonly Context _context;
            private IConfiguration _config;
            private IHostingEnvironment environment;
            public DesenvolvedorViewModel user { get; set; }

            public ModelStateDictionary ModelState { get; set; }
            public NameValueCollection Querystring { get; set; }
            public UriBuilder Uri { get; set; }
            public Dictionary<string, object> Form { get; set; }

            public BaseController(IHostingEnvironment environment, params dynamic[] data)
            {
                this.environment = environment;
                ModelState = new ModelStateDictionary();
                if (data != null && data.Length > 1)
                {
                    Querystring = data[0].querystring ?? new NameValueCollection();
                    ModelState.SetModelValue(data[0], data[1]);
                    Form = data[0].data ?? new Dictionary<string, object>();
                    Uri = new UriBuilder(data[0].Uri);
                }
                else if (data != null && data.Length == 1)
                {
                    Querystring = data[0].querystring;
                    Form = data[0].data ?? new Dictionary<string, object>();
                    Uri = new UriBuilder(data[0].Uri);
                }
                else
                {
                    Querystring = new NameValueCollection();
                    Form = new Dictionary<string, object>();
                    Uri = new UriBuilder();
                }
                if (data != null && data.Length > 0)
                {
                    //Log.IP = data[0].IP;
                    //Log.Url = Uri.Uri.PathAndQuery;
                    //Log.Browser = data[0].Browser;
                    //Log.BrowserFull = data[0].BrowserFull;
                }
                int page = 0;
                int.TryParse(Querystring["page"], out page);
                //pagination = new Pagination(page == 0 ? 1 : page);

                //ViewBag = new ExpandoObject();
                //Search = new ExpandoObject();
                //DropDownLists = new Dictionary<string, DropDownList>();
                //RadioButtonLists = new Dictionary<string, RadioButtonList>();
                //CheckBoxLists = new Dictionary<string, CheckBoxList>();
                //SEO = new SEOPage();

            }

            public BaseController(IOptions<AppSettings> settings, IHttpContextAccessor accessor)
            {
                AppSettings = settings.Value;
                if (accessor.HttpContext.User.FindFirst("user") != null)
                {
                    user = JsonConvert.DeserializeObject<DesenvolvedorViewModel>(accessor.HttpContext.User.FindFirst("user").Value);
                }
            }
            public BaseController(IConfiguration config, Context context, IHttpContextAccessor accessor)
            {
                _config = config;
                _context = context;
                if (accessor.HttpContext.User.FindFirst("user") != null)
                {
                    user = JsonConvert.DeserializeObject<DesenvolvedorViewModel>(accessor.HttpContext.User.FindFirst("user").Value);
                }
            }
            public BaseController(Context context)
            {
                _context = context;
            }

            public BaseController()
            {

            }

            public IActionResult ReturnBadRequest(string field, string message)
            {
                if (ModelState == null)
                    ModelState = new ModelStateDictionary();

                ModelState.AddModelError(field, message);
                return BadRequest(ModelState);
            }
            public IActionResult ReturnException(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error500 = new List<string> { ex.ToString() } });
            }

            public string FormatCurrency(string currency, decimal valor)
            {
                return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
            }

            public void Dispose()
            {
                if(_context != null)
                {

                    _context.Dispose();
                }
            }
    }
}
